﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data.Interfaces;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.Repository
{
    public class ProductAttributeRepository : Repository<ProductAttribute>, IProductAttributeRepository
    {
        public ProductAttributeRepository(AppDBContext appDBContext) : base(appDBContext)
        {
        }

        public new async Task<IReadOnlyList<ProductAttribute>> GetAllAsync()
        {
            return await base.GetAllAsync();
        }

        public new async Task<ProductAttribute> GetByIdAsync(int productId)
        {
            var products = await GetAllAsync();
            return products.FirstOrDefault(u => u.Id == productId);
        }

        public new async Task AddAsync(ProductAttribute productAttribute)
        {
            await base.AddAsync(productAttribute);
        }

        public async Task DeleteListAsync(List<ProductAttribute> productAttributes)
        {
            foreach(ProductAttribute productAttribute in productAttributes)
            {
                await DeleteAsync(productAttribute);
            }
        }
    }
}