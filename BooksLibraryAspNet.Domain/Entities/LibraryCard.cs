namespace BooksLibraryAspNet.Domain.Entities;

public class LibraryCard
{
    public int Id { get; set; }
    public string CardNumber { get; set; }

    public int ReaderId { get; set; }
    public Reader Reader { get; set; }
}