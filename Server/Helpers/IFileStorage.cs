using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDemo.Server.Helpers
{
    public interface IFileStorage
    {
        Task<string> EditFile(byte[] content, string extension, string containerName, string pathActualFile);
        Task DeleteFile(string path, string containerName);
        Task<string> SaveFile(byte[] content, string extension, string containerName);
    }

    public class FileStorageAzureStorage : IFileStorage
    {
        public FileStorageAzureStorage(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("AzureStorage");
        }

        private readonly string connectionString;

        public async Task DeleteFile(string path, string containerName)
        {
            var account = CloudStorageAccount.Parse(connectionString);
            var servicioCliente = account.CreateCloudBlobClient();
            var contenedor = servicioCliente.GetContainerReference(containerName);

            var blobName = Path.GetFileName(path);
            var blob = contenedor.GetBlobReference(blobName);
            await blob.DeleteIfExistsAsync();
        }

        public async Task<string> EditFile(byte[] content, string extension, string containerName, string pathActualFile)
        {
            if (!string.IsNullOrEmpty(pathActualFile))
            {
                await DeleteFile(pathActualFile, containerName);
            }

            return await SaveFile(content, extension, containerName);
        }

        public async Task<string> SaveFile(byte[] content, string extension, string containerName)
        {
            var account = CloudStorageAccount.Parse(connectionString);
            var clientService = account.CreateCloudBlobClient();
            var container = clientService.GetContainerReference(containerName);
            await container.CreateIfNotExistsAsync();
            await container.SetPermissionsAsync(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });

            var fileName = $"{Guid.NewGuid()}.{extension}";
            var blob = container.GetBlockBlobReference(fileName);
            await blob.UploadFromByteArrayAsync(content, 0, content.Length);
            blob.Properties.ContentType = "image/jpg";
            await blob.SetPropertiesAsync();
            return blob.Uri.ToString();
        }
    }

    public class FileStorageLocalFiles : IFileStorage
    {

        public FileStorageLocalFiles(IWebHostEnvironment env,
            IHttpContextAccessor httpContextAccessor)
        {
            Env = env;
            HttpContextAccessor = httpContextAccessor;
        }

        public IWebHostEnvironment Env { get; }
        public IHttpContextAccessor HttpContextAccessor { get; }

        public Task DeleteFile(string path, string containerName)
        {
            var filename = Path.GetFileName(path);
            string directorioArchivo = Path.Combine(Env.WebRootPath, containerName, filename);
            if (File.Exists(directorioArchivo))
            {
                File.Delete(directorioArchivo);
            }

            return Task.FromResult(0);
        }

        public async Task<string> EditFile(byte[] content, string extension, string containerName, string pathActualFile)
        {
            if (!string.IsNullOrEmpty(pathActualFile))
            {
                await DeleteFile(pathActualFile, containerName);
            }

            return await SaveFile(content, extension, containerName);
        }

        public async Task<string> SaveFile(byte[] content, string extension, string containerName)
        {
            var filename = $"{Guid.NewGuid()}.{extension}";
            string folder = Path.Combine(Env.WebRootPath, containerName);

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            string path = Path.Combine(folder, filename);
            await File.WriteAllBytesAsync(path, content);

            var urlActual = $"{HttpContextAccessor.HttpContext.Request.Scheme}://{HttpContextAccessor.HttpContext.Request.Host}";
            var urlDB = Path.Combine(urlActual, containerName, filename);
            return urlDB;
        }
    }
}
