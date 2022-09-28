using RudsECom.Migrations;
using RudsECom.ViewModel;

namespace RudsECom.InterfacesAndSqlRepo
{
    public interface IProdSellLinkCRUD
    {
        Task<int> LinkProdSell(ProductViewModel model, int? prodId);
    }
}
