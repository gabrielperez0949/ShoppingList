using ShoppingList.Data.Abstractions.Parts;
using ShoppingList.Data.Entity;

namespace ShoppingList.Data.Abstractions;

public interface IUser : IStringIdPart, IFirstnamePart, ILastnamePart, IUsernamePart
{

}
