using ShoppingList.Data.Abstractions;

namespace ShoppingList.Rest.ViewModel;

public class ShoppingListViewModel : StringIdViewModel
{
    public ICollection<ListItemViewModel> ListItems { get; set; }
}
