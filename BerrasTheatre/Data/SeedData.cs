using BerrasTheatre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BerrasTheatre.Data
{
    public class SeedData
    {
        public static void Initialize(CinemaContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Movies.Any())
            {
                return;   // DB has been seeded
            }

            var movies = new Movie[]
            {
            new Movie{Title="Raiders Of the Lost Ark",Info="In 1936, archaeologist and adventurer Indiana Jones is hired by the U.S. government to find the Ark of the Covenant before Adolf Hitler's Nazis can obtain its awesome powers.", TimeSpan = new TimeSpan(2, 32, 0), TicketPrice=80},
            new Movie{Title="Mission Impossible: Fallout",Info="Ethan Hunt and his IMF team, along with some familiar allies, race against time after a mission gone wrong.", TimeSpan = new TimeSpan(3, 02, 0), TicketPrice=90},
            new Movie{Title="50 Shades of Grey",Info="Literature student Anastasia Steele's life changes forever when she meets handsome, yet tormented, billionaire Christian Grey.", TimeSpan = new TimeSpan(2, 05, 0), TicketPrice=75}

            };
            foreach (Movie m in movies)
            {
                context.Movies.Add(m);
            }
            context.SaveChanges();

            var lounges = new Salon[]
            {
            new Salon{Info="The small lounge with 3D screen and comfortable chairs",SeatNum=50, TicketPrice=1},
            new Salon{Info="The big lounge with 3D screen and simolator comfortable chairs for optional 4D enjoyment", SeatNum=100, TicketPrice=1.1}

            };
            foreach (Salon l in lounges)
            {
                context.Salons.Add(l);
            }
            context.SaveChanges();

            var showings = new Show[]
            {
            new Show{StartTime=DateTime.Parse("16:30"),MovieId=1,SalonId=1,RemainingSeats=5},
            new Show{StartTime=DateTime.Parse("20:00"),MovieId=2,SalonId=1,RemainingSeats=5},
            new Show{StartTime=DateTime.Parse("23:30"),MovieId=3,SalonId=1,RemainingSeats=5},
             new Show{StartTime=DateTime.Parse("16:00"),MovieId=1,SalonId=2,RemainingSeats=5},
            new Show{StartTime=DateTime.Parse("19:30"),MovieId=2,SalonId=2,RemainingSeats=5},
            new Show{StartTime=DateTime.Parse("23:00"),MovieId=3,SalonId=2,RemainingSeats=15}

            };
            foreach (Show s in showings)
            {
                context.Shows.Add(s);
            }
            context.SaveChanges();
        }
    }
}
