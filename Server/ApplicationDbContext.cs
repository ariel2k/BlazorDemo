using BlazorDemo.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDemo.Server
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GenderFilm>().HasKey(x => new { x.GenderId, x.FilmId });
            modelBuilder.Entity<PersonFilm>().HasKey(x => new { x.PersonId, x.FilmId });
            base.OnModelCreating(modelBuilder); 
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Film>  Films { get; set; }
        public DbSet<Gender> Genders  { get; set; }
        public DbSet<GenderFilm> GenderFilms{ get; set; }
        public DbSet<PersonFilm> PersonFilms { get; set; }
    }
}
