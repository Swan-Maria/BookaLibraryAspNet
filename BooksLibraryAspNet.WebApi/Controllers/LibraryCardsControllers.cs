using BooksLibraryAspNet.Service.Services;
using BooksLibraryAspNet.Domain.Entities;

namespace BooksLibraryAspNet.WebApi.Controllers
{
    public class LibraryCardsController : GenericController<LibraryCard>
    {
        public LibraryCardsController(IService<LibraryCard> service) : base(service) { }
    }
}