using LibraryManagementSystem.API.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.API.Models.Entities;

public class Library
{
    private readonly LibraryDbContext _context;

    public Library(LibraryDbContext context)
    {
        _context = context;
    }

    public List<Book> Books => _context.Books.ToList();

    public List<Book> GetBooksByAuthor(string authorName)
    {
        return _context.Books
            .Where(b => b.Author.Name == authorName)
            .ToList();
    }

    public List<Book> GetAllCheckedOutBooks()
    {
        return _context.Books
            .Where(b => b.CheckedOut)
            .ToList();
    }

    public async Task<bool> CheckOutBookAsync(string isbn)
    {
        var book = await _context.Books.FirstOrDefaultAsync(b => b.ISBN == isbn);
        if (book == null) return false;

        await Task.Delay(5000);

        book.CheckedOut = true;

        await _context.SaveChangesAsync();

        return true;
    }
}