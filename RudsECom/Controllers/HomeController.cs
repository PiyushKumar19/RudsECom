using Microsoft.AspNetCore.Mvc;
using RudsECom.InterfacesAndSqlRepo;
using RudsECom.Models;
using System.Diagnostics;

namespace RudsECom.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsCRUD cRUD;

        public HomeController(IProductsCRUD _cRUD)
        {
            this.cRUD = _cRUD;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ViewResult> Details(int Id)
        {
            var prods = await cRUD.GetProductById(Id);
            return View(prods);
        }

        public IActionResult TestingView()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}