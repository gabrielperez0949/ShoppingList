using ShoppingList.Services.Abstractions;
using System.Text.Json;

namespace ShoppingList.Services;

/// <summary>
///   Generic mapper implementation. Will map all public fields as long as schema is maintained.
/// </summary>
public class Mapper : IMapper
{
    public TEntity MapToEntity<TView, TEntity>(TView view)
        where TView : class
        where TEntity : class
    {
        var temp = JsonSerializer.Serialize(view);
        return JsonSerializer.Deserialize<TEntity>(temp);
    }

    public TView MapToView<TView, TEntity>(TEntity entity)
        where TView : class
        where TEntity : class
    {
        var temp = JsonSerializer.Serialize(entity);
        return JsonSerializer.Deserialize<TView>(temp);
    }
}
