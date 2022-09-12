using RudsECom.Models;
using RudsECom.ViewModel;

namespace RudsECom.InterfacesAndSqlRepo
{
    public interface IProductsCRUD
    {
        public ProductsModel GetProduct(int Id);
        IEnumerable<ProductsModel> GetProducts();
        ProductsModel Add(ProductsModel product);
        ProductsModel delete(int Id);
        ProductsModel updateProduct(ProductsModel upproduct);

        Task<int> AddNewProduct(ProductViewModel product);
    }
}
