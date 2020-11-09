using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorDemo.Shared.Models
{
    public class Film
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Summary { get; set; }
        [Required]
        public DateTime? ReleaseDate { get; set; }
        public bool OnBillboard { get; set; }
        public string TrailerURL { get; set; }
        public string ImgURL { get; set; }
        public List<GenderFilm> GenderFilms { get; set; } = new List<GenderFilm>();
        public string ShortTitle { 
            get {
                if (string.IsNullOrEmpty(Title))
                {
                    return null;
                }

                if(Title.Length > 60)
                {
                    return $"{Title.Substring(0, 60)}...";
                }

                return Title;
            } 
        }
    }
}
