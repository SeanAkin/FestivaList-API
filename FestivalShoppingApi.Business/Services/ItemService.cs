using System.Net;
using FestivalShoppingApi.Common.Models;
using FestivalShoppingApi.Data;
using FestivalShoppingApi.Data.RequestModels;
using FestivalShoppingApi.Domain.Contracts;

namespace FestivalShoppingApi.Domain.Services;

public class ItemService(FestivalShoppingContext context) : IItemService
{
    public async Task<Result> CreateItem(NewItemRequest newItemRequest)
    {
        var category = await context.Categories.FindAsync(newItemRequest.CategoryId);
        if (category == null)
        {
            return Result.FailureResult("Category not found", HttpStatusCode.NotFound);
        }
        
        category.Items.Add(newItemRequest.ToItem());
        await context.SaveChangesAsync();
        
        return Result.SuccessResult();
    }

    public async Task<Result> DeleteItem(Guid categoryId, Guid itemId)
    {
        var item = await context.Items.FindAsync(itemId);
        if (item == null || item.CategoryId != categoryId)
        {
            return Result.FailureResult("Item not found", HttpStatusCode.NotFound);
        }
        
        context.Items.Remove(item);
        await context.SaveChangesAsync();
        
        return Result.SuccessResult();
    }
}