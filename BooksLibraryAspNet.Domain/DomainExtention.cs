using BooksLibraryAspNet.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BooksLibraryAspNet.Domain;

public static class DomainExtension
{
    public static void RegisterDomain(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    }
}