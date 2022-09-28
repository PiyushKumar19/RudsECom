using RudsECom.Models;

namespace RudsECom.ViewModel
{
    public class SellerViewModel
    {
        public int Id { get; set; }
        public string SellerName { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public List<SellersModel> Sellers { get; set; }
    }
}
