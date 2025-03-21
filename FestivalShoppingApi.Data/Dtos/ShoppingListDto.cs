namespace FestivalShoppingApi.Data.Dtos;

public record ShoppingListDto
{
    public Guid ShoppingListId { get; init; }
    public required string Name { get; init; }
    public List<CategoryDto> Categories { get; init; } = [];
}