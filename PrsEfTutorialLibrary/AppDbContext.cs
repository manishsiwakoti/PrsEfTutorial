using Microsoft.EntityFrameworkCore;
using PrsEfTutorialLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrsEfTutorialLibrary
    {
    public class AppDbContext : DbContext
        {
        
        public virtual DbSet<Order>Orders { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }

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
            }
        }
