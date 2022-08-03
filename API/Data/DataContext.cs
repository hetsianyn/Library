using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Book> Book { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Review>()
                .HasKey(x => x.Id);
            builder.Entity<Review>()
                .HasIndex(x => x.Id).IsUnique();
            builder.Entity<Review>()
                .HasOne(b => b.SourceBook)
                .WithMany(r => r.Reviews)
                .HasForeignKey(b => b.SourceBookId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.Entity<Rating>()
                .HasKey(x => x.Id);
            builder.Entity<Review>()
                .HasIndex(x => x.Id).IsUnique();
            builder.Entity<Rating>()
                .HasOne(b => b.SourceBook)
                .WithMany(s => s.Ratings)
                .HasForeignKey(b => b.SourceBookId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}