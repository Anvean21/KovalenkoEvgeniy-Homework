using EFPractice.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFPractice.DAL.EntitiesConfigurations
{
    internal class DirectoryPermissionConfig : IEntityTypeConfiguration<DirectoryPermission>
    {
        public void Configure(EntityTypeBuilder<DirectoryPermission> builder)
        {
            builder.HasKey(x => new { x.DirectoryId, x.UserId });

            builder.HasOne(x => x.User)
                .WithMany(x => x.DirectoryPermissions)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Directory)
                .WithMany(x => x.DirectoryPermissions)
                .HasForeignKey(x => x.DirectoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
