using FestivalShoppingApi.Data.Models;

namespace FestivalShoppingApi.Common.Dtos;

public record ItemDto
{
    public Guid ItemId { get; init; }
    public string Name { get; init; } = string.Empty;
    public string? Url { get; init; }
    public bool Essential { get; init; }
}

public static class ItemExtensions
{
    public static ItemDto ConvertToDto(this Item item)
    {
        return new ItemDto()
        {
            ItemId = item.ItemId,
            Name = item.Name,
            Url = item.Url,
            Essential = item.Essential
        };
    }
}