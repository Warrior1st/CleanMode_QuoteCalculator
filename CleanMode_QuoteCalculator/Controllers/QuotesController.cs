using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CleanMode_QuoteCalculator.Models;

namespace CleanMode_QuoteCalculator.Controllers
{
    public class QuotesController : Controller
    {
        private readonly CleanModeContext _context;

        public QuotesController(CleanModeContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Quote quote, List<string> UnitType, string area1)
        {

            if (ModelState.IsValid)
            {
                float finalPrice = 0f;
                
                foreach (string unit in UnitType)
                {
                    switch (unit)
                    {
                        case "basement":
                            var basement = _context.Basements.Where(a => a.RoomTypeId == 8).FirstOrDefault();
                            var price = basement.PricePerSqft * int.Parse(area1);
                            finalPrice += (float) price;
                            break;
                        case "bathroom":
                            var bathroom = _context.Bathrooms.Where(a => a.RoomTypeId == 2).FirstOrDefault();
                            var price2 = bathroom.PricePerSqft * int.Parse(area1);
                            finalPrice += (float)price2;
                            break;
                        case "garage":
                            var garage = _context.Garages.Where(a => a.RoomTypeId == 5).FirstOrDefault();
                            var price3 = garage.PricePerSqft * int.Parse(area1);
                            finalPrice += (float)price3;
                            break;
                        case "livingroom":
                            var livingroom = _context.Livingrooms.Where(a => a.RoomTypeId == 4).FirstOrDefault();
                            var price4 = livingroom.PricePerSqft * int.Parse(area1);
                            finalPrice += (float)price4;
                            break;
                        //case "diningroom":
                        //    var diningroom = _context.Diningrooms.Where(a => a.RoomTypeId == 4).FirstOrDefault();
                        //    var price4 = diningroom.PricePerSqft * int.Parse(area1);
                        //    finalPrice += (float)price4;
                        //    break;
                        //case "stairs":
                        //    var livingroom = _context.Livingrooms.Where(a => a.RoomTypeId == 4).FirstOrDefault();
                        //    var price4 = livingroom.PricePerSqft * int.Parse(area1);
                        //    finalPrice += (float)price4;
                        //    break;
                        //case "kitchen":
                        //    var livingroom = _context.Livingrooms.Where(a => a.RoomTypeId == 4).FirstOrDefault();
                        //    var price4 = livingroom.PricePerSqft * int.Parse(area1);
                        //    finalPrice += (float)price4;
                        //    break;
                        //case "bedroom":
                        //    var livingroom = _context.Livingrooms.Where(a => a.RoomTypeId == 4).FirstOrDefault();
                        //    var price4 = livingroom.PricePerSqft * int.Parse(area1);
                        //    finalPrice += (float)price4;
                        //    break;
                        default:
                            break;
                    }
                }

               
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", quote.CustomerId);
            return View(quote);
        }

        // GET: Quotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quote = await _context.Quotes
                .Include(q => q.Customer)
                .FirstOrDefaultAsync(m => m.QuoteId == id);
            if (quote == null)
            {
                return NotFound();
            }

            return View(quote);
        }

        // GET: Quotes/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId");
            return View();
        }

        // POST: Quotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QuoteId,CustomerId,Quote1")] Quote quote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", quote.CustomerId);
            return View(quote);
        }

        // GET: Quotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quote = await _context.Quotes.FindAsync(id);
            if (quote == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", quote.CustomerId);
            return View(quote);
        }

        // POST: Quotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("QuoteId,CustomerId,Quote1")] Quote quote)
        {
            if (id != quote.QuoteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuoteExists(quote.QuoteId))
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
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", quote.CustomerId);
            return View(quote);
        }

        // GET: Quotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quote = await _context.Quotes
                .Include(q => q.Customer)
                .FirstOrDefaultAsync(m => m.QuoteId == id);
            if (quote == null)
            {
                return NotFound();
            }

            return View(quote);
        }

        // POST: Quotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quote = await _context.Quotes.FindAsync(id);
            _context.Quotes.Remove(quote);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuoteExists(int id)
        {
            return _context.Quotes.Any(e => e.QuoteId == id);
        }
    }
}
