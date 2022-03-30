using Microsoft.EntityFrameworkCore;
using ShoppingList.Data;
using ShoppingList.Data.Entity;
using ShoppingList.Exceptions;
using ShoppingList.Services.Abstractions;

namespace ShoppingList.Services;

public class ListItemService : CRUDServiceBase<ListItem>, IListItemService
{
    public ListItemService(ILogger<CRUDServiceBase<ListItem>> logger, ShoppingListContext context) : base(logger, context)
    {
    }

    public async Task<IEnumerable<ListItem>> ListAsync(string userId)
    {
        var items = await GetEagerFetchQuery().Where(i => userId == i.User.Id).ToListAsync();
        if (items == default)
            throw new ItemNotFoundException();

        return items;
    }
}
