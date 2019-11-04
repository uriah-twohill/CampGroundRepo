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
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly aspnetFinalAssessment813E699D00FA4DB99FF0576FE69C3222Context _context;

        public OrdersController(aspnetFinalAssessment813E699D00FA4DB99FF0576FE69C3222Context context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var aspnetFinalAssessment813E699D00FA4DB99FF0576FE69C3222Context = _context.Order.Include(o => o.C).Include(o => o.P);
            return View(await aspnetFinalAssessment813E699D00FA4DB99FF0576FE69C3222Context.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.C)
                .Include(o => o.P)
                .FirstOrDefaultAsync(m => m.Oid == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["Cid"] = new SelectList(_context.Customers, "Cid", "Cid");
            ViewData["Pid"] = new SelectList(_context.Products, "Pid", "Pid");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Oid,Cid,Pid,PurchaseDate,PaymentDate")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Cid"] = new SelectList(_context.Customers, "Cid", "Cid", order.Cid);
            ViewData["Pid"] = new SelectList(_context.Products, "Pid", "Pid", order.Pid);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["Cid"] = new SelectList(_context.Customers, "Cid", "Cid", order.Cid);
            ViewData["Pid"] = new SelectList(_context.Products, "Pid", "Pid", order.Pid);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Oid,Cid,Pid,PurchaseDate,PaymentDate")] Order order)
        {
            if (id != order.Oid)
            {
                return NotFound();
            }

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
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.C)
                .Include(o => o.P)
                .FirstOrDefaultAsync(m => m.Oid == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Order.FindAsync(id);
            _context.Order.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.Oid == id);
        }
    }
}
