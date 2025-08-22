using C44_G00_EF02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G00_EF02.Configs
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Departments");

            builder.HasKey(d => d.ID);

            builder.Property(d => d.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(d => d.Name)
                .IsUnique();

            builder.Property(d => d.Ins_ID)
                .IsRequired(false);

            builder.Property(d => d.HiringDate)
                .IsRequired();

            builder.HasCheckConstraint("CK_Department_HiringDate", "HiringDate <= GETDATE()");
        }
    }
}
