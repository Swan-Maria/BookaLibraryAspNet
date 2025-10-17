using BooksLibraryAspNet.Service.Services;
using BooksLibraryAspNet.Domain.Entities;

namespace BooksLibraryAspNet.WebApi.Controllers
{
    public class GenresController : GenericController<Genre>
    {
        public GenresController(IService<Genre> service) : base(service) { }
    }
}