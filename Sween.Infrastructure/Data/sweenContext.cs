using Microsoft.EntityFrameworkCore;
using Sween.Core.Entities;
using Sween.Infrastructure.Configuration;

#nullable disable

namespace Sween.Infrastructure.Data
{
    public partial class sweenContext : DbContext
    {
        public sweenContext()
        {
        }

        public sweenContext(DbContextOptions<sweenContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserContact> UserContact { get; set; }
        public virtual DbSet<UserGroup> UserGroup { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserContactConfiguration());
            modelBuilder.ApplyConfiguration(new UserGroupConfiguration());
        }

        
    }
}
