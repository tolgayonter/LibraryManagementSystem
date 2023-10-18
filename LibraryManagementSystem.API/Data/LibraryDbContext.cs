using LibraryManagementSystem.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.API.Data;

public class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>().HasMany(a => a.Books).WithOne(b => b.Author);
        // modelBuilder.Entity<Book>()
        //     .HasOne(b => b.Author)
        //     .WithMany(a => a.Books)
        //     .HasForeignKey(b => b.AuthorId);
    }
}