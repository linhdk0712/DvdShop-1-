using System.Data.Entity;
using DvdShop.Models.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

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
        public DbSet<User> Users { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Ingredients> Ingredientses { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

       
    }
}