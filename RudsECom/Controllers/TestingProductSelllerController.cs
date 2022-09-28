using Microsoft.AspNetCore.Mvc;
using RudsECom.AppDbContext;
using RudsECom.Models;

namespace RudsECom.Controllers
{
    public class TestingProductSelllerController : Controller
    {
        private readonly DatabaseContext context;

        public TestingProductSelllerController(DatabaseContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SellersModel model)
        {
            var seller = new SellersModel()
            {
                SellerName = model.SellerName,
                City = model.City,
                Email = model.Email,
                ContactNo = model.ContactNo,
            };
            context.Sellers.Add(seller);
            context.SaveChanges();
            return RedirectToAction("AllProducts", "Products");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
