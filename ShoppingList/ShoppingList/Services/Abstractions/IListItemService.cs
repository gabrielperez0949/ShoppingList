using ShoppingList.Data.Entity;

namespace ShoppingList.Services.Abstractions;

/// <summary>
///   CRUD service to Create, Read, Update, and Delete list items.
/// </summary>
public interface IListItemService : ICRUDService<ListItem>
{
    /// <summary>
    ///   Get a list of shopping list items by the user id
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<IEnumerable<ListItem>> ListAsync(string userId);
}
