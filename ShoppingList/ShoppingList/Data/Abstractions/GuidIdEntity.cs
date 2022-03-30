using ShoppingList.Data.Abstractions.Parts;
using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Data.Abstractions;

public abstract class GuidIdEntity : IGuidIdPart
{
    [Key]
    [Required]
    public virtual Guid Id { get; set; }
}
