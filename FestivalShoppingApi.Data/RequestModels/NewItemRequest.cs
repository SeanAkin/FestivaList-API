using FestivalShoppingApi.Data.Models;

namespace FestivalShoppingApi.Data.RequestModels;

public class NewItemRequest
{
    public string Name { get; set; } = string.Empty;
    public string? Url { get; set; }
    public bool Essential { get; set; }
    public Guid CategoryId { get; set; }
}

public static class NewItemRequestExtensions
{
    public static Item ToItem(this NewItemRequest newItemRequest)
        => new Item 
        { 
            Name = newItemRequest.Name, 
            Url = newItemRequest.Url, 
            Essential = newItemRequest.Essential,
            CategoryId = newItemRequest.CategoryId
        };
}