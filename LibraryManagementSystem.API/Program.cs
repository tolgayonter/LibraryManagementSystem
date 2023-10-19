using LibraryManagementSystem.API.Data;
using LibraryManagementSystem.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseSqlite("Data Source=library.db"));

builder.Services.AddScoped<Library>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
    DbInitializer.Initialize(context);
}

app.MapGet("/", () => "Hello World!");

app.MapGet("/books", (Library library) =>
    library.Books);

app.MapGet("/books/author/{authorName}", (string authorName, Library library) =>
    library.GetBooksByAuthor(authorName));

app.MapGet("/books/checkedout", (Library library) =>
    library.GetAllCheckedOutBooks());

app.MapPost("/books/checkout", async (string isbn, Library library) => 
    await library.CheckOutBookAsync(isbn));

app.Run();