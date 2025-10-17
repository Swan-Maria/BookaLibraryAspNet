using BooksLibraryAspNet.Service.Services;
using BooksLibraryAspNet.Domain.Entities;

namespace BooksLibraryAspNet.WebApi.Controllers
{
    public class AuthorsController : GenericController<Author>
    {
        public AuthorsController(IService<Author> service) : base(service) { }
    }
}