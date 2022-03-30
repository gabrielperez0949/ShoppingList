using ShoppingList.Data.Abstractions;

namespace ShoppingList.Services.Abstractions;

/// <summary>
///   Generic CRUD service
/// </summary>
public interface ICRUDService<T> where T : StringIdEntity
{
    Task<IEnumerable<T>> ListAsync();

    Task<T> GetByIdAsync(string id);

    Task<bool> CreateAsync(T item);

    Task<bool> UpdateAsync(T item);

    Task<bool> DeleteAsync(string id);
        
}
