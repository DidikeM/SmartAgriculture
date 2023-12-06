using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgri.Entities.Concrete
{
    public class AdvertSell : Advert
    {
        public Transaction? Transaction { get; set; } = null!;
    }
}
