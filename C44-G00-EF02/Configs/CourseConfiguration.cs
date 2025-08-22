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
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses");

            builder.HasKey(c => c.ID);

            builder.Property(c => c.Duration)
                .IsRequired();

            builder.HasCheckConstraint("CK_Course_Duration", "Duration > 0");

            builder.Property(c => c.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(c => c.Name)
                .IsUnique();

            builder.Property(c => c.Description)
                .HasMaxLength(255)
                .IsRequired(false);

            builder.Property(c => c.Top_ID)
                .IsRequired();
        }
    }
}
