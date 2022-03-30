namespace ShoppingList.Data.Abstractions.Parts;

public interface ILastnamePart
{
    /// <summary>
    ///   The last name of a user.
    /// </summary>
    string? Lastname { get; set; }
}