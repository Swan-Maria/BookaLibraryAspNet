using LibraryComplexServices.Service;
using BooksLibraryAspNet.Domain.Entities;

namespace BooksLibraryAspNet.WebApi.Controllers
{
    public class ReadersController : GenericController<Reader>
    {
        public ReadersController(IService<Reader> service) : base(service) { }
    }
}