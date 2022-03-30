namespace ShoppingList.Data.Abstractions.Parts;

public interface IGuidIdPart
{
    /// <summary>
    ///   Id of item
    /// </summary>
    Guid Id { get; set; }
}
