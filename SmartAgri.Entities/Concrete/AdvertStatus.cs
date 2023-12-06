using SmartAgri.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgri.Entities.Concrete
{
    public class AdvertStatus : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public virtual ICollection<Advert> Adverts { get; set; } = null!;
    }
}
