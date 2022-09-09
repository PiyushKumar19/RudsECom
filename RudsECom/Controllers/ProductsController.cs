using Microsoft.AspNetCore.Mvc;
using RudsECom.InterfacesAndSqlRepo;
using RudsECom.Models;
using RudsECom.ViewModel;

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
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Products model)
        {
            if(ModelState.IsValid)
            {
                Products products = new Products()
                {
                    ProdName = model.ProdName,
                    ProdPrice = model.ProdPrice,
                    Description = model.Description,
                    Origin = model.Origin,
                    City = model.City
                };
                cRUD.Add(products);
                return RedirectToAction("AllProducts", new { ProductId = products.ProductId });
            }
            return View();
        }
        [HttpGet]
        public ViewResult Edit(int Id)
        {
            Products res = cRUD.GetProduct(Id);
            ProductViewModel products = new ProductViewModel()
            {
                ProductId = res.ProductId,
                ProdName = res.ProdName,
                ProdPrice = res.ProdPrice,
                Description = res.Description,
                Origin = res.Origin,
                City = res.City
            };
            return View(products);
        }
        [HttpPost]
        public IActionResult Edit(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                Products products = cRUD.GetProduct(model.ProductId);
                products.ProdName = model.ProdName;
                products.ProdPrice = model.ProdPrice;
                products.Description = model.Description;
                products.Origin = model.Origin;
                products.City = model.City;
                Products upProduct =  cRUD.updateProduct(products);
                return RedirectToAction("AllProducts");
            };
            return View();
        }
        public IActionResult Delete(int Id)
        {
            cRUD.delete(Id);
            return RedirectToAction("AllProducts");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
