using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FestivalShoppingApi.Data.Dtos;

namespace FestivalShoppingApi.Data.Models;

public record Item
{
    [Key]
    public Guid ItemId { get; set; }

    [Required] 
    [MaxLength(100)] 
    public string Name { get; set; } = string.Empty;
    public string? Url { get; set; }
    public bool Essential { get; set; }
    [ForeignKey("Category")]
    public Guid CategoryId { get; set; }  
    public virtual Category Category { get; set; }  
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