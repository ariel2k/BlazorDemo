using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorDemo.Shared.Models
{
    public class GenderFilm
    {
        public int FilmId{ get; set; }
        public int GenderId{ get; set; }
        
        public Gender Gender { get; set; }
        
        public Film Film { get; set; }
    }
}
