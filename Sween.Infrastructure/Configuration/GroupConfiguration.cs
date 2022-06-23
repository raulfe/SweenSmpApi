using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sween.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sween.Infrastructure.Configuration
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(e => e.GroupId);

            builder.ToTable("groups");

            builder.HasComment("Table to create groups");

            builder.HasIndex(e => e.GroupId, "GROUP_PK")
                .IsUnique();

            builder.Property(e => e.CreatedBy)
                .HasMaxLength(250)
                .HasColumnName("CREATED_BY");

            builder.Property(e => e.CreationDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATION_DATE")
                .HasDefaultValueSql("curdate()");

            builder.Property(e => e.GroupDescription)
                .HasMaxLength(400)
                .HasColumnName("GROUP_DESCRIPTION");

            builder.Property(e => e.GroupId)
                .HasPrecision(15)
                .HasColumnName("GROUP_ID");

            builder.Property(e => e.GroupType)
                .HasPrecision(15)
                .HasColumnName("GROUP_TYPE");

            builder.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("UPDATE_DATE");

            builder.Property(e => e.UpdatedBy)
                .HasMaxLength(250)
                .HasColumnName("UPDATED_BY");

            builder.Property(e => e.Xdate)
                .HasColumnType("datetime")
                .HasColumnName("XDATE");

            builder.Property(e => e.Xuser)
                .HasMaxLength(30)
                .HasColumnName("XUSER");
        }
    }
}
