using FestivalShoppingApi.Common.Dtos;
using FestivalShoppingApi.Common.Models;
using FestivalShoppingApi.Data.Models;

namespace FestivalShoppingApi.Domain.Contracts;

public interface IShopperService
{
    Task<Result<List<ShopperDto>>> GetShoppers(Guid shoppingListId);
    Task<Result<ShopperDto?>> GetShopper(Guid personId);
    Task<Result<Guid>> AddShopper(Guid shoppingListId, string name);
    Task<Result> RemoveShopper(Guid personId);
    Task<Result> UpdateItemStatus(Guid personId, Guid itemId, AcquisitionStatus status);
} 