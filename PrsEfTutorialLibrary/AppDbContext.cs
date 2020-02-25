using Microsoft.EntityFrameworkCore;
using PrsEfTutorialLibrary.Migrations;
using PrsEfTutorialLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrsEfTutorialLibrary
    {
    public  class AppDbContext : DbContext
        {
        
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Orderline> Orderlines { get; set; }

        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
            {
            if (!builder.IsConfigured)
                {
                builder.UseLazyLoadingProxies();
                var connStr = @"server=localhost\sqlexpress;database=CustEfDb;trusted_connection=true;";
                builder.UseSqlServer(connStr);
                }
            }
        protected override void OnModelCreating(ModelBuilder model)
            {
            model.Entity<Product>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Code).HasMaxLength(10).IsRequired();
                e.Property(x => x.Name).HasMaxLength(30).IsRequired();
                e.Property(x => x.Price);
                e.HasIndex(x => x.Code).IsUnique();
            });
            model.Entity<Orderline>(e =>
            {
                e.ToTable("Orderlines");
                e.HasKey(x => x.Id);
                e.HasOne(x => x.Product).WithMany(x => x.Orderlines)
                                       .HasForeignKey(x => x.ProductId)
                                       .OnDelete(DeleteBehavior.Restrict);
            });
            }
               
        }   

    }