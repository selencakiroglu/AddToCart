using Microsoft.EntityFrameworkCore;

namespace AddToCart.Entities
{
    public class AddToCartContext : DbContext
    {
        public AddToCartContext(DbContextOptions<AddToCartContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MovieCategory> MovieCategories { get; set; }
        public DbSet<Director> Directors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieCategory>()
                .HasKey(rc => new { rc.MovieId, rc.CategoryId });
            modelBuilder.Entity<MovieCategory>()
                .HasOne(rc => rc.Movie)
                .WithMany(r => r.MovieCategories)
                .HasForeignKey(rc => rc.MovieId);
            modelBuilder.Entity<MovieCategory>()
                .HasOne(rc => rc.Category)
                .WithMany(c => c.MovieCategories)
                .HasForeignKey(rc => rc.CategoryId);
        }
    }
}
