using ShoppingList.Data.Abstractions.Parts;
using ShoppingList.Rest.ViewModel;

namespace ShoppingList.Data.Abstractions;

/// <summary>
///   Shopping list with list of items.
/// </summary>
public interface IShoppingListViewModel : IStringIdPart
{
    /// <summary>
    ///   User associated with the shopping list
    /// </summary>
    UserViewModel User { get; set; }

    /// <summary>
    ///   List of items in the shopping list
    /// </summary>
    ICollection<ListItemViewModel> ListItems { get; set;}
}