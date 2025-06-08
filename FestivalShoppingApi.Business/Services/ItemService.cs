using System.Net;
using FestivalShoppingApi.Common.Dtos;
using FestivalShoppingApi.Common.Models;
using FestivalShoppingApi.Data;
using FestivalShoppingApi.Data.RequestModels;
using FestivalShoppingApi.Domain.Contracts;

namespace FestivalShoppingApi.Domain.Services;

public class ItemService(FestivalShoppingContext context) : IItemService
{
    public async Task<Result<ItemDto>> CreateItem(NewItemRequest newItemRequest)
    {
        var category = await context.Categories.FindAsync(newItemRequest.CategoryId);
        if (category == null)
        {
            return Result<ItemDto>.FailureResult("Category not found", HttpStatusCode.NotFound);
        }
        var item = newItemRequest.ToItem();
        category.Items.Add(item);
        await context.SaveChangesAsync();
        
        return Result<ItemDto>.SuccessResult(item.ConvertToDto());
    }

    public async Task<Result> DeleteItem(Guid itemId)
    {
        var item = await context.Items.FindAsync(itemId);
        if (item == null)
        {
            return Result.FailureResult("Item not found", HttpStatusCode.NotFound);
        }
        
        context.Items.Remove(item);
        await context.SaveChangesAsync();
        
        return Result.SuccessResult();
    }
}