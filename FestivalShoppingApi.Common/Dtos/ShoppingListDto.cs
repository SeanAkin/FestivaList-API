using FestivalShoppingApi.Data.Models;

namespace FestivalShoppingApi.Common.Dtos;

public record ShoppingListDto
{
    public Guid ShoppingListId { get; init; }
    public required string Name { get; init; }
    public List<CategoryDto> Categories { get; init; } = [];
}

public static class ShoppingListExtensions
{
    public static ShoppingListDto ConvertToDto(this ShoppingList shoppingList)
    {
        return new ShoppingListDto
        {
            ShoppingListId = shoppingList.GuidId,
            Name = shoppingList.Name,
            Categories = shoppingList.Categories.Select(c => c.ConvertToDto()).ToList()
        };
    }
}