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
    public class StudCourseConfiguration : IEntityTypeConfiguration<StudCourse>
    {
        public void Configure(EntityTypeBuilder<StudCourse> builder)
        {
            builder.ToTable("Stud_Course");
            // Composite Primary Key
            builder.HasKey(sc => new { sc.Stud_ID, sc.Course_ID });

            builder.Property(sc => sc.Grade)
                .HasMaxLength(10)
                .IsRequired(false);

            // Foreign Key Relationships
            builder.HasOne(sc => sc.Student)
                .WithMany(s => s.StudCourses)
                .HasForeignKey(sc => sc.Stud_ID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(sc => sc.Course)
                .WithMany(c => c.StudCourses)
                .HasForeignKey(sc => sc.Course_ID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
