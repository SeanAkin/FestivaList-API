using FestivalShoppingApi.Common.Models;
using FestivalShoppingApi.Data.Dtos;
using FestivalShoppingApi.Data.RequestModels;

namespace FestivalShoppingApi.Domain.Contracts;

public interface IItemService
{
    public Task<Result<ItemDto>> CreateItem(NewItemRequest newItemRequest);
    public Task<Result> DeleteItem(Guid itemId);
}