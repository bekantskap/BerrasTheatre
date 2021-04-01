using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BerrasTheatre.Models
{
    public class Show
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public int MovieId { get; set; }
        public int SalonId { get; set; }
        public int RemainingSeats { get; set; }
        public Movie Movie { get; set; }
        public Salon Salon { get; set; }
        public ICollection<ShowSeat> ShowSeats { get; set; }
    }
}
