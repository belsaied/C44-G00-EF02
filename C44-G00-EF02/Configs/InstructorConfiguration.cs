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
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.ToTable("Instructors");

            builder.HasKey(i => i.ID);

            builder.Property(i => i.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(i => i.Salary)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.HasCheckConstraint("CK_Instructor_Salary", "Salary > 0");

            builder.Property(i => i.Address)
                .HasMaxLength(150)
                .IsRequired(false);

            builder.Property(i => i.HourRateBouns)
                .HasColumnType("decimal(10,2)")
                .HasDefaultValue(0);

            builder.HasCheckConstraint("CK_Instructor_HourRateBouns", "HourRateBouns >= 0");

            builder.Property(i => i.Dept_ID)
                .IsRequired();

            // Foreign Key Relationship
            builder.HasOne(i => i.Department)
                .WithMany(d => d.Instructors)
                .HasForeignKey(i => i.Dept_ID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
