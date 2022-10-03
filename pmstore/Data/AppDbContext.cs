using Microsoft.EntityFrameworkCore;
using pmstore.Models;

namespace pmstore.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist_Album>().HasKey(am => new
            {
                am.ArtistId,
                am.AlbumId
            });

            modelBuilder.Entity<Artist_Album>().HasOne(m => m.Album).WithMany(am => am.Artists_Albums).HasForeignKey(m => m.AlbumId);
            modelBuilder.Entity<Artist_Album>().HasOne(m => m.Artist).WithMany(am => am.Artists_Albums).HasForeignKey(m => m.ArtistId);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist_Album> Artists_Albums { get; set; }
        public DbSet<Streaming> Streamings { get; set; }
        public DbSet<Producer> Producers { get; set; }


      
    }
}
