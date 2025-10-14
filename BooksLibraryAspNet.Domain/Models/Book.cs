namespace BooksLibraryAspNet.Domain.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }

    // Many-to-One
    public int GenreId { get; set; }
    public Genre Genre { get; set; }

    // Many-to-Many
    public ICollection<Author> Authors { get; set; } = new List<Author>();
}