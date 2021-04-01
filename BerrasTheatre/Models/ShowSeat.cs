using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BerrasTheatre.Models
{
    public class ShowSeat
    {
        public int Id { get; set; }
        public int ShowId { get; set; }
        public int Seat { get; set; }
        public bool Booked { get; set; }
        public Show Show { get; set; }
    }
}
