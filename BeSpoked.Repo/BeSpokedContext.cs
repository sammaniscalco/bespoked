using BeSpoked.Repo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeSpoked.Repo
{
    public class BeSpokedContext : DbContext
    {
        public BeSpokedContext(DbContextOptions<BeSpokedContext> options)
            : base(options)
        {
        }
        
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Salesperson> Salespersons { get; set; }
    }
}
