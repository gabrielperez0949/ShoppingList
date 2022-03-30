using ShoppingList.Data.Abstractions.Parts;

namespace ShoppingList.Data.Abstractions;

/// <summary>
///   A product being sold
/// </summary>
public interface IProduct : IStringIdPart, INamePart, IDescriptionPart, IPricePart
{
    string ImageUrl { get; set; }

    string ImageAlt { get; set; }
}
