using SmartAgri.Entities.Concrete;

namespace SmartAgri.WebUI.DTOs
{
    public class AdvertDto
    {
        public AdvertDto()
        {
            
        }
        public AdvertDto(Advert advert)
        {
            Id = advert.Id;
            ProductId = advert.ProductId;
            UnitPrice = advert.UnitPrice;
            Quantity = advert.Quantity;
            UserId = advert.UserId;
            StatusId = advert.StatusId;
            CreatedAt = advert.CreatedAt;
        }
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }
        public int StatusId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
