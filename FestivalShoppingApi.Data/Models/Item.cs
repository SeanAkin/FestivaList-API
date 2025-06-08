using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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