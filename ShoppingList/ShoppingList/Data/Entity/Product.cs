using ShoppingList.Data.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ShoppingList.Data.Entity;

public class Product : StringIdEntity, IProduct
{
    [Required]
    [MaxLength(256)]
    public string? Name { get; set; }

    [MaxLength(256)]
    public string? Description { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    public int Price { get; set; }

    [Required]
    [MaxLength(256)]
    public string ImageUrl { get; set; }

    [MaxLength(256)]
    public string ImageAlt { get; set; }

    [JsonIgnore]
    public virtual ICollection<ListItem> ListItems { get; set; }
}