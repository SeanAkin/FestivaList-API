using FestivalShoppingApi.Data.Models;

namespace FestivalShoppingApi.Common.Dtos;

public record CategoryDto
{
    public Guid CategoryId { get; init; }
    public string Name { get; init; }
    public List<ItemDto> Items { get; init; } = [];
}

public static class CategoryExtensions
{
    public static CategoryDto ConvertToDto(this Category category)
    {
        return new CategoryDto()
        {
            CategoryId = category.CategoryId,
            Name = category.Name,
            Items = category.Items.Select(i => i.ConvertToDto()).ToList()
        };
    }
}