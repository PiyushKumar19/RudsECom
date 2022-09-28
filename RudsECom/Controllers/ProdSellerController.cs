using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RudsECom.AppDbContext;
using RudsECom.Models;
using RudsECom.ViewModel;

namespace RudsECom.Controllers
{
    public class ProdSellerController : Controller
    {
        private readonly DatabaseContext _context;

        public ProdSellerController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: ProdSeller
        public async Task<IActionResult> Index()
        {
              return View(await _context.Sellers.ToListAsync());
        }

        [HttpGet]
        public ViewResult ListSellers()
        {
            var model = new List<SellerViewModel>();

            foreach(var se in _context.Sellers.ToList())
            {
                var sellerModel = new SellerViewModel
                {
                    Id = se.SellerId,
                    SellerName = se.SellerName,
                    City = se.City,
                    Email = se.Email,
                    ContactNo = se.ContactNo
                };
                model.Add(sellerModel);
            }
            return View(model);
        }

        // GET: ProdSeller/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sellers == null)
            {
                return NotFound();
            }

            var sellersModel = await _context.Sellers
                .FirstOrDefaultAsync(m => m.SellerId == id);
            if (sellersModel == null)
            {
                return NotFound();
            }

            return View(sellersModel);
        }

        // GET: ProdSeller/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProdSeller/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SellerName,City,Email,ContactNo")] SellersModel sellersModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sellersModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sellersModel);
        }

        // GET: ProdSeller/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sellers == null)
            {
                return NotFound();
            }

            var sellersModel = await _context.Sellers.FindAsync(id);
            if (sellersModel == null)
            {
                return NotFound();
            }
            return View(sellersModel);
        }

        // POST: ProdSeller/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SellerName,City,Email,ContactNo,ProductId")] SellersModel sellersModel)
        {
            if (id != sellersModel.SellerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sellersModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SellersModelExists(sellersModel.SellerId))
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
            return View(sellersModel);
        }

        // GET: ProdSeller/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sellers == null)
            {
                return NotFound();
            }

            var sellersModel = await _context.Sellers
                .FirstOrDefaultAsync(m => m.SellerId == id);
            if (sellersModel == null)
            {
                return NotFound();
            }

            return View(sellersModel);
        }

        // POST: ProdSeller/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sellers == null)
            {
                return Problem("Entity set 'DatabaseContext.Sellers'  is null.");
            }
            var sellersModel = await _context.Sellers.FindAsync(id);
            if (sellersModel != null)
            {
                _context.Sellers.Remove(sellersModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SellersModelExists(int id)
        {
          return _context.Sellers.Any(e => e.SellerId == id);
        }
    }
}
