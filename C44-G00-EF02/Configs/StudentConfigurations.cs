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
    public class StudentConfigurations : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {

            builder.HasKey(s => s.ID);

            builder.Property(s => s.FName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(s => s.LName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(s => s.Address)
                .HasMaxLength(150)
                .IsRequired(false);

            builder.Property(s => s.Age)
                .IsRequired();

            // I Don't know how to apply the Range of Age here so i will do it with Data Annotations.
            //Note: I will Add DbSet for it .
            builder.Property(s => s.Dep_Id)
                .IsRequired();
        }
    }
}
