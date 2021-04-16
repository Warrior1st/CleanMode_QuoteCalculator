using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CleanMode_QuoteCalculator.Models;
using Microsoft.AspNetCore.Identity;
using System.Text;

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

                //IdentityRole role = new IdentityRole { Name = "CUSTOMER" };
                //await roleManager.CreateAsync(role);
                //*********************************************************************************

                //Add admin as a customer

                //var user = await userManager.FindByEmailAsync("sebujo@gmail.com");
                //await userManager.AddToRoleAsync(user, "ADMINISTRATOR");
                //Customer admin = new Customer
                //{
                //    FirstName = "Administrator",
                //    LastName = "Administrator",
                //    EmailAddress = user.Email,
                //    PhysicalAddress = "12 ABCD St"

                //};
                //_context.Add(admin);
                //await _context.SaveChangesAsync();


                bool valid = true;
                bool validRoom = true;
                for (int i = 0; i < area.Count; i++)
                {
                    if (!float.TryParse(area[i], out float result) || result <= 0)
                    {
                        valid = false;
                        break;
                    }
                    else
                    {
                        valid = true;
                    }
                }
                for (int i = 0; i < UnitType.Count; i++)
                {
                    if (UnitType[i] == "DefaultMessage")
                    {
                        validRoom = false;
                        break;
                    }
                    else
                    {
                        validRoom = true;
                    }
                }
                if (!valid)
                {
                    TempData["message"] = "The area must be a number greater than 0.";
                    return RedirectToAction("Index", "Home");
                }
                else if (!validRoom)
                {
                    TempData["message"] = "The room type must be selected.";
                    return RedirectToAction("Index", "Home");
                }
                else if (valid && validRoom)
                {




                    int basementCounter = 0;
                    string basementString = "";
                    float finalBasement = 0f;

                    int bedroomCounter = 0;
                    string bedroomString = "";
                    float finalBedroom = 0f;

                    int bathroomCounter = 0;
                    string bathroomString = "";
                    float finalBathroom = 0f;

                    int garageCounter = 0;
                    string garageString = "";
                    float finalGarage = 0f;

                    int entranceCounter = 0;
                    string entranceString = "";
                    float finalEntrance = 0f;

                    int kitchenCounter = 0;
                    string kitchenString = "";
                    float finalKitchen = 0f;

                    int stairsCounter = 0;
                    string stairsString = "";
                    float finalStairs = 0f;

                    int diningRoomCounter = 0;
                    string diningRoomString = "";
                    float finalDining = 0f;

                    int livingRoomCounter = 0;
                    string livingRoomString = "";
                    float finalLiving = 0f;


                    StringBuilder builder = new StringBuilder();

                    float finalPrice = 0;

                    for (int i = 0; i < UnitType.Count; i++)
                    {
                        switch (UnitType[i])
                        {
                            case "basement":
                                var basement = _context.Basements.Where(a => a.RoomTypeId == 8).FirstOrDefault();
                                var price = basement.PricePerSqft * float.Parse(area[i]);

                                finalBasement += (float)price;



                                basementCounter++;
                                basementString = $"{basementCounter} basement(s) for {Math.Round((float)finalBasement, 2)}, ";


                                finalPrice += (float)Math.Round((float)price, 2);
                                break;
                            case "bathroom":
                                var bathroom = _context.Bathrooms.Where(a => a.RoomTypeId == 2).FirstOrDefault();
                                var price2 = bathroom.PricePerSqft * float.Parse(area[i]);

                                finalBathroom += (float)price2;



                                bathroomCounter++;
                                bathroomString = $"{bathroomCounter} bathroom(s) for {Math.Round((float)finalBathroom, 2)}, ";


                                finalPrice += (float)Math.Round((float)price2, 2);
                                break;
                            case "garage":
                                var garage = _context.Garages.Where(a => a.RoomTypeId == 5).FirstOrDefault();
                                var price3 = garage.PricePerSqft * float.Parse(area[i]);

                                finalGarage += (float)price3;



                                garageCounter++;
                                garageString = $"{garageCounter} garage(s) for {Math.Round((float)finalGarage, 2)}, ";


                                finalPrice += (float)Math.Round((float)price3, 2);
                                break;
                            case "livingroom":
                                var livingroom = _context.Livingrooms.Where(a => a.RoomTypeId == 4).FirstOrDefault();
                                var price4 = livingroom.PricePerSqft * float.Parse(area[i]);

                                finalLiving += (float)price4;



                                livingRoomCounter++;
                                livingRoomString = $"{livingRoomCounter} living(s) for {Math.Round((float)finalLiving, 2)}, ";


                                finalPrice += (float)Math.Round((float)price4, 2);
                                break;
                            case "diningroom":
                                var diningroom = _context.Diningrooms.Where(a => a.RoomTypeId == 3).FirstOrDefault();
                                var price5 = diningroom.PricePerSqft * float.Parse(area[i]);

                                finalDining += (float)price5;



                                diningRoomCounter++;
                                diningRoomString = $"{diningRoomCounter} diningroom(s) for {Math.Round((float)finalDining, 2)}, ";


                                finalPrice += (float)Math.Round((float)price5, 2);
                                break;
                            case "stairs":
                                var stairs = _context.Stairs.Where(a => a.RoomTypeId == 9).FirstOrDefault();
                                var price6 = stairs.PricePerSqft * float.Parse(area[i]);

                                finalStairs += (float)price6;



                                stairsCounter++;
                                stairsString = $"{stairsCounter} stairs for {Math.Round((float)finalStairs, 2)}, ";


                                finalPrice += (float)Math.Round((float)price6, 2);
                                break;
                            case "kitchen":
                                var kitchen = _context.Kitchens.Where(a => a.RoomTypeId == 7).FirstOrDefault();
                                var price7 = kitchen.PricePerSqft * float.Parse(area[i]);

                                finalKitchen += (float)price7;



                                kitchenCounter++;
                                kitchenString = $"{kitchenCounter} kitchen(s) for {Math.Round((float)finalKitchen, 2)}, ";


                                finalPrice += (float)Math.Round((float)price7, 2);
                                break;
                            case "bedroom":
                                var bedroom = _context.Bedrooms.Where(a => a.RoomTypeId == 1).FirstOrDefault();
                                var price8 = bedroom.PricePerSqft * float.Parse(area[i]);

                                finalBedroom += (float)price8;



                                bedroomCounter++;
                                bedroomString = $"{bedroomCounter} basement(s) for {Math.Round((float)finalBedroom, 2)}, ";


                                finalPrice += (float)Math.Round((float)price8, 2);
                                break;
                            case "entrance":
                                var entrance = _context.Entrances.Where(a => a.RoomTypeId == 6).FirstOrDefault();
                                var price9 = entrance.PricePerSqft * float.Parse(area[i]);

                                finalEntrance += (float)price9;



                                entranceCounter++;
                                entranceString = $"{entranceCounter} basement(s) for {Math.Round((float)finalEntrance, 2)}, ";


                                finalPrice += (float)Math.Round((float)price9, 2);
                                break;
                            default:
                                break;
                        }
                    }
                    //Checking if there is a user connected save quote associated with that particular user
                    if (Request.Cookies["email"] != null)
                    {
                        builder.Append($"{basementString} {bathroomString} {garageString} {livingRoomString} {diningRoomString} {stairsString} {kitchenString} {bedroomString} {entranceString}");
                        if (_context.Customers.Where(a => a.EmailAddress == Request.Cookies["email"]).FirstOrDefault() == null)
                        {
                            var userLogged = await userManager.FindByEmailAsync(Request.Cookies["email"]);
                            Customer newReturningCust = new Customer
                            {
                                FirstName = userLogged.UserName,
                                LastName = userLogged.UserName,
                                EmailAddress = userLogged.Email,
                                PhysicalAddress = "Not typed in"
                            };
                            _context.Add(newReturningCust);
                            await _context.SaveChangesAsync();

                        }
                        var recurringCust = _context.Customers.Where(a => a.EmailAddress == Request.Cookies["email"]).FirstOrDefault();


                        Quote existingQuote = new Quote
                        {
                            CustomerId = recurringCust.CustomerId,
                            Quote1 = finalPrice,
                            Quote_Summary = builder.ToString()
                        };

                        _context.Add(existingQuote);
                        await _context.SaveChangesAsync();

                    }
                    else
                    {
                        builder.Append($"{basementString} {bathroomString} {garageString} {livingRoomString} {diningRoomString} {stairsString} {kitchenString} {bedroomString} {entranceString}");

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
                            Quote1 = finalPrice,
                            Quote_Summary = builder.ToString()
                        };
                        _context.Add(anonQuote);
                        await _context.SaveChangesAsync();
                    }
                    Response.Cookies.Append("summary", builder.ToString());

                    Response.Cookies.Append("finalPrice", finalPrice.ToString());
                    return RedirectToAction("Edit");
                }
                //return RedirectToAction("Index", "Home");
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
            bool loggedIn = false;
            if (Request.Cookies["email"] != null)
            {
                loggedIn = true;
            }
            else
            {
                loggedIn = false;
            }

            string finalPrice = "";

            string summary = "";
            if (Request.Cookies["finalPrice"] != null)
            {
                finalPrice = Request.Cookies["finalPrice"];
            }
            if (Request.Cookies["summary"] != null)
            {
                summary = Request.Cookies["summary"];
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

            ViewData["login"] = loggedIn;
            ViewData["summary"] = summary;
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
