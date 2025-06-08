using FestivalShoppingApi.Data.Models;

namespace FestivalShoppingApi.Common.Dtos;

public record ItemStatusDto
{
    public Guid ItemStatusId { get; set; }
    public Guid PersonId { get; set; }
    public Guid ItemId { get; set; }
    public string ItemName { get; set; } = string.Empty;
    public AcquisitionStatus Status { get; set; }
} 

public static class PersonItemExtensions
{
    public static ItemStatusDto ConvertToDto(this ItemStatus itemStatus)
    {
        return new ItemStatusDto
        {
            ItemStatusId = itemStatus.ItemStatusId,
            PersonId = itemStatus.ShopperId,
            ItemId = itemStatus.ItemId,
            ItemName = itemStatus.Item.Name,
            Status = itemStatus.Status
        };
    }
} 