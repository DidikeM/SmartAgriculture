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
        public string Message { get; set; } = null!;
    }
}
