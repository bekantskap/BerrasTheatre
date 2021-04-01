using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BerrasTheatre.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Info { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh\\:mm}")]
        public TimeSpan TimeSpan { get; set; }
        public decimal TicketPrice { get; set; }
        public ICollection<Show> Shows { get; set; }
    }
}
