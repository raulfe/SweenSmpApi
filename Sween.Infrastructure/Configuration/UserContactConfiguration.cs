using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sween.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sween.Infrastructure.Configuration
{
    public class UserContactConfiguration : IEntityTypeConfiguration<UserContact>
    {
        public void Configure(EntityTypeBuilder<UserContact> builder)
        {
            builder.HasKey(e => e.ContactId);

            builder.ToTable("user_contacts");

            builder.HasIndex(e => e.ContactId, "CONTACT_ID_PK")
                .IsUnique();

            builder.Property(e => e.ContactId)
                .HasPrecision(15)
                .HasColumnName("CONTACT_ID");

            builder.Property(e => e.CreatedBy)
                .HasMaxLength(250)
                .HasColumnName("CREATED_BY");

            builder.Property(e => e.CreationDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATION_DATE")
                .HasDefaultValueSql("curdate()");

            builder.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("UPDATE_DATE");

            builder.Property(e => e.UpdatedBy)
                .HasMaxLength(250)
                .HasColumnName("UPDATED_BY");

            builder.Property(e => e.UserPublicId)
                .HasPrecision(15)
                .HasColumnName("USER_PUBLIC_ID");

            builder.Property(e => e.UserPublicId2)
                .HasPrecision(15)
                .HasColumnName("USER_PUBLIC_ID_2");

            builder.Property(e => e.Status)
                .HasPrecision(15)
                .HasColumnName("STATUS");
        }
    }
}
