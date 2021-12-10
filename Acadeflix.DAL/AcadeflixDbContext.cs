using Acadeflix.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Acadeflix.DAL
{
    public class AcadeflixDbContext : DbContext
    {
        public DbSet<Content> Contents { get; set; }
        public DbSet<Watcher> Watchers { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<Role> Roles { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Acadeflix;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Content>()
                .HasOne(p => p.Previous)
                .WithOne()
                .HasForeignKey<Content>(p => p.PreviousId);
            modelBuilder.Entity<Content>()
                .HasOne(p => p.Parent)
                .WithMany()
                .HasForeignKey(p => p.ParentId);
            modelBuilder.Entity<Credit>()
                .HasKey(cm => new { cm.RoleId, cm.CastId, cm.ContentId });
        }
    }
}
