using Microsoft.EntityFrameworkCore;
using RudsECom.AppDbContext;
using RudsECom.ViewModel;
using RudsECom.Models;

namespace RudsECom.InterfacesAndSqlRepo
{
    public class SqlProdSellLinkRepo : IProdSellLinkCRUD
    {
        private readonly DatabaseContext context;

        public SqlProdSellLinkRepo(DatabaseContext _context)
        {
            context = _context;
        }

        public async Task<int> LinkProdSell(ProductViewModel model, int? prodId)
        {
            var prodLink = new ProdSellLinkModel()
            {
                SellerId = model.SellerId,
                ProductId = prodId
            };
            await context.AddAsync(prodLink);
            await context.SaveChangesAsync();
            return prodLink.Id;
        }
    }
}
