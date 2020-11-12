using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorDemo.Shared.Models
{
    public class PersonFilm
    {
        public int PersonId { get; set; }
        public int FilmId { get; set; }
        public Person Person { get; set; }
        public Film Film { get; set; }
        public string Character { get; set; }
        public int Order { get; set; }
    }
}
