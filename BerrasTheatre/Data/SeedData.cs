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
            new Movie{Title="50 Shades of Grey",Info="Literature student Anastasia Steele's life changes forever when she meets handsome, yet tormented, billionaire Christian Grey.", TimeSpan = new TimeSpan(2, 05, 0), TicketPrice=75},
            new Movie{Title="Avengers: Age of Ultron",Info="When Tony Stark and Bruce Banner try to jump-start a dormant peacekeeping program called Ultron, things go horribly wrong and it's up to Earth's mightiest heroes to stop the villainous Ultron from enacting his terrible plan.", TimeSpan = new TimeSpan(2, 21, 0), TicketPrice=95},
            new Movie{Title="Justice League",Info="Determined to ensure Superman's ultimate sacrifice was not in vain, Bruce Wayne aligns forces with Diana Prince with plans to recruit a team of metahumans to protect the world from an approaching threat of catastrophic proportions.", TimeSpan = new TimeSpan(4, 05, 0), TicketPrice=100},
            new Movie{Title="Fight Club",Info="An insomniac office worker and a devil-may-care soapmaker form an underground fight club that evolves into something much, much more.", TimeSpan = new TimeSpan(2, 19, 0), TicketPrice=75},
            new Movie{Title="Forrest Gump",Info="The presidencies of Kennedy and Johnson, the Vietnam War, the Watergate scandal and other historical events unfold from the perspective of an Alabama man with an IQ of 75, whose only desire is to be reunited with his childhood sweetheart.", TimeSpan = new TimeSpan(2, 22, 0), TicketPrice=80},
            new Movie{Title="The Godfather",Info="An organized crime dynasty's aging patriarch transfers control of his clandestine empire to his reluctant son.", TimeSpan = new TimeSpan(2, 05, 0), TicketPrice=75},
            new Movie{Title="Goodfellas",Info="The story of Henry Hill and his life in the mob, covering his relationship with his wife Karen Hill and his mob partners Jimmy Conway and Tommy DeVito in the Italian-American crime syndicate.", TimeSpan = new TimeSpan(2, 05, 0), TicketPrice=75},
            new Movie{Title="Godzilla vs. Kong",Info="The epic next chapter in the cinematic Monsterverse pits two of the greatest icons in motion picture history against one another - the fearsome Godzilla and the mighty Kong - with humanity caught in the balance.", TimeSpan = new TimeSpan(2, 05, 0), TicketPrice=75},
            new Movie{Title="Avengers: Infinity War",Info="The Avengers and their allies must be willing to sacrifice all in an attempt to defeat the powerful Thanos before his blitz of devastation and ruin puts an end to the universe.", TimeSpan = new TimeSpan(2, 05, 0), TicketPrice=75},
            new Movie{Title="Insidious",Info="A family looks to prevent evil spirits from trapping their comatose child in a realm called The Further.", TimeSpan = new TimeSpan(2, 05, 0), TicketPrice=75},
            new Movie{Title="Iron Man",Info="After being held captive in an Afghan cave, billionaire engineer Tony Stark creates a unique weaponized suit of armor to fight evil.", TimeSpan = new TimeSpan(2, 05, 0), TicketPrice=75},
            new Movie{Title="Joker",Info="In Gotham City, mentally troubled comedian Arthur Fleck is disregarded and mistreated by society. He then embarks on a downward spiral of revolution and bloody crime. This path brings him face-to-face with his alter-ego: the Joker.", TimeSpan = new TimeSpan(2, 05, 0), TicketPrice=75},
            new Movie{Title="Lord of The Rings",Info="A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.", TimeSpan = new TimeSpan(2, 05, 0), TicketPrice=75},
            new Movie{Title="The matrix",Info="When a beautiful stranger leads computer hacker Neo to a forbidding underworld, he discovers the shocking truth--the life he knows is the elaborate deception of an evil cyber-intelligence.", TimeSpan = new TimeSpan(2, 05, 0), TicketPrice=75},
            new Movie{Title="Nobody",Info="A bystander who intervenes to help a woman being harassed by a group of men becomes the target of a vengeful drug lord.", TimeSpan = new TimeSpan(2, 05, 0), TicketPrice=75},
            new Movie{Title="The Prestige",Info="After a tragic accident, two stage magicians engage in a battle to create the ultimate illusion while sacrificing everything they have to outwit each other.", TimeSpan = new TimeSpan(2, 05, 0), TicketPrice=75},
            new Movie{Title="Pulp Fiction",Info="The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.", TimeSpan = new TimeSpan(2, 05, 0), TicketPrice=75},
            new Movie{Title="Scarface",Info="In 1980 Miami, a determined Cuban immigrant takes over a drug cartel and succumbs to greed.", TimeSpan = new TimeSpan(2, 05, 0), TicketPrice=75},
            new Movie{Title="Shutter Island",Info="In 1954, a U.S. Marshal investigates the disappearance of a murderer who escaped from a hospital for the criminally insane.", TimeSpan = new TimeSpan(2, 05, 0), TicketPrice=75},
            new Movie{Title="Doctor Strange",Info="While on a journey of physical and spiritual healing, a brilliant neurosurgeon is drawn into the world of the mystic arts.", TimeSpan = new TimeSpan(2, 05, 0), TicketPrice=75},
            new Movie{Title="Suicide Squad",Info="A secret government agency recruits some of the most dangerous incarcerated super-villains to form a defensive task force. Their first mission: save the world from the apocalypse.", TimeSpan = new TimeSpan(2, 05, 0), TicketPrice=75},
            new Movie{Title="The Wolf of Wall street",Info="Based on the true story of Jordan Belfort, from his rise to a wealthy stock-broker living the high life to his fall involving crime, corruption and the federal government.", TimeSpan = new TimeSpan(2, 05, 0), TicketPrice=75},
            new Movie{Title="Wonder Woman",Info="When a pilot crashes and tells of conflict in the outside world, Diana, an Amazonian warrior in training, leaves home to fight a war, discovering her full powers and true destiny.", TimeSpan = new TimeSpan(2, 05, 0), TicketPrice=75},
            };
            foreach (Movie m in movies)
            {
                context.Movies.Add(m);
            }
            context.SaveChanges();

            var salons = new Salon[]
            {
            new Salon{Info="Traditional salon with old school 3d cardboard glasses.",SeatNum=50, TicketPrice=1},
            new Salon{Info="Top of the line salon with Dolby 3000 sound system and massage chairs.", SeatNum=100, TicketPrice=1.1}

            };
            foreach (Salon s in salons)
            {
                context.Salons.Add(s);
            }
            context.SaveChanges();

            var showings = new Show[]
            {
            new Show{StartTime=DateTime.Parse("14:00"),MovieId=4,SalonId=1,RemainingSeats=70},
            new Show{StartTime=DateTime.Parse("14:00"),MovieId=4,SalonId=2,RemainingSeats=30},
            new Show{StartTime=DateTime.Parse("16:30"),MovieId=1,SalonId=1,RemainingSeats=32},
            new Show{StartTime=DateTime.Parse("20:00"),MovieId=2,SalonId=1,RemainingSeats=22},
            new Show{StartTime=DateTime.Parse("23:30"),MovieId=3,SalonId=1,RemainingSeats=37},
            new Show{StartTime=DateTime.Parse("16:00"),MovieId=1,SalonId=2,RemainingSeats=22},
            new Show{StartTime=DateTime.Parse("19:30"),MovieId=2,SalonId=2,RemainingSeats=10},
            new Show{StartTime=DateTime.Parse("23:00"),MovieId=3,SalonId=2,RemainingSeats=15},
            new Show{StartTime=DateTime.Parse("02:00"),MovieId=7,SalonId=1,RemainingSeats=43},
            new Show{StartTime=DateTime.Parse("02:00"),MovieId=8,SalonId=2,RemainingSeats=35},
            new Show{StartTime=DateTime.Parse("04:30"),MovieId=9,SalonId=1,RemainingSeats=5},
            new Show{StartTime=DateTime.Parse("07:00"),MovieId=6,SalonId=1,RemainingSeats=11},
            new Show{StartTime=DateTime.Parse("10:30"),MovieId=5,SalonId=1,RemainingSeats=15},
            new Show{StartTime=DateTime.Parse("05:00"),MovieId=10,SalonId=2,RemainingSeats=6},
            new Show{StartTime=DateTime.Parse("08:30"),MovieId=11,SalonId=2,RemainingSeats=14},
            new Show{StartTime=DateTime.Parse("11:00"),MovieId=12,SalonId=2,RemainingSeats=7}

            };
            foreach (Show s in showings)
            {
                context.Shows.Add(s);
            }
            context.SaveChanges();
        }
    }
}
