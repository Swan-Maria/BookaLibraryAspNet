using BooksLibraryAspNet.Domain.Repositories;

namespace BooksLibraryAspNet.Service.Services;

internal class Service<T> : IService<T> where T : class
{
    private readonly IRepository<T> _repository;
    public Service(IRepository<T> repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<T>> GetAllAsync() => _repository.GetAllAsync();
    public Task<T?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
    public Task<T> AddAsync(T entity) => _repository.AddAsync(entity);
    public Task UpdateAsync(T entity) => _repository.UpdateAsync(entity);
    public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
}