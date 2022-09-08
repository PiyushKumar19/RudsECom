using Microsoft.AspNetCore.Mvc;
using RudsECom.InterfacesAndSqlRepo;
using RudsECom.Models;

namespace RudsECom.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsCRUD cRUD;

        public ProductsController(IProductsCRUD _cRUD)
        {
            this.cRUD = _cRUD;
        }
        public IActionResult AllProducts()
        {
            var products = cRUD.GetProducts();
            return View(products);
        }
        public IActionResult Details(int Id)
        {
            Products prods = cRUD.GetProduct(Id);
            return View(prods);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
