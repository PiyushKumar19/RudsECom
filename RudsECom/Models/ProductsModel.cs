using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RudsECom.Models
{
    public class ProductsModel
    {
        [Key]
        public int ProductId { get; set; }
        public string ProdName { get; set; }
        public string ProdPrice { get; set; }
        public string Description { get; set; }
        public string Origin { get; set; }
        public string City { get; set; }
        public string PhotosUrl { get; set; }
    }
}
