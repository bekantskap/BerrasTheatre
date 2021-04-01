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
    public class ShowSeatsController : Controller
    {
        private readonly CinemaContext _context;

        public ShowSeatsController(CinemaContext context)
        {
            _context = context;
        }

        // GET: ShowSeats
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["StartSortParm"] = sortOrder == "Time" ? "time_desc" : "Time";
            ViewData["MovieTitleSortParm"] = String.IsNullOrEmpty(sortOrder) ? "movietitle_desc" : "";
            ViewData["TimespanSortParm"] = sortOrder == "Timespan" ? "timespan_desc" : "Timespan";
            ViewData["SalonNameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "salonname_desc" : "";
            ViewData["RemainingSeatsSortParm"] = sortOrder == "RemainingSeats" ? "remainingseats_desc" : "RemainingSeats";

            DateTime today = DateTime.Today;
            ViewData["DateToDay"] = today.ToString("yyyy-MM-dd");

            var showseats = from s in _context.ShowSeats.Include(s => s.Show).ThenInclude(m => m.Movie)
                               select s;

            switch (sortOrder)
            {
                case "Time":
                    showseats = showseats.OrderBy(s => s.Show.StartTime);
                    break;

                case "time_desc":
                    showseats = showseats.OrderByDescending(s => s.Show.StartTime);
                    break;

                case "movietitle_desc":
                    showseats = showseats.OrderBy(m => m.Show.Movie.Title);
                    break;

                case "Timespan":
                    showseats = showseats.OrderBy(s => s.Show.Movie.TimeSpan);
                    break;

                case "timespan_desc":
                    showseats = showseats.OrderByDescending(s => s.Show.Movie.TimeSpan);
                    break;

                case "salonname_desc":
                    showseats = showseats.OrderBy(s => s.Show.SalonId);
                    break;

                case "RemainingSeats":
                    showseats = showseats.OrderByDescending(s => s.Show.RemainingSeats);
                    break;

                case "remainingseats_desc":
                    showseats = showseats.OrderByDescending(s => s.Show.RemainingSeats);
                    break;

                default:
                    showseats = showseats.OrderBy(s => s.Show.StartTime);
                    break;

            }


            return View(await showseats.AsNoTracking().ToListAsync());

        }

        // GET: ShowSeats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var showSeat = await _context.ShowSeats
                .Include(s => s.Show)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (showSeat == null)
            {
                return NotFound();
            }

            return View(showSeat);
        }

        // GET: ShowSeats/Create
        public IActionResult Create()
        {
            ViewData["ShowId"] = new SelectList(_context.Shows, "Id", "Id");
            return View();
        }

        // POST: ShowSeats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ShowId,Seat,Booked")] ShowSeat showSeat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(showSeat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ShowId"] = new SelectList(_context.Shows, "Id", "Id", showSeat.ShowId);
            return View(showSeat);
        }

        // GET: ShowSeats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var showSeat = await _context.ShowSeats.SingleOrDefaultAsync(m => m.Id == id);
            if (showSeat == null)
            {
                return NotFound();
            }
            ViewData["ShowId"] = new SelectList(_context.Shows, "Id", "Id", showSeat.ShowId);
            return View(showSeat);
        }

        // POST: ShowSeats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ShowId,Seat,Booked")] ShowSeat showSeat)
        {
            if (id != showSeat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(showSeat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShowSeatExists(showSeat.Id))
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
            ViewData["ShowId"] = new SelectList(_context.Shows, "Id", "Id", showSeat.ShowId);
            return View(showSeat);
        }

        // GET: ShowSeats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var showSeat = await _context.ShowSeats
                .Include(s => s.Show)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (showSeat == null)
            {
                return NotFound();
            }

            return View(showSeat);
        }

        // POST: ShowSeats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var showSeat = await _context.ShowSeats.FindAsync(id);
            _context.ShowSeats.Remove(showSeat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShowSeatExists(int id)
        {
            return _context.ShowSeats.Any(e => e.Id == id);
        }
    }
}
