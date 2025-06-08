using System.ComponentModel.DataAnnotations;

namespace FestivalShoppingApi.Data.Models;

public class ShoppingList
{
    [Key]
    public Guid GuidId { get; set; }
    public string Name { get; set; } = String.Empty;
    public virtual List<Category> Categories { get; set; } = [];
}