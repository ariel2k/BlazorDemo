using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorDemo.Shared.Models
{
    public class VoteFillm
    {
        public int Id { get; set; }
        public int Vote { get; set; }
        public DateTime VoteDate { get; set; }
        public int FilmId { get; set; }
        public Film Film { get; set; }
    }
}
