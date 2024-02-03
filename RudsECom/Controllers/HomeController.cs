using Microsoft.AspNetCore.Mvc;
using RudsECom.InterfacesAndSqlRepo;
using RudsECom.Models;
using System.Diagnostics;
using System.Net.Http.Headers;

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

        [HttpGet]
        public IActionResult TestForm()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TestForm(Temp model)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    // Set the base address of the Node.js server
                    httpClient.BaseAddress = new Uri("https://localhost:7110"); // Replace with your Node.js server URL

                    // Prepare the form data
                    var formData = new MultipartFormDataContent();
                    formData.Add(new StringContent(model.Name), "name");

                    if (model.File != null && model.File.Length > 0)
                    {
                        var fileStream = model.File.OpenReadStream();
                        var fileContent = new StreamContent(fileStream);
                        fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                        {
                            Name = "file",
                            FileName = model.File.FileName
                        };
                        formData.Add(fileContent);
                    }

                    // Send the POST request
                    var response = await httpClient.PostAsync("/api/Models/TestFormData", formData);

                    // Handle the response
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Response from Node.js server: {result}");
                        return Content($"Response from Node.js server: {result}");
                    }
                    else
                    {
                        return Content($"Error: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                return Content($"Error: {ex.Message}");
            }
        }
    }
}