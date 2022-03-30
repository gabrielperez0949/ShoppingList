namespace ShoppingList.Data.Abstractions.Parts;

public interface INamePart
{
    /// <summary>
    ///   The name of an item
    /// </summary>
    string Name { get; set; }
}