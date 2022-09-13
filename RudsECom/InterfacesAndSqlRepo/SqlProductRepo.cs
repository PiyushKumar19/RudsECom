using Microsoft.EntityFrameworkCore;
using RudsECom.AppDbContext;
using RudsECom.Models;
using RudsECom.ViewModel;

namespace RudsECom.InterfacesAndSqlRepo
{
    public class SqlProductRepo : IProductsCRUD
    {
        private readonly DatabaseContext context;

        public SqlProductRepo(DatabaseContext _context)
        {
            this.context = _context;
        }
        public ProductsModel Add(ProductsModel product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return product;
        }

        public async Task<int> AddNewProduct(ProductViewModel model)
        {
            var newProduct = new ProductsModel()
            {
                ProdName = model.ProdName,
                ProdPrice = model.ProdPrice,
                Description = model.Description,
                Origin = model.Origin,
                City = model.City,
                PhotosUrl = model.PhotosUrl
            };

            newProduct.ProductGallery = new List<ProductGallery>();

            foreach (var file in model.Gallery)
            {
                newProduct.ProductGallery.Add(new ProductGallery()
                {
                    Name = file.Name,
                    URL = file.URL
                });
            }
            await context.Products.AddAsync(newProduct);
            await context.SaveChangesAsync();

            return newProduct.ProductId;
        }

        public ProductsModel delete(int Id)
        {
            ProductsModel res = context.Products.Find(Id);
            if(res != null)
            {
                context.Products.Remove(res);
                context.SaveChanges();
            }
            return res;
        }

        public ProductsModel GetProduct(int Id)
        {
            return context.Products.Find(Id);
        }
        //public async Task<ProductViewModel> GetProductById(int Id)
        //{
        //    return await context.Products.Where(x => x.ProductId == Id)
        //         .Select(book => new ProductViewModel()
        //         {
        //             ProdName = book.ProdName,
        //             ProdPrice = book.ProdPrice,
        //             Description = book.Description,
        //             ProductId = book.ProductId,
        //             Origin = book.Origin,
        //             City = book.City,
        //             PhotosUrl = book.PhotosUrl,
        //             Gallery = book.ProductGallery.Select(g => new GalleryModel()
        //             {
        //                 Id = g.Id,
        //                 Name = g.Name,
        //                 URL = g.URL
        //             }).ToList()
        //         }).FirstOrDefaultAsync();
        //}

        public async Task<ProductViewModel> GetProductById(int id)
        {
            return await context.Products.Where(x => x.ProductId == id)
                 .Select(book => new ProductViewModel()
                 {
                     ProdName = book.ProdName,
                     ProdPrice = book.ProdPrice,
                     Description = book.Description,
                     ProductId = book.ProductId,
                     Origin = book.Origin,
                     City = book.City,
                     PhotosUrl = book.PhotosUrl,
                     Gallery = book.ProductGallery.Select(g => new GalleryModel()
                     {
                         Id = g.Id,
                         Name = g.Name,
                         URL = g.URL
                     }).ToList()
                 }).FirstOrDefaultAsync();
        }

        public IEnumerable<ProductsModel> GetProducts()
        {
            return context.Products;
        }

        public ProductsModel updateProduct(ProductsModel upproduct)
        {
            var newProduct = context.Products.Attach(upproduct);
            newProduct.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return upproduct;
        }
    }
}
