﻿using SmartAgri.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgri.Entities.Concrete
{
    public class Reply : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TopicId { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; } = null!;
        public User User { get; set; } = null!;
        public Topic Topic { get; set; } = null!;
    }
}
