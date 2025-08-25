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
    public class CourseInstConfiguration : IEntityTypeConfiguration<CourseInst>
    {
        public void Configure(EntityTypeBuilder<CourseInst> builder)
        {
            builder.ToTable("Course_Inst");

            // Composite Primary Key
            builder.HasKey(ci => new { ci.Inst_ID, ci.Course_ID });

            builder.Property(ci => ci.Evaluate)
                .HasMaxLength(255)
                .IsRequired(false);

            // Foreign Key Relationships
            builder.HasOne(ci => ci.Instructor)
                .WithMany(i => i.CourseInstructors)
                .HasForeignKey(ci => ci.Inst_ID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ci => ci.Course)
                .WithMany(c => c.CourseInstructors)
                .HasForeignKey(ci => ci.Course_ID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
