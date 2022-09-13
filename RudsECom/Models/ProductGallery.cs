namespace RudsECom.Models
{
    public class ProductGallery
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public string? Name { get; set; }
        public string? URL { get; set; }
        public ProductsModel? Product { get; set; }
    }
}
