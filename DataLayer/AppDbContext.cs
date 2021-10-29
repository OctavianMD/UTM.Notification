using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class AppDbContext: DbContext
    {
        public DbSet<Notification> Notifications;
        public DbSet<Sender> Sender;
        public DbSet<Receiver> Receiver;
        public DbSet<Contact> Contact;

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notification>(entity =>
            {
                entity.ToTable("Notification");
                entity.HasKey(x => x.Id);
                entity.HasOne(x => x.Sender);
                entity.HasMany(x => x.Receivers);
            });

            modelBuilder.Entity<Receiver>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasIndex(x => x.Idnp);
                entity.HasMany(x => x.Contacts);
                entity.HasMany(x => x.Notifications);
            });

            modelBuilder.Entity<Sender>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Service).HasMaxLength(10);
                entity.HasIndex(x => new { x.Name, x.Service }).IsUnique();
                entity.HasMany(x => x.Notifications);
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasOne(x => x.Receiver);
            });
        }
    }
}
