using LibraryComplexApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryComplexApi.Data;

public class LibraryDbContext : DbContext
{
    public DbSet<Reader> Readers { get; set; }
    public DbSet<LibraryCard> LibraryCards { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Genre> Genres { get; set; }

    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) 
        : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5434;Database=postgres;Username=user;Password=1234");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
         // One-to-One
        modelBuilder.Entity<Reader>()
            .HasOne(r => r.LibraryCard)
            .WithOne(c => c.Reader)
            .HasForeignKey<LibraryCard>(c => c.ReaderId);

        // Many-to-Many
        modelBuilder.Entity<Book>()
            .HasMany(b => b.Authors)
            .WithMany(a => a.Books);

        // Many-to-One
        modelBuilder.Entity<Genre>()
            .HasMany(g => g.Books)
            .WithOne(b => b.Genre);
    }
}