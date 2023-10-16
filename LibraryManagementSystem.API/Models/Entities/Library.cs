namespace LibraryManagementSystem.API.Models.Entities;

public class Library
{
    public List<Book> Books { get; set; } = new List<Book>();

    public List<Book> GetBooksByAuthor(string authorName)
    {
        return Books.Where(book => book.Author.Name == authorName).ToList();
    }

    public List<Book> GetAllCheckOutBooks()
    {
        return Books.Where(book => book.CheckedOut).ToList();
    }

    public async Task<bool> CheckOutBookAsync(string isbn)
    {
        var book = Books.FirstOrDefault(b => b.ISBN == isbn);
        if (book == null) return false;

        await Task.Delay(1000);
        book.CheckedOut = true;
        return true;
    }
}