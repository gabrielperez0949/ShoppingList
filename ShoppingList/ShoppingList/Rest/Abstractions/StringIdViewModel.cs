using ShoppingList.Data.Abstractions.Parts;
using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Data.Abstractions;

public abstract class StringIdViewModel : IStringIdPart
{
    [Required]
    [MaxLength(38)]
    public virtual string Id { get; set; }
}
