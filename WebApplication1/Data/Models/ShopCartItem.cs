﻿namespace WebApplication1.Data.Models
{
    public class ShopCartItem
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Price { get; set; }

        public Category Category { set; get; }
        public string ShopCartId { get; set; }
    }
}
