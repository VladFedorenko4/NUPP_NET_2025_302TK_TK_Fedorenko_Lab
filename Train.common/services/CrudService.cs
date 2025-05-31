using Tourist.Infrastructure.Repository;

namespace Tourist.Common.Services
{
    public class CrudService<T> : ICrudService<T> where T : class, IIdentifiable
    {
        private readonly IRepository<T> _repository;

        public CrudService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreateAsync(T element)
        {
            await _repository.AddAsync(element);
            return await SaveAsync();
        }

        public async Task<T> ReadAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<T>> ReadAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IEnumerable<T>> ReadAllAsync(int page, int amount)
        {
            return await _repository.GetAllAsync(page, amount);
        }

        public async Task<bool> UpdateAsync(T element)
        {
            await Task.Run(() => _repository.Update(element));
            return await SaveAsync();
        }

        public async Task<bool> RemoveAsync(T element)
        {
            await Task.Run(() => _repository.Delete(element));
            return await SaveAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _repository.SaveAsync();
        }
    }
}

