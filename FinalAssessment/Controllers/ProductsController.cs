using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalAssessment.Models;
using Microsoft.AspNetCore.Authorization;
using Google.Apis.Admin.Directory.directory_v1.Data;

namespace FinalAssessment.Controllers
{
    // Stops users who aren't logged in from accessing controller
    [Authorize]
    // name of class 'ProductsController'
    public class ProductsController : Controller
    {
        private readonly aspnetFinalAssessment813E699D00FA4DB99FF0576FE69C3222Context _context;

        public ProductsController(aspnetFinalAssessment813E699D00FA4DB99FF0576FE69C3222Context context)
        {
            _context = context;
        }

        // GET: Products index view
        public async Task<IActionResult> Index(string sortOrder, string productCategory, string searchString)
        {
            // Declares ViewBags for current sorting order, name sort order and price sort order.
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";


            // LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Products
                                            orderby m.Category
                                            select m.Category;


            var products = from m in _context.Products
                         select m;

            // If searchString isn't empty then return products containing searchString
            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.ProductName.Contains(searchString));
            }

            // If productCategory isn't empty then display products of that category
            if (!string.IsNullOrEmpty(productCategory))
            {
                products = products.Where(x => x.Category == productCategory);
            }

            // If searchString isn't empty then return products containing searchString
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.ProductName.Contains(searchString)
                    || p.ProductName.Contains(searchString));
            }

            // switches between sort orders
            switch (sortOrder)
            {
                // orders product name descending
                case "name_desc":
                    products = products.OrderByDescending(p => p.ProductName);
                    break;
                // orders product price ascending
                case "Price":
                    products = products.OrderBy(p => p.Price);
                    break;
                // orders product price descending
                case "price_desc":
                    products = products.OrderByDescending(p => p.Price);
                    break;
                // orders product name ascending
                default:
                    products = products.OrderBy(p => p.ProductName);
                    break;
            }

            // declares a new ProductCategoryModel named productCategoryVM
            var productCategoryVM = new ProductCategoryViewModel
            {
                // creates a new select list for the categories
                Catgories = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Products = await products.ToListAsync()
            };
            // returns the productCategoryVM view
            return View(productCategoryVM);
        }


        // GET: Products/Details/ view
        public async Task<IActionResult> Details(string id)
        {
            // if ID is null return not found
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .FirstOrDefaultAsync(m => m.Pid == id);
            // if ID is null return not found
            if (products == null)
            {
                return NotFound();
            }
            // returns porducts view
            return View(products);
        }

        // GET: Products/Create view
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // Sends the create product request
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Pid,ProductName,Description,Price,Rating,Category")] Products products)
        {
            // if model is valid then send newly created product to database
            if (ModelState.IsValid)
            {
                _context.Add(products);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            // returns products view
            return View(products);
        }

        // GET: Products/Edit/5 view
        public async Task<IActionResult> Edit(string id)
        {
            // if ID is null return not found
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products.FindAsync(id);
            // if ID is null return not found
            if (products == null)
            {
                return NotFound();
            }
            // returns product view
            return View(products);
        }

        // POST: Products/Edit/5
        // Sends edit request to update  the selected product
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Pid,ProductName,Description,Price,Rating,Category")] Products products)
        {
            // if ID is null return not found
            if (id != products.Pid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(products);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    // if ID is null return not found
                    if (!ProductsExists(products.Pid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                // returns to index
                return RedirectToAction(nameof(Index));
            }
            // returns products view
            return View(products);
        }

        // GET: Products/Delete/5 view
        public async Task<IActionResult> Delete(string id)
        {
            // if ID is null return not found
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .FirstOrDefaultAsync(m => m.Pid == id);
            // if ID is null return not found
            if (products == null)
            {
                return NotFound();
            }
            // returns products view
            return View(products);
        }

        // POST: Products/Delete/5
        // sends delete request for selected product
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            // deletes selected item and returns to index view
            var products = await _context.Products.FindAsync(id);
            _context.Products.Remove(products);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // bool value to check whether product exists
        private bool ProductsExists(string id)
        {
            return _context.Products.Any(e => e.Pid == id);
        }
    }
}
