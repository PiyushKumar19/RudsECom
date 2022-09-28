using System.ComponentModel.DataAnnotations;

namespace RudsECom.Models
{
    public class ProdSellLinkModel
    {
        [Key]
        public int Id { get; set; }
        public SellersModel? Seller { get; set; }
        public int? SellerId { get; set; }
        public ProductsModel? Product { get; set; }
        public int? ProductId { get; set; }
    }
}
