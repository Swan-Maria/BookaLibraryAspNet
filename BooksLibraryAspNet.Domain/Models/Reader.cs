namespace BooksLibraryAspNet.Domain.Models;

public class Reader
{
    public int Id { get; set; }
    public string FullName { get; set; }

    public LibraryCard LibraryCard { get; set; }
}