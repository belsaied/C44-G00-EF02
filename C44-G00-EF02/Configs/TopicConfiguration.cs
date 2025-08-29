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
    public class TopicConfiguration : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.ToTable("Topics");

            builder.HasKey(t => t.ID);

            builder.Property(t => t.ID).ValueGeneratedOnAdd();

            builder.Property(t => t.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(t => t.Name)
                .IsUnique();
        }
    }
}
