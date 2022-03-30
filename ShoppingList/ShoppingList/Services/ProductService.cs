using ShoppingList.Data;
using ShoppingList.Data.Entity;
using ShoppingList.Services.Abstractions;

namespace ShoppingList.Services;

public class ProductService : CRUDServiceBase<Product>, IProductService
{
    public ProductService(ILogger<CRUDServiceBase<Product>> logger, ShoppingListContext context) : base(logger, context)
    {
    }
}
