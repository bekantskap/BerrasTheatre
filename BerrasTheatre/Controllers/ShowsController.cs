using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BerrasTheatre.Data;
using BerrasTheatre.Models;

namespace BerrasTheatre.Controllers
{
    public class ShowsController : Controller
    {
        private readonly CinemaContext _context;

        public ShowsController(CinemaContext context)
        {
            _context = context;
        }

        // GET: Shows
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["StartTimeSortParm"] = sortOrder == "Time" ? "time_desc" : "Time";
            ViewData["MovieTitleSortParm"] = String.IsNullOrEmpty(sortOrder) ? "movietitle_desc" : "";
            ViewData["TimeSpanSortParm"] = sortOrder == "TimeSpan" ? "timespan_desc" : "TimeSpan";
            ViewData["SalonSortParm"] = sortOrder == "SalonId" ? "salon_desc" : "SalonId";
            ViewData["SeatsSortParm"] = sortOrder == "Seats" ? "seats_desc" : "Seats";
            ViewData["RemainingSeatsSortParm"] = sortOrder == "RemainingSeats" ? "remainingseats_desc" : "RemainingSeats";

            DateTime today = DateTime.Today;
            ViewData["DateToDay"] = today.ToString("yyyy-MM-dd");

            var shows = from s in _context.Shows
                           .Include(m => m.Movie)
                           .Include(s => s.Salon)
                        select s;

            switch (sortOrder)
            {
                case "Time":
                    shows = shows.OrderBy(s => s.StartTime);
                    break;

                case "time_desc":
                    shows = shows.OrderByDescending(s => s.StartTime);
                    break;

                case "movietitle_desc":
                    shows = shows.OrderByDescending(m => m.Movie.Title);
                    break;

                case "TimeSpan":
                    shows = shows.OrderBy(s => s.Movie.TimeSpan);
                    break;

                case "timespan_desc":
                    shows = shows.OrderByDescending(s => s.Movie.TimeSpan);
                    break;

                case "SalonId":
                    shows = shows.OrderBy(s => s.SalonId);
                    break;

                case "salon_desc":
                    shows = shows.OrderByDescending(s => s.SalonId);
                    break;

                case "Seats":
                    shows = shows.OrderBy(s => s.Salon.SeatNum);
                    break;

                case "seats_desc":
                    shows = shows.OrderByDescending(s => s.Salon.SeatNum);
                    break;

                case "RemainingSeats":
                    shows = shows.OrderBy(s => s.RemainingSeats);
                    break;

                case "remainingseats_desc":
                    shows = shows.OrderByDescending(s => s.RemainingSeats);
                    break;

                default:
                    shows = shows.OrderBy(m => m.Movie.Title);
                    break;

            }


            return View(await shows.AsNoTracking().ToListAsync());

        }
        [HttpGet]
        public ActionResult Book(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var selectedShowing = _context.Shows
           .Include(a => a.Salon)
           .Include(m => m.Movie)
           .SingleOrDefault(m => m.Id == id);

            DateTime today = DateTime.Today;
            ViewData["DateToDay"] = today.ToString("yyyy-MM-dd");

            ViewData["RemainingSeats"] = selectedShowing.RemainingSeats < 12 ? selectedShowing.RemainingSeats : 12;

            ViewData["BookAvailable"] = selectedShowing.RemainingSeats;

            var ticketMoviePrice = selectedShowing.Movie.TicketPrice;

            var salonTicketPrice = (decimal)selectedShowing.Salon.TicketPrice;

            ViewData["TicketPrice"] = ticketMoviePrice * salonTicketPrice;

            if (selectedShowing == null)
            {
                return NotFound();
            }

            return View(selectedShowing);
        }
        [HttpPost]
        public ActionResult Book(int? id, int nrOfTickets)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookedShow = _context.Shows
               .Include(a => a.Salon)
               .Include(m => m.Movie)
               .SingleOrDefault(m => m.Id == id);

            bookedShow.RemainingSeats -= nrOfTickets;

            _context.Update(bookedShow);
            _context.SaveChanges();

            if (bookedShow == null)
            {
                return NotFound();
            }

            return RedirectToAction("Booked", new { id, nrOfTickets });
        }
        [HttpGet]
        public ActionResult Booked(int? id, int? nrOfTickets)
        {
            if (id == null || nrOfTickets == null)
            {
                return NotFound();
            }

            var selectedShow = _context.Shows
           .Include(a => a.Salon)
           .Include(m => m.Movie)
           .SingleOrDefault(m => m.Id == id);

            DateTime today = DateTime.Today;
            ViewData["DateToDay"] = today.ToString("yyyy-MM-dd");

            ViewData["NrOfTIckets"] = nrOfTickets;

            var ticketMoviePrice = selectedShow.Movie.TicketPrice;

            var salonTicketPrice = (decimal)selectedShow.Salon.TicketPrice;

            ViewData["TicketPrice"] = ticketMoviePrice * salonTicketPrice;

            ViewData["TotalTicketPrice"] = ticketMoviePrice * salonTicketPrice * nrOfTickets;


            if (selectedShow == null)
            {
                return NotFound();
            }

            return View(selectedShow);
        }

        // GET: Shows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.Shows
                .Include(s => s.Movie)
                .Include(s => s.Salon)
                .FirstOrDefaultAsync(m => m.Id == id);
            var ticketMoviePrice = show.Movie.TicketPrice;

            var salonTicketPrice = (decimal)show.Salon.TicketPrice;

            ViewData["TicketPrice"] = ticketMoviePrice * salonTicketPrice;

            DateTime today = DateTime.Today;
            ViewData["DateToDay"] = today.ToString("yyyy-MM-dd");
            if (show == null)
            {
                return NotFound();
            }

            return View(show);
        }

        // GET: Shows/Create
        public IActionResult Create()
        {
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id");
            ViewData["SalonId"] = new SelectList(_context.Salons, "Id", "Id");
            return View();
        }

        // POST: Shows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartTime,MovieId,SalonId,RemainingSeats")] Show show)
        {
            if (ModelState.IsValid)
            {
                _context.Add(show);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", show.MovieId);
            ViewData["SalonId"] = new SelectList(_context.Salons, "Id", "Id", show.SalonId);
            return View(show);
        }

        // GET: Shows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.Shows.FindAsync(id);
            if (show == null)
            {
                return NotFound();
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", show.MovieId);
            ViewData["SalonId"] = new SelectList(_context.Salons, "Id", "Id", show.SalonId);
            return View(show);
        }

        // POST: Shows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StartTime,MovieId,SalonId,RemainingSeats")] Show show)
        {
            if (id != show.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(show);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShowExists(show.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", show.MovieId);
            ViewData["SalonId"] = new SelectList(_context.Salons, "Id", "Id", show.SalonId);
            return View(show);
        }

        // GET: Shows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _context.Shows
                .Include(s => s.Movie)
                .Include(s => s.Salon)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (show == null)
            {
                return NotFound();
            }

            return View(show);
        }

        // POST: Shows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var show = await _context.Shows.FindAsync(id);
            _context.Shows.Remove(show);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShowExists(int id)
        {
            return _context.Shows.Any(e => e.Id == id);
        }
    }
}
