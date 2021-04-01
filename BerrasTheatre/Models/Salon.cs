using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BerrasTheatre.Models
{
    public class Salon
    {
        public int Id { get; set; }
        public string Info { get; set; }
        public double TicketPrice { get; set; }
        public int SeatNum { get; set; }
        public ICollection<Show> Shows { get; set; }
    }
}
