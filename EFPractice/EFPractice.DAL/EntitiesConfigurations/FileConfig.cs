using EFPractice.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFPractice.DAL.EntitiesConfigurations
{
    internal class FileConfig : IEntityTypeConfiguration<File>
    {
        public void Configure(EntityTypeBuilder<File> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.FilePermissions)
                .WithOne(x => x.File)
                .HasForeignKey(x => x.FileId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Directory)
                 .WithMany(x => x.Files)
                 .HasForeignKey(x => x.DirectoryId)
                 .IsRequired()
                 .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Title).HasMaxLength(128).IsRequired();
            builder.Property(x => x.Extention).HasMaxLength(10).IsRequired();
            builder.Property(x => x.Size).IsRequired();
        }
    }
}
