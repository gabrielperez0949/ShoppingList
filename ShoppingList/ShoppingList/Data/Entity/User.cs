using ShoppingList.Data.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ShoppingList.Data.Entity;

public class User : StringIdEntity, IUser
{
    [Required]
    [MaxLength(256)]
    public string? Firstname { get; set; }

    [Required]
    [MaxLength(256)]
    public string? Lastname { get; set; }

    [Required]
    [MaxLength(256)]
    public string? Username { get; set; }

    [JsonIgnore]
    public virtual ICollection<ListItem> ListItems { get; set; }

}
