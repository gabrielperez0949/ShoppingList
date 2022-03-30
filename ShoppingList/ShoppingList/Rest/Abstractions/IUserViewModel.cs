using ShoppingList.Data.Abstractions.Parts;
using ShoppingList.Rest.ViewModel;

namespace ShoppingList.Data.Abstractions;

public interface IUserViewModel : IStringIdPart, IFirstnamePart, ILastnamePart, IUsernamePart
{
    /// <summary>
    ///   Shopping list associated with the user.
    /// </summary>
    public ShoppingListViewModel ShoppingList { get; set;}
}
