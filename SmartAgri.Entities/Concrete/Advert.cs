using SmartAgri.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgri.Entities.Concrete
{
    public abstract class Advert : IEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }
        public int StatusId { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual Product Product { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual AdvertStatus Status { get; set; } = null!;

    }
}
