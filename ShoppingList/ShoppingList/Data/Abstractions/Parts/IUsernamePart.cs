namespace ShoppingList.Data.Abstractions.Parts;

public interface IUsernamePart
{
    /// <summary>
    ///   The user name of a user.
    /// </summary>
    string? Username { get; set; }
}
