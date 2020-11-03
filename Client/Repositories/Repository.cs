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
                new Film() 
                {
                    Title="Spider-man: Far from home", 
                    ReleaseDate=new DateTime(2019,7,2),
                    ImgURL="https://m.media-amazon.com/images/M/MV5BMGZlNTY1ZWUtYTMzNC00ZjUyLWE0MjQtMTMxN2E3ODYxMWVmXkEyXkFqcGdeQXVyMDM2NDM2MQ@@._V1_UX182_CR0,0,182,268_AL_.jpg"
                },
                new Film() 
                {
                    Title="Moana", 
                    ReleaseDate=new DateTime(2016,11,23),
                    ImgURL="https://m.media-amazon.com/images/M/MV5BMjI4MzU5NTExNF5BMl5BanBnXkFtZTgwNzY1MTEwMDI@._V1_UX182_CR0,0,182,268_AL_.jpg"
                },
                new Film() 
                {
                    Title="Inception", 
                    ReleaseDate=new DateTime(2010,7,16),
                    ImgURL="https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_UX182_CR0,0,182,268_AL_.jpg"
                },
            };
        }
    }
}
