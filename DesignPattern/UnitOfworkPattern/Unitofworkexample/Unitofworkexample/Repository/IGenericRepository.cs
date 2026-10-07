namespace Unitofworkexample.Repository
{
    public interface IGenericRepository<T>where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(object Id);
        Task InsertAsync(T Entity);
        Task UpdateEntity(T Entity);
        Task DeleteEntityAsync(object Id);
        Task SaveAsync();

    }
}
