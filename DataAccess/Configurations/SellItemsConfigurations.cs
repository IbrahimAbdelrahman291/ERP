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
    public class SellItemsConfigurations : IEntityTypeConfiguration<SellItem>
    {
        public void Configure(EntityTypeBuilder<SellItem> builder)
        {
            builder.Property(P => P.Amount).IsRequired();
            builder.Property(P => P.Billing).HasColumnType("decimal(18,2)");
        }
    }
}
