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
    public class TransactionItemsConfigurations : IEntityTypeConfiguration<TransactionItems>
    {
        public void Configure(EntityTypeBuilder<TransactionItems> builder)
        {
            builder.Property(P => P.Amount).IsRequired();
            builder.HasOne(ti => ti.Transaction)
                   .WithMany(t => t.TransactionItems)
                   .HasForeignKey(ti => ti.TransactionId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
