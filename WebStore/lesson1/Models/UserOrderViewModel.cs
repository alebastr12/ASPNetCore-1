﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lesson1.Models
{
    public class UserOrderViewModel
    {
        public int Id { get; set; }
        public OrderViewModel Order  { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
