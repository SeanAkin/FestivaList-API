using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FestivalShoppingApi.Data.Models;

public class ItemStatus
{
    [Key]
    public Guid ItemStatusId { get; set; }

    [ForeignKey(nameof(Shopper))]
    public Guid ShopperId { get; set; }

    [ForeignKey(nameof(Item))]
    public Guid ItemId { get; set; }

    public AcquisitionStatus Status { get; set; }

    public virtual Shopper Shopper { get; set; }
    public virtual Item Item { get; set; }
}


public enum AcquisitionStatus
{
    NotAcquiring = 0,
    Acquired = 1,
}