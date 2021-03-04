﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Data.Models
{
    public class ShopCart
    {
        private readonly AppDBContext appDBContent;
        public ShopCart(AppDBContext appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public string ShopCartId { get; set; }
        public List<ShopCartItem> ListShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContext>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", shopCartId);

            return new ShopCart(context) { ShopCartId = shopCartId };
        }

        public Dictionary<Order, List<OrderDetail>> GetAllOrders()
        {
            Dictionary<Order, List<OrderDetail>> allOrders = new Dictionary<Order, List<OrderDetail>>();
            foreach (Order order in appDBContent.Order)
            {
                allOrders.Add(order, null);
                List<OrderDetail> orders = new List<OrderDetail>();
                orders = appDBContent.OrderDetail.Include(p => p.Product).Where(p => p.OrderID == order.Id).ToList();
                allOrders[order] = orders;
            }
            return allOrders;
        }

        public void AddToCart(Product product)
        {
            appDBContent.ShopCartItem.Add(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                Product = product,
                Price = product.Price,
                Category = product.Category
            });
            appDBContent.SaveChanges();
        }

        public void RemoveToCart(string id)
        {
            ShopCartItem order = appDBContent.ShopCartItem.Where(o => o.ShopCartId == id).FirstOrDefault();
            appDBContent.ShopCartItem.Remove(order);
            appDBContent.SaveChanges();
        }

        public void EmptyTheCart(List<ShopCartItem> items)
        {
            foreach (ShopCartItem item in items)
            {
                appDBContent.ShopCartItem.Remove(item);
            }
            appDBContent.SaveChanges();
        }

        public List<ShopCartItem> GetShopItems()
        {
            return appDBContent.ShopCartItem.Where(c => c.ShopCartId == ShopCartId).Include(s => s.Product).ToList();
        }
    }
}
