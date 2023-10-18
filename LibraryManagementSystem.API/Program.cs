using LibraryManagementSystem.API.Data;
using LibraryManagementSystem.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseSqlite("Data Source=library.db"));

builder.Services.AddScoped<Library>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/books", (Library library) => library.Books);

app.Run();