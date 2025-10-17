using BooksLibraryAspNet.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BooksLibraryAspNet.Service;

public static class ServiceExtension
{
    public static void RegisterService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped(typeof(IService<>), typeof(Service<>));
    }
}