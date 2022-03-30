using ShoppingList.Data.Abstractions;

namespace ShoppingList.Data.Entity;

public class ListItem : StringIdEntity, IListItem
{ 

    public string UserId { get; set; }

    public string ProductId { get; set; }

    public virtual Product Product { get; set; }

    public virtual User User { get; set; }
}
