using Microsoft.EntityFrameworkCore;
using ShoppingList.Data;
using ShoppingList.Data.Abstractions;
using ShoppingList.Exceptions;
using System.Reflection;

namespace ShoppingList.Services.Abstractions;

public abstract class CRUDServiceBase<T> : ICRUDService<T>
    where T : StringIdEntity
{
    public CRUDServiceBase(ILogger<CRUDServiceBase<T>> logger, ShoppingListContext context)
    {
        _logger = logger;
        Context = context;
    }

    protected ShoppingListContext Context { get; set; }
    protected DbSet<T> DbSet => Context.Set<T>();

    private readonly ILogger<CRUDServiceBase<T>> _logger;

    protected bool _eagerFetch = true;

    public virtual async Task<bool> CreateAsync(T item)
    {
        DbSet.Add(item);
        await Context.SaveChangesAsync();

        return true;
    }

    public virtual async Task<bool> DeleteAsync(string id)
    {
        var item = await GetByIdAsync(id);

        DbSet.Remove(item);
        await Context.SaveChangesAsync();

        return true;
    }

    public virtual async Task<T> GetByIdAsync(string id)
    {
        var item = await GetEagerFetchQuery().Where(t => id == t.Id).FirstOrDefaultAsync<T>();
        if (item == default)
            throw new ItemNotFoundException();

        return item;
    }

    public virtual async Task<IEnumerable<T>> ListAsync()
    {
        var query = GetEagerFetchQuery();

        return await query.ToListAsync();
    }

    public virtual async Task<bool> UpdateAsync(T item)
    {
        var dbItem = await GetByIdAsync(item.Id);

        dbItem.GetType().GetRuntimeProperties().Where(p => p.CanWrite && p.CanRead).ToList().ForEach(p =>
        {
            p.SetValue(dbItem, p.GetValue(item));
        });

        await Context.SaveChangesAsync();

        return true;
    }

    protected IQueryable<T> GetEagerFetchQuery()
    {
        var query = DbSet.AsQueryable();

        if(_eagerFetch)
        {
            var navigations = Context.Model.FindEntityType(typeof(T))
            .GetDerivedTypesInclusive()
            .SelectMany(type => type.GetNavigations())
            .Distinct();

            foreach (var property in navigations)
                query = query.Include(property.Name);
        }

        return query;
    }
}
