using EFPractice.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFPractice.DAL.EntitiesConfigurations
{
    internal class FilePermissionConfig : IEntityTypeConfiguration<FilePermission>
    {
        public void Configure(EntityTypeBuilder<FilePermission> builder)
        {
            builder.HasKey(x => new { x.FileId, x.UserId });

            builder.HasOne(x => x.User)
                .WithMany(x => x.FilePermissions)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.File)
                .WithMany(x => x.FilePermissions)
                .HasForeignKey(x => x.FileId)
                .OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}
