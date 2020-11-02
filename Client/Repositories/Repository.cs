using BlazorDemo.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDemo.Client.Repositories
{
    public class Repository : IRepository
    {
        public List<Film> GetFilms()
        {
            return new List<Film>()
            {
                new Film() {Title="Spider-man: Far from home", ReleaseDate=new DateTime(2019,7,2)},
                new Film() {Title="Moana", ReleaseDate=new DateTime(2016,11,23)},
                new Film() {Title="Inception", ReleaseDate=new DateTime(2010,7,16)},
            };
        }
    }
}
