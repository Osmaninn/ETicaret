﻿using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETicaretAPI.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }

        public int Stock { get; set; }

        public float Price{ get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
