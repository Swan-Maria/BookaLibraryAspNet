namespace BooksLibraryAspNet.Domain.Models;

public class Author
{
    public int Id { get; set; }
    public string FullName { get; set; }

    public ICollection<Book> Books { get; set; } = new List<Book>();
}