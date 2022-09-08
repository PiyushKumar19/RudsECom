using RudsECom.AppDbContext;
using RudsECom.Models;

namespace RudsECom.InterfacesAndSqlRepo
{
    public class SqlProductRepo : IProductsCRUD
    {
        private readonly DatabaseContext context;

        public SqlProductRepo(DatabaseContext _context)
        {
            this.context = _context;
        }
        public Products Add(Products product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return product;
        }

        public Products delete(int Id)
        {
            Products res = context.Products.Find(Id);
            if(res != null)
            {
                context.Products.Remove(res);
                context.SaveChanges();
            }
            return res;
        }

        public Products GetProduct(int Id)
        {
            return context.Products.Find(Id);
        }

        public IEnumerable<Products> GetProducts()
        {
            return context.Products;
        }

        public Products updateProduct(Products upproduct)
        {
            var newProduct = context.Products.Attach(upproduct);
            newProduct.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return upproduct;
        }
    }
}
