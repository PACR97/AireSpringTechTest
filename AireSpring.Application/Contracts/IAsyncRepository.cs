namespace AireSpring.Application.Contracts;

/// <summary>
/// Interface of base repository
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IAsyncRepository<T> where T : class
{
    /// <summary>
    /// Get one register filtering by entity id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<T> GetByIdAsync(Guid id);

    /// <summary>
    /// Get all registers 
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<T>> GetAllAsync();

    /// <summary>
    /// Insert new record in database
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<int> AddAsync(T entity);

    /// <summary>
    /// Update record in database
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<T> UpdateAsync(T entity);

    /// <summary>
    /// Delete record from database
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<int> DeleteAsync(Guid id);
}
