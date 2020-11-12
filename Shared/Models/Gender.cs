using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorDemo.Shared.Models
{
    public class Gender
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; }
        public List<GenderFilm> GenderFilms { get; set; }
    }
}
