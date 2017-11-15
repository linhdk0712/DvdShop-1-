using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DvdShop.Models.Entities;

namespace DvdShop.Models
{
    public class DvdDbContext : DbContext
    {
        public DvdDbContext() : base("SocialGoalEntities")
        {
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Studio> Studios { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
       
    }
}