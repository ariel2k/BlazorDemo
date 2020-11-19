using BlazorDemo.Server.Helpers;
using BlazorDemo.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDemo.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        public PersonController(ApplicationDbContext context, IFileStorage fileStorage)
        {
            Context = context;
            this.fileStorage = fileStorage;
        }

        public ApplicationDbContext Context { get; }
        private readonly IFileStorage fileStorage;

        [HttpPost]
        public async Task<ActionResult<int>> Post(Person person)
        {
            if (!string.IsNullOrWhiteSpace(person.Picture))
            {
                var picture = Convert.FromBase64String(person.Picture);
                person.Picture = await fileStorage.SaveFile(picture, "jpg", "people");
            }

            Context.Add(person);
            await Context.SaveChangesAsync();
            return person.Id;
        }
    }
}
