using BlazorDemo.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDemo.Client.Repositories
{
    public interface IRepository
    {
        List<Film> GetFilms();
    }
}
