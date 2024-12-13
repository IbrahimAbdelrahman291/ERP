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
    public class BranshConfigurations : IEntityTypeConfiguration<Bransh>
    {
        public void Configure(EntityTypeBuilder<Bransh> builder)
        {
            builder.Property(P => P.Name).IsRequired().HasMaxLength(100);
            builder.HasOne(b => b.Admin)
                   .WithMany(a => a.Branshes)
                   .HasForeignKey(b => b.AdminId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
