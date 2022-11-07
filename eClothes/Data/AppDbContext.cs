﻿using eClothes.Models;
using Microsoft.EntityFrameworkCore;

namespace eClothes.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public AppDbContext() :base()
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clothes_Discounts>().HasKey(cd => new
            {
                cd.DiscountId,
                cd.ClothId
            });

            modelBuilder.Entity<Clothes_Discounts>().HasOne(d => d.Discounts).WithMany(dc => dc.Clothes_Discounts).HasForeignKey(d => d.ClothId);
            modelBuilder.Entity<Clothes_Discounts>().HasOne(d => d.Clothes).WithMany(dc => dc.Clothes_Discounts).HasForeignKey(d => d.DiscountId);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Clothes> Clothes { get; set; }
        public DbSet<Discounts> Discounts { get; set; }
        public DbSet<Clothes_Discounts> Clothes_Discounts { get; set; }
    }
}