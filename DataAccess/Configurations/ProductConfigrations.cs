using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class ProductConfigrations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(P => P.Name).IsRequired();
            builder.Property(P => P.Amount).IsRequired();
            builder.Property(P => P.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.HasOne(P => P.Inventory).WithOne(P => P.Product).HasForeignKey<Inventory>(I => I.ProductId);
            builder.HasOne(P => P.Stock).WithOne(P => P.Product).HasForeignKey<Stock>(I => I.ProductId);
        }
    }
}
