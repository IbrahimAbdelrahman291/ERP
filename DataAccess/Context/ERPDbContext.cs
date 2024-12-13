using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class ERPDbContext : DbContext
    {
        public ERPDbContext(DbContextOptions<ERPDbContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        
        public DbSet<Admin> admins { get; set; }
        public DbSet<Bransh> branshes { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Sell> Sells { get; set; }
        public DbSet<SellItem> SellItems { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Transaction> transactions { get; set; }
        public DbSet<TransactionItems> TransactionItems { get; set; }

    }
}
