using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Quantifeed.Excercise.Authorization.Roles;
using Quantifeed.Excercise.Authorization.Users;
using Quantifeed.Excercise.MultiTenancy;
using Quantifeed.Excercise.Business.Orders;
using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Quantifeed.Excercise.Business.Baskets;

namespace Quantifeed.Excercise.EntityFrameworkCore
{
    public class ExcerciseDbContext : AbpZeroDbContext<Tenant, Role, User, ExcerciseDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Order> Orders { get; set; }

        public ExcerciseDbContext(DbContextOptions<ExcerciseDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Order>()
                .Property(e => e.Type)
                .HasConversion(new EnumToNumberConverter<OrderType, int>());
        }
    }
}
