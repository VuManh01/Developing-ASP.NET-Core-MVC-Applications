using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ComicSystem.Data;
using ComicSystem.Models;

namespace ComicSystem.Controllers
{
    public class RentalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RentalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rentals/Create
        public IActionResult Create()
        {
            ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "FullName");
            ViewData["ComicBookID"] = new SelectList(_context.ComicBooks, "ComicBookID", "Title");
            return View();
        }

        // POST: Rentals/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerID,RentalDate,ReturnDate,ComicBookID,Quantity")] RentalInputModel rental)
        {
            if (ModelState.IsValid)
            {
                // Add Rental
                var newRental = new Rental
                {
                    CustomerID = rental.CustomerID,
                    RentalDate = rental.RentalDate,
                    ReturnDate = rental.ReturnDate,
                    Status = "Rented"
                };

                _context.Add(newRental);
                await _context.SaveChangesAsync();

                // Add RentalDetails
                var rentalDetail = new RentalDetail
                {
                    RentalID = newRental.RentalID,
                    ComicBookID = rental.ComicBookID,
                    Quantity = rental.Quantity,
                    PricePerDay = await _context.ComicBooks
                        .Where(c => c.ComicBookID == rental.ComicBookID)
                        .Select(c => c.PricePerDay)
                        .FirstOrDefaultAsync()
                };

                _context.Add(rentalDetail);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index), "ComicBooks");
            }

            ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "FullName", rental.CustomerID);
            ViewData["ComicBookID"] = new SelectList(_context.ComicBooks, "ComicBookID", "Title", rental.ComicBookID);
            return View(rental);
        }
    }
}
