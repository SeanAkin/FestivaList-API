using FestivalShoppingApi.Data.Models;

namespace FestivalShoppingApi.Common.Dtos;

public record ShopperDto
{
    public Guid PersonId { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid ShoppingListId { get; set; }
    public List<ItemStatusDto> Items { get; set; } = [];
} 

public static class ShoppingListPersonExtensions
{
    public static ShopperDto ConvertToDto(this Shopper shopper)
    {
        return new ShopperDto
        {
            PersonId = shopper.PersonId,
            Name = shopper.Name,
            ShoppingListId = shopper.ShoppingListId,
            Items = shopper.ItemStatuses.Select(pi => pi.ConvertToDto()).ToList()
        };
    }
} 