namespace LibraryManagementSystem.API.Models.Entities;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string ISBN { get; set; }
    public Author Author { get; set; }
    public bool CheckedOut { get; set; }
}