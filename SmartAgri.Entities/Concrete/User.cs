﻿using SmartAgri.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgri.Entities.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int RoleId { get; set; }
        public Guid CoinAccountId { get; set; }
        public string CoinAddress { get; set; } = null!;
        public string? ExternalCoinAddress { get; set; }
        public decimal LockedBalance { get; set; }
        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<Reply> Replies { get; set; } = new List<Reply>();
        public virtual ICollection<Topic> Topics { get; set; } = new List<Topic>();
        public virtual ICollection<Advert> Adverts { get; set; } = new List<Advert>();
    }
}
