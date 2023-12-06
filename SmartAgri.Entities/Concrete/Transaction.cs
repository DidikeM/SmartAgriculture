using SmartAgri.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgri.Entities.Concrete
{
    public class Transaction : IEntity
    {
        public int Id { get; set; }
        public int BuyAdvertId { get; set; }
        public int SellAdvertId { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual AdvertBuy BuyAdvert { get; set; } = null!;
        public virtual AdvertSell SellAdvert { get; set; } = null!;
    }
}
