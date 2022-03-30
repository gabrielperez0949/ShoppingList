using ShoppingList.Data;
using ShoppingList.Data.Entity;
using ShoppingList.Services.Abstractions;

namespace ShoppingList.Services;

public class UserService : CRUDServiceBase<User>, IUserService
{
    public UserService(ILogger<CRUDServiceBase<User>> logger, ShoppingListContext context) : base(logger, context)
    {
    }
}
