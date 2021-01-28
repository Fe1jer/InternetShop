﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data.Models
{
    public class OrderDetail
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int CarID { get; set; }
        public uint Prise { get; set; }
        public virtual Car Car { get; set; }
        public virtual Order Order { get; set; }
    }
}