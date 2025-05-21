using CleanArchitecture_2025.Domain.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture_2025.Infrastructure.Configurations
{
    internal sealed class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.OwnsOne(e => e.PersonalInformation, builder =>
            {
                builder.Property(p => p.TCNo).HasColumnName("TCNO");
                builder.Property(p => p.Phone1).HasColumnName("Phone1");
                builder.Property(p => p.Phone2).HasColumnName("Phone2");
                builder.Property(p => p.Email).HasColumnName("Email");
            });

            builder.OwnsOne(e => e.Address, builder =>
            {
                builder.Property(a => a.Country).HasColumnName("Country");
                builder.Property(a => a.City).HasColumnName("City");
                builder.Property(a => a.Town).HasColumnName("Town");
                builder.Property(a => a.FullAddress).HasColumnName("FullAddress");
            });

            builder.Property(e => e.Salary).HasColumnType("money");
        }
    }
}
