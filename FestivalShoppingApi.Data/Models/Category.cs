using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FestivalShoppingApi.Data.Dtos;

namespace FestivalShoppingApi.Data.Models;

public class Category
{
    [Key]
    public Guid CategoryId { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    [ForeignKey("ShoppingList")]
    public Guid ShoppingListId { get; set; }
    public virtual ShoppingList ShoppingList { get; set; }  
    public virtual List<Item> Items { get; set; } = new List<Item>();
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