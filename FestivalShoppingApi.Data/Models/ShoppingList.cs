using System.ComponentModel.DataAnnotations;
using FestivalShoppingApi.Data.Dtos;

namespace FestivalShoppingApi.Data.Models;

public class ShoppingList
{
    [Key]
    public Guid GuidId { get; set; }
    public string Name { get; set; } = String.Empty;
    public virtual List<Category> Categories { get; set; } = [];
}

public static class ShoppingListExtensions
{
    public static ShoppingListDto ConvertToDto(this ShoppingList shoppingList)
    {
        return new ShoppingListDto
        {
            ShoppingListId = shoppingList.GuidId,
            Categories = shoppingList.Categories.Select(c => c.ConvertToDto()).ToList()
        };
    }
}