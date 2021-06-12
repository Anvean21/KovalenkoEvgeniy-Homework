using EFPractice.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Text;

namespace EFPractice.DAL.EntitiesConfigurations
{
    internal class DirectoryConfig : IEntityTypeConfiguration<Directory>
    {
        public void Configure(EntityTypeBuilder<Directory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasMaxLength(30).IsRequired();
            builder.HasOne(x => x.ParentDirectory)
                .WithMany(x => x.Directories)
                .HasForeignKey(x => x.ParentDirectoryId);
        }
    }
}
