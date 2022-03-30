using ShoppingList.Data.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Rest.ViewModel;

public class UserViewModel : StringIdViewModel
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
}
