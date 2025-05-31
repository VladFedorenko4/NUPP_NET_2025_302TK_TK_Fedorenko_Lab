namespace Tourist.Infrastructure.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);

        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> GetAllAsync(int page, int amount);

        Task AddAsync(T entity);

        Task Update(T entity);

        Task Delete(T entity);

        Task<bool> SaveAsync();
    }
}
