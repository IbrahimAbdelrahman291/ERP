using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(P => P.UserName).IsRequired().HasMaxLength(50);
            builder.Property(P => P.Name).IsRequired().HasMaxLength(50);
            builder.Property(P => P.Password).IsRequired().HasMaxLength(50);
            builder.HasOne(e => e.Admin)
                   .WithMany(a => a.Employees)
                   .HasForeignKey(e => e.AdminId)
                   .OnDelete(DeleteBehavior.Restrict);
         
        }
    }
}
