using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorDemo.Shared.Models
{
    public class Film
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ImgURL { get; set; }
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
