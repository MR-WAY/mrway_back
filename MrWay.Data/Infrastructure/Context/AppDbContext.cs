using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MrWay.Domain.DomainModels.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MrWay.Data.Configurations;
using MrWay.Domain.DomainModels.Retail;
using MrWay.Domain.DomainModels.Order;

namespace MrWay.Data.Infrastructure.Context
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Store> Stores { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new StoreConfiguration());
            builder.ApplyConfiguration(new ProductConfiguraion());
        }
    }
}