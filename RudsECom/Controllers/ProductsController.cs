using Microsoft.AspNetCore.Mvc;
using RudsECom.InterfacesAndSqlRepo;
using RudsECom.Models;
using RudsECom.ViewModel;

namespace RudsECom.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsCRUD cRUD;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductsController(IProductsCRUD _cRUD, IWebHostEnvironment _webHostEnvironment)
        {
            this.cRUD = _cRUD;
            this.webHostEnvironment = _webHostEnvironment;
        }
        public IActionResult AllProducts()
        {
            var products = cRUD.GetProducts();
            return View(products);
        }
        public async Task<ViewResult> Details(int Id)
        {
            var prods = await cRUD.GetProductById(Id);
            return View(prods);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductsModel model)
        {
            if(ModelState.IsValid)
            {
                ProductsModel products = new ProductsModel()
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
        public async Task<ViewResult> AddProduct(bool isSuccess = false, int prodId = 0)
        
        {
            var model = new ProductViewModel();
            ViewBag.IsSuccess = isSuccess;
            ViewBag.ProductId = prodId;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Photos != null)
                {
                    string folder = "ProductsImages/cover/";
                    model.PhotosUrl = await UploadImage(folder, model.Photos);
                }
                if (model.GalleryPhotos != null)
                {
                    string folder = "ProductsImages/gallery/";

                    model.Gallery = new List<GalleryModel>();
                    foreach (var file in model.GalleryPhotos)
                    {
                        var gallery = new GalleryModel()
                        {
                            Name = file.Name,
                            URL = await UploadImage(folder, file)
                        };
                        model.Gallery.Add(gallery);
                    }
                }
                int Id = await cRUD.AddNewProduct(model);
                if (Id > 0)
                {
                    return RedirectToAction(nameof(AddProduct), new { isSuccess = true, prodId = Id });
                }
            }
            return View();
        }
        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {
            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;
            string serverFolder = Path.Combine(webHostEnvironment.WebRootPath, folderPath);
            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            return "/" + folderPath;
        }
        [HttpGet]
        public ViewResult Edit(int Id)
        {
            ProductsModel res = cRUD.GetProduct(Id);
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
                ProductsModel products = cRUD.GetProduct(model.ProductId);
                products.ProdName = model.ProdName;
                products.ProdPrice = model.ProdPrice;
                products.Description = model.Description;
                products.Origin = model.Origin;
                products.City = model.City;
                ProductsModel upProduct =  cRUD.updateProduct(products);
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
