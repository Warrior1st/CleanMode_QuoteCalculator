using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CleanMode_QuoteCalculator.Models;
using Microsoft.AspNetCore.Identity;

namespace CleanMode_QuoteCalculator.Controllers
{
    public class QuotesController : Controller
    {
        private readonly CleanModeContext _context;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;

        public QuotesController(CleanModeContext context, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _context = context;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Quote quote, List<string> UnitType, List<string> area)
        {

            if (ModelState.IsValid)
            {
                //Creating admin roles
                //CODE IS TO BE DELETED FOR SECURITY RESONS AFTER SETTING UP THE DATABASE
                //if (roleManager.FindByNameAsync("ADMINISTRATOR") == null)
                //{
                IdentityRole role = new IdentityRole { Name = "CUSTOMER" };
                await roleManager.CreateAsync(role);
                //}

                var user = await userManager.FindByEmailAsync("sebujo@gmail.com");

                await userManager.AddToRoleAsync(user, "ADMINISTRATOR");





                float finalPrice = 0f;

                for (int i = 0; i < UnitType.Count; i++)
                {
                    switch (UnitType[i])
                    {
                        case "basement":
                            var basement = _context.Basements.Where(a => a.RoomTypeId == 8).FirstOrDefault();
                            var price = basement.PricePerSqft * int.Parse(area[i]);
                            finalPrice += (float)price;
                            break;
                        case "bathroom":
                            var bathroom = _context.Bathrooms.Where(a => a.RoomTypeId == 2).FirstOrDefault();
                            var price2 = bathroom.PricePerSqft * int.Parse(area[i]);
                            finalPrice += (float)price2;
                            break;
                        case "garage":
                            var garage = _context.Garages.Where(a => a.RoomTypeId == 5).FirstOrDefault();
                            var price3 = garage.PricePerSqft * int.Parse(area[i]);
                            finalPrice += (float)price3;
                            break;
                        case "livingroom":
                            var livingroom = _context.Livingrooms.Where(a => a.RoomTypeId == 4).FirstOrDefault();
                            var price4 = livingroom.PricePerSqft * int.Parse(area[i]);
                            finalPrice += (float)price4;
                            break;
                        case "diningroom":
                            var diningroom = _context.Diningrooms.Where(a => a.RoomTypeId == 3).FirstOrDefault();
                            var price5 = diningroom.PricePerSqft * int.Parse(area[i]);
                            finalPrice += (float)price5;
                            break;
                        case "stairs":
                            var stairs = _context.Stairs.Where(a => a.RoomTypeId == 9).FirstOrDefault();
                            var price6 = stairs.PricePerSqft * int.Parse(area[i]);
                            finalPrice += (float)price6;
                            break;
                        case "kitchen":
                            var kitchen = _context.Kitchens.Where(a => a.RoomTypeId == 7).FirstOrDefault();
                            var price7 = kitchen.PricePerSqft * int.Parse(area[i]);
                            finalPrice += (float)price7;
                            break;
                        case "bedroom":
                            var bedroom = _context.Bedrooms.Where(a => a.RoomTypeId == 1).FirstOrDefault();
                            var price8 = bedroom.PricePerSqft * int.Parse(area[i]);
                            finalPrice += (float)price8;
                            break;
                        case "entrance":
                            var entrance = _context.Entrances.Where(a => a.RoomTypeId == 6).FirstOrDefault();
                            var price9 = entrance.PricePerSqft * int.Parse(area[i]);
                            finalPrice += (float)price9;
                            break;
                        default:
                            break;
                    }
                }
                Customer customer = new Customer
                {
                    FirstName = "ANONYMOUS",
                    LastName = "ANONYMOUS",
                    EmailAddress = "ANONYMOUS",
                    PhysicalAddress = "ANONYMOUS"
                };

                _context.Add(customer);
                await _context.SaveChangesAsync();


                Quote anonQuote = new Quote
                {
                    CustomerId = _context.Customers.Where(a => a.FirstName == "ANONYMOUS").OrderByDescending(b => b.CustomerId).FirstOrDefault().CustomerId,
                    Quote1 = finalPrice
                };
                _context.Add(anonQuote);
                await _context.SaveChangesAsync();

                Response.Cookies.Append("finalPrice", finalPrice.ToString());
                return RedirectToAction("Edit");


            }
            //ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", quote.CustomerId);
            return RedirectToAction("Index", "Home");
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
        public async Task<IActionResult> Edit()
        {
            string finalPrice = "";
            if (Request.Cookies["finalPrice"] != null)
            {
                finalPrice = Request.Cookies["finalPrice"];
            }
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var quote = await _context.Quotes.FindAsync(id);
            //if (quote == null)
            //{
            //    return NotFound();
            //}
            //ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", quote.CustomerId);
            //return View(quote);
            ViewData["finalPrice"] = finalPrice;
            return View();
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
