using ShoppingList.Data.Abstractions;

namespace ShoppingList.Rest.ViewModel;

public class ProductViewModel : StringIdViewModel, IProductViewModel
{
    public string Name { get; set; }

    public string Description { get; set; }

    public int Price { get; set; }

    public string ImageUrl { get; set; }

    public string ImageAlt { get; set; }
}