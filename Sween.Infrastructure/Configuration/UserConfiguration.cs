using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sween.Core.Entities;

namespace Sween.Infrastructure.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
           
            builder.ToTable("users");

            builder.Property(e => e.ActiveDate)
                .HasColumnType("datetime")
                .HasColumnName("ACTIVE_DATE");

            builder.Property(e => e.Birthday)
                .HasMaxLength(200)
                .HasColumnName("BIRTHDAY");

            builder.Property(e => e.CreatedBy)
                .HasMaxLength(250)
                .HasColumnName("CREATED_BY");

            builder.Property(e => e.CreationDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATION_DATE")
                .HasDefaultValueSql("curdate()");

            builder.Property(e => e.Email)
                .HasMaxLength(250)
                .HasColumnName("EMAIL");

            builder.Property(e => e.Imageurl)
                .HasMaxLength(500)
                .HasColumnName("IMAGEURL");

            builder.Property(e => e.InactiveDate)
                .HasColumnType("datetime")
                .HasColumnName("INACTIVE_DATE");

            builder.Property(e => e.Status)
                .HasMaxLength(1)
                .HasColumnName("STATUS");

            builder.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("UPDATE_DATE");

            builder.Property(e => e.UpdatedBy)
                .HasMaxLength(250)
                .HasColumnName("UPDATED_BY");

            builder.Property(e => e.UserCountry)
                .HasMaxLength(50)
                .HasColumnName("USER_COUNTRY");

            builder.Property(e => e.UserId)
                .HasPrecision(15)
                .HasColumnName("USER_ID");

            builder.Property(e => e.UserLastName)
                .HasMaxLength(100)
                .HasColumnName("USER_LAST_NAME");

            builder.Property(e => e.UserMidleName)
                .HasMaxLength(100)
                .HasColumnName("USER_MIDLE_NAME");

            builder.Property(e => e.UserName)
                .HasMaxLength(100)
                .HasColumnName("USER_NAME");

            builder.Property(e => e.UserPhoneNumber)
                .HasMaxLength(50)
                .HasColumnName("USER_PHONE_NUMBER");

            builder.Property(e => e.UserPublicId)
                .HasPrecision(10)
                .HasColumnName("USER_PUBLIC_ID");

            builder.Property(e => e.UserPublicName)
                .HasMaxLength(200)
                .HasColumnName("USER_PUBLIC_NAME");

            builder.Property(e => e.UserThemeId)
                .HasPrecision(10)
                .HasColumnName("USER_THEME_ID");
        }
    }
}
