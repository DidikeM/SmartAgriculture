using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgri.Entities.Concrete
{
    public class AdvertBuy : Advert
    {
        public ICollection<Transaction> Transactions { get; set; } = null!;
    }
}
