namespace Booking.Data
{
    public interface IBaseRepository<T>
    {
        Task<List<T>> GetAll();

        Task<T?> GetById(params object[] key);
        Task AddAsync(T entity);

        Task UpdateWithId(int Id);

        Task Update(T entity);
        IQueryable<T> Table { get; }
        IQueryable<T> TableNoTracking { get; }


    }
}
