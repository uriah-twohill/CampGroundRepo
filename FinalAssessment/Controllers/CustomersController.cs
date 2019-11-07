using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalAssessment.Models;
using Microsoft.AspNetCore.Authorization;

namespace FinalAssessment.Controllers
{
    // Stops user accessing Customers controller without being logged in.
    [Authorize]
    // Declaration of class 'Customers Controller'
    public class CustomersController : Controller
    {
        private readonly aspnetFinalAssessment813E699D00FA4DB99FF0576FE69C3222Context _context;

        public CustomersController(aspnetFinalAssessment813E699D00FA4DB99FF0576FE69C3222Context context)
        {
            _context = context;
        }

        // GET: Customers view
        public async Task<IActionResult> Index()
        {
            return View(await _context.Customers.ToListAsync());
        }

        // GET: Customers/Details/5 view
        public async Task<IActionResult> Details(int? id)
        {
            // if customer id is null return not found
            if (id == null)
            {
                return NotFound();
            }

            // sets 'cusotmers as the context .Customers
            var customers = await _context.Customers
                .FirstOrDefaultAsync(m => m.Cid == id);
            // if customer id is null return not found
            if (customers == null)
            {
                return NotFound();
            }

            // returns cusotmers view
            return View(customers);
        }

        // Returns Customers/Create view
        public IActionResult Create()
        {
            return View();
        }

        // Creates new customer and returns to customers view
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cid,Name,Age,Phone")] Customers customers)
        {
            // if ModelState is valid then return view
            if (ModelState.IsValid)
            {
                _context.Add(customers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customers);
        }


        // GET: Customers/Edit/5 view
        public async Task<IActionResult> Edit(int? id)
        {
            // if ID or customers is null then return not found
            if (id == null)
            {
                return NotFound();
            }

            // sets customers context to that of the returned ID
            var customers = await _context.Customers.FindAsync(id);
            // if ID is null then return not found
            if (customers == null)
            {
                return NotFound();
            }
            // returns customers view
            return View(customers);
        }

        // POST: Customers/Edit/5
        // Sends edited customer to table
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cid,Name,Age,Phone")] Customers customers)
        {
            // if ID is null then return not found
            if (id != customers.Cid)
            {
                return NotFound();
            }

            // if modelView is valid then proceed with try/ catch block
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomersExists(customers.Cid))
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
            // return the customers view
            return View(customers);
        }


        // GET: Customers/Delete/5 view
        public async Task<IActionResult> Delete(int? id)
        {
            // if ID is null then return not found
            if (id == null)
            {
                return NotFound();
            }

            // sets 'cusotmers as the context .Customers
            var customers = await _context.Customers
                .FirstOrDefaultAsync(m => m.Cid == id);
            // if ID is null then return not found
            if (customers == null)
            {
                return NotFound();
            }

            // returns customers View
            return View(customers);
        }

        // POST: Customers/Delete/5 
        // sends delete request
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // removes customer if they exist
            var customers = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // bool value to check if customer exists
        private bool CustomersExists(int id)
        {
            return _context.Customers.Any(e => e.Cid == id);
        }
    }
}
