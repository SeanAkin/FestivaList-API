namespace FestivalShoppingApi.Data.Dtos;

public record CategoryDto
{
    public Guid CategoryId { get; init; }
    public string Name { get; init; }
    public List<ItemDto> Items { get; init; } = [];
}