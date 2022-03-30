using ShoppingList.Data.Abstractions.Parts;
using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Data.Abstractions;

public abstract class StringIdEntity : IStringIdPart
{
    [Key]
    [Required]
    [MaxLength(38)]
    public virtual string Id { get; set; }
}
