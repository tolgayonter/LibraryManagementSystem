using LibraryManagementSystem.API.Models.Entities;

namespace LibraryManagementSystem.API.Data;

public static class DbInitializer
{
    public static void Initialize(LibraryDbContext context)
    {
        context.Database.EnsureCreated();

        if (context.Books.Any()) return;

        var authors = new Author[]
        {
            new Author { Name = "Tolkien" },
            new Author { Name = "J.K. Rowling" }
        };

        context.Authors.AddRange(authors);
        context.SaveChanges();

        var books = new Book[]
        {
            new Book { Title = "The Hobbit", ISBN = "123", Author = authors[0], CheckedOut = false },
            new Book { Title = "Lord of the Rings", ISBN = "456", Author = authors[0], CheckedOut = false },
            new Book
            {
                Title = "Harry Potter and the Sorcerer's Stone", ISBN = "789", Author = authors[1], CheckedOut = false
            }
        };
        
        context.Books.AddRange(books);
        context.SaveChanges();
    }
}