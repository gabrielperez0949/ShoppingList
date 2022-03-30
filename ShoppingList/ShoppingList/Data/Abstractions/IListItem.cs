using ShoppingList.Data.Abstractions.Parts;
using ShoppingList.Data.Entity;

namespace ShoppingList.Data.Abstractions;

/// <summary>
///   An item in the shopping list.
/// </summary>
public interface IListItem : IStringIdPart 
{
    /// <summary>
    ///   Product descripting the shopping list item.
    /// </summary>
    Product Product { get; set; }

    /// <summary>
    ///   User associated with the list item
    /// </summary>
    User User { get; set; }
}
