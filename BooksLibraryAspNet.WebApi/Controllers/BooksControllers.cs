using LibraryComplexServices.Service;
using BooksLibraryAspNet.Domain.Entities;

namespace BooksLibraryAspNet.WebApi.Controllers
{
    public class BooksController : GenericController<Book>
    {
        public BooksController(IService<Book> service) : base(service) { }
    }
}