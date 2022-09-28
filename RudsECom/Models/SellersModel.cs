using System.ComponentModel.DataAnnotations;

namespace RudsECom.Models
{
    public class SellersModel
    {
        [Key]
        public int SellerId { get; set; }
        public string SellerName { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public ProductsModel? Products { get; set; }
    }
}
