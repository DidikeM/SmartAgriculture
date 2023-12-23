using SmartAgri.Entities.Concrete;

namespace SmartAgri.WebUI.DTOs
{
    public class ProductDto
    {
        public ProductDto()
        {
            
        }
        public ProductDto(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            ImagePath = product.ImagePath;
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ImagePath { get; set; } = null!;
        public List<decimal> OldPrices { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal ExpectedPrice { get; set; }
    }
}
