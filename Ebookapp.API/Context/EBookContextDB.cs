using Ebookapp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Ebookapp.API.Context;

public class EBookContextDB : DbContext
{
    public EBookContextDB(DbContextOptions<EBookContextDB> options) :
    base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Purchase>()
            .HasKey(p => new { p.UserId, p.BookId });
        modelBuilder.Entity<BookGenre>()
            .HasKey(bg => new { bg.BookId, bg.GenreId });

        modelBuilder.Entity<Book>()
            .HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.AuthorID);

        modelBuilder.Entity<Purchase>()
            .HasOne(p => p.User)
            .WithMany(u => u.Purchases)
            .HasForeignKey(p => p.UserId);

        modelBuilder.Entity<Purchase>()
            .HasOne(p => p.Book)
            .WithMany(b => b.Purchases)
            .HasForeignKey(p => p.BookId);

        //Decimal precision
        modelBuilder.Entity<Book>()
            .Property(b => b.Price)
            .HasColumnType("decimal(18,2)");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EBookContextDB).Assembly);

    }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Purchase> Purchases { get; set; }

    public DbSet<Genre> Genres { get; set; }
    public DbSet<BookGenre> BookGenres { get; set; }


}