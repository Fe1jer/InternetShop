﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternetShop.Data.Interfaces;
using InternetShop.Data.Models;
using InternetShop.Data.Specifications.Base;
using InternetShop.Data.Repository.Base;

namespace InternetShop.Data.Repository
{
    public class SiteRatingRepository : Repository<SiteRating>, ISiteRatingRepository
    {
        public SiteRatingRepository(AppDBContext appDBContext) : base(appDBContext) { }

        public async Task<double> OverallSiteRating()
        {
            var ratings = await base.GetAllAsync();
            return ratings.Count != 0 ? ratings.Average(r => r.Rating) : 0;
        }
        public new async Task<IReadOnlyList<SiteRating>> GetAllAsync()
        {
            return await base.GetAllAsync();
        }

        public new async Task<IReadOnlyList<SiteRating>> GetAllAsync(ISpecification<SiteRating> specification)
        {
            return await base.GetAllAsync(specification);
        }

        public new async Task<SiteRating> GetByIdAsync(int id)
        {
            return await base.GetByIdAsync(id);
        }

        public async Task DeleteAsync(int id)
        {
            SiteRating siteRating = await base.GetByIdAsync(id);
            await DeleteAsync(siteRating);
        }

        public new async Task AddAsync(SiteRating siteRating)
        {
            await base.AddAsync(siteRating);
        }

        public new async Task UpdateAsync(SiteRating siteRating)
        {
            await base.UpdateAsync(siteRating);
        }
    }
}
