using RudsECom.Models;

namespace RudsECom.InterfacesAndSqlRepo
{
    public interface IProductsCRUD
    {
        public Products GetProduct(int Id);
        IEnumerable<Products> GetProducts();
        Products Add(Products product);
        Products delete(int Id);
        Products updateProduct(Products upproduct);
    }
}
