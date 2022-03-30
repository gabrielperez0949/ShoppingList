namespace ShoppingList.Services.Abstractions;

public interface IMapper
{
    TView MapToView<TView, TEntity>(TEntity entity)
        where TView : class
        where TEntity : class;

    TEntity MapToEntity<TView, TEntity>(TView view)
        where TView : class
        where TEntity : class;
}
