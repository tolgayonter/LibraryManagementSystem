using LibraryManagementSystem.API.Models.Entities;

namespace LibraryManagementSystem.Tests;

public class UnitTest1
{
    [Fact]
    public void TestGetBooksByAuthor()
    {
        var author = new Author { Name = "Tolkien" };
        var book1 = new Book { Title = "The Hobbit", ISBN = "123", Author = author };
        var book2 = new Book { Title = "Lord of the Rings", ISBN = "456", Author = author };
        var library = new Library();
        library.Books.Add(book1);
        library.Books.Add(book2);

        var result = library.GetBooksByAuthor("Tolkien");
        
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public async Task TestCheckOutBookAsync()
    {
        var book = new Book { Title = "The Hobbit", ISBN = "123", CheckedOut = false };
        var library = new Library();
        library.Books.Add(book);

        var success = await library.CheckOutBookAsync("123");
        
        Assert.True(success);
        Assert.True(book.CheckedOut);
    }
}