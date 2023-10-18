using LibraryManagementSystem.API.Data;
using LibraryManagementSystem.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Tests;

public class UnitTest1
{
    private LibraryDbContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<LibraryDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

        var context = new LibraryDbContext(options);
        context.Database.EnsureDeleted(); // ensure we're starting with a clean database
        return context;
    }

    [Fact]
    public void TestGetBooksByAuthor()
    {
        using var context = GetInMemoryDbContext();

        var author = new Author { Name = "Tolkien" };
        var book1 = new Book { Title = "The Hobbit", ISBN = "123", Author = author };
        var book2 = new Book { Title = "Lord of the Rings", ISBN = "456", Author = author };

        context.Books.AddRange(book1, book2);
        context.SaveChanges();

        var library = new Library(context);

        var result = library.GetBooksByAuthor("Tolkien");

        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void TestGetAllCheckedOutBooks()
    {
        using var context = GetInMemoryDbContext();

        var book1 = new Book { Title = "The Hobbit", ISBN = "123", CheckedOut = true };
        var book2 = new Book { Title = "Lord of the Rings", ISBN = "456", CheckedOut = false };
        
        context.Books.AddRange(book1, book2);
        context.SaveChanges();

        var library = new Library(context);

        var result = library.GetAllCheckedOutBooks();

        Assert.Single(result);
        Assert.True(result.First().CheckedOut);
    }

    [Fact]
    public async Task TestCheckOutBookAsync()
    {
        await using var context = GetInMemoryDbContext();
        
        var book = new Book { Title = "The Hobbit", ISBN = "123", CheckedOut = false };

        context.Books.Add(book);
        await context.SaveChangesAsync();

        var library = new Library(context);

        var success = await library.CheckOutBookAsync("123");

        Assert.True(success);
        Assert.True(context.Books.First(b => b.ISBN == "123").CheckedOut);
    }
}