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
    // Declaration of class 'Orders Controller'
    public class OrdersController : Controller
    {
        private readonly aspnetFinalAssessment813E699D00FA4DB99FF0576FE69C3222Context _context;

        public OrdersController(aspnetFinalAssessment813E699D00FA4DB99FF0576FE69C3222Context context)
        {
            _context = context;
        }

        // GET: Orders view 
        public async Task<IActionResult> Index()
        {
            var aspnetFinalAssessment813E699D00FA4DB99FF0576FE69C3222Context = _context.Order.Include(o => o.C).Include(o => o.P);
            return View(await aspnetFinalAssessment813E699D00FA4DB99FF0576FE69C3222Context.ToListAsync());
        }

        // GET: Orders/Details/5 view
        public async Task<IActionResult> Details(int? id)
        {
            // if order id is null return not found
            if (id == null)
            {
                return NotFound();
            }

            // includes the foreign keys for customer and product id in the order
            var order = await _context.Order
                .Include(o => o.C)
                .Include(o => o.P)
                .FirstOrDefaultAsync(m => m.Oid == id);
            // if order id is null return not found
            if (order == null)
            {
                return NotFound();
            }

            // returns the order view
            return View(order);
        }

        // GET: Orders/Create view
        public IActionResult Create()
        {
            // Creates a list to allow user to select form existing Customer and Product IDs when creatin new order
            ViewData["Cid"] = new SelectList(_context.Customers, "Cid", "Cid");
            ViewData["Pid"] = new SelectList(_context.Products, "Pid", "Pid");
            return View();
        }

        // POST: Orders/Create 
        // Sends newly created order to database to be displayed on order index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Oid,Cid,Pid,PurchaseDate,PaymentDate")] Order order)
        {
            // if model state is valid then save changes to the table
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Cid"] = new SelectList(_context.Customers, "Cid", "Cid", order.Cid);
            ViewData["Pid"] = new SelectList(_context.Products, "Pid", "Pid", order.Pid);
            // returns the order view
            return View(order);
        }

        // GET: Orders/Edit/5 view
        public async Task<IActionResult> Edit(int? id)
        {
            // if order id is null return not found
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FindAsync(id);
            // if order id is null return not found
            if (order == null)
            {
                return NotFound();
            }
            ViewData["Cid"] = new SelectList(_context.Customers, "Cid", "Cid", order.Cid);
            ViewData["Pid"] = new SelectList(_context.Products, "Pid", "Pid", order.Pid);
            // returns the order view
            return View(order);
        }

        // POST: Orders/Edit/5
        // Sends newly edited order to database to be displayed on order index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Oid,Cid,Pid,PurchaseDate,PaymentDate")] Order order)
        {
            // if order id is null return not found
            if (id != order.Oid)
            {
                return NotFound();
            }

            // if modelstate is valid then save changes and update order
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Oid))
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
            ViewData["Cid"] = new SelectList(_context.Customers, "Cid", "Cid", order.Cid);
            ViewData["Pid"] = new SelectList(_context.Products, "Pid", "Pid", order.Pid);
            // return the orders view
            return View(order);
        }

        // GET: Orders/Delete/5 view
        public async Task<IActionResult> Delete(int? id)
        {
            // if order id is null return not found
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.C)
                .Include(o => o.P)
                .FirstOrDefaultAsync(m => m.Oid == id);
            // if order id is null return not found
            if (order == null)
            {
                return NotFound();
            }
            // return orders view
            return View(order);
        }

        // POST: Orders/Delete/5 
        // send delete request
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // delete order and return index
            var order = await _context.Order.FindAsync(id);
            _context.Order.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        // value to determine whether order exists
        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.Oid == id);
        }
    }
}
