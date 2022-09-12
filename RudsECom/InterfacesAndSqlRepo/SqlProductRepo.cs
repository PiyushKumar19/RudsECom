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
