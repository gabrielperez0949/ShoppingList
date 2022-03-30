using ShoppingList.Data.Abstractions;

namespace ShoppingList.Rest.ViewModel;

public class ListItemViewModel : StringIdViewModel
{
    public virtual ProductViewModel Product { get; set; }
}
