using SmartAgri.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgri.Entities.Concrete
{
    public class Role : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public virtual ICollection<User> Users { get; set; } = null!;
    }
}
