using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sween.Core.Entities;

namespace Sween.Infrastructure.Configuration
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(e => e.MessageId);

            builder.ToTable("messages");

            builder.HasIndex(e => e.MessageId, "MESSAGE_PK")
                .IsUnique();

            builder.Property(e => e.MessageBlob)
                .HasMaxLength(500)
                .HasColumnName("MESSAGE_BLOB");

            builder.Property(e => e.CreatedBy)
                .HasMaxLength(250)
                .HasColumnName("CREATED_BY");

            builder.Property(e => e.CreationDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATION_DATE")
                .HasDefaultValueSql("curdate()");

            builder.Property(e => e.GroupId)
                .HasPrecision(15)
                .HasColumnName("GROUP_ID");

            builder.Property(e => e.Message1)
                .HasMaxLength(4000)
                .HasColumnName("MESSAGE");

            builder.Property(e => e.MessageId)
                .HasPrecision(15)
                .HasColumnName("MESSAGE_ID");


            builder.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("UPDATE_DATE");

            builder.Property(e => e.UpdatedBy)
                .HasMaxLength(250)
                .HasColumnName("UPDATED_BY");

            builder.Property(e => e.UserId)
                .HasPrecision(15)
                .HasColumnName("USER_ID");

            builder.Property(e => e.Xdate)
                .HasColumnType("datetime")
                .HasColumnName("XDATE");

            builder.Property(e => e.Xuser)
                .HasMaxLength(30)
                .HasColumnName("XUSER");

            builder.Property(e => e.BlobType)
                .HasMaxLength(30)
                .HasColumnName("BLOB_TYPE");
        }
    }
}
