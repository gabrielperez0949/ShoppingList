using ShoppingList.Data.Abstractions.Parts;
using ShoppingList.Rest.ViewModel;

namespace ShoppingList.Data.Abstractions;

/// <summary>
///   An item in the shopping list.
/// </summary>
public interface IListItemViewModel : IStringIdPart 
{
    /// <summary>
    ///   Product descripting the shopping list item.
    /// </summary>
    ProductViewModel Product { get; set; }

    /// <summary>
    ///   Shopping list the item is associated.
    /// </summary>
    ShoppingListViewModel ShoppingList { get; set; }
}
