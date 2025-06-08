using System.Net;
using FestivalShoppingApi.Common.Dtos;
using FestivalShoppingApi.Common.Models;
using FestivalShoppingApi.Data;
using FestivalShoppingApi.Data.Models;
using FestivalShoppingApi.Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FestivalShoppingApi.Domain.Services;

public class ShoppingListService(FestivalShoppingContext context) : IShoppingListService
{
    public async Task<Result<ShoppingListDto?>> GetShoppingList(Guid shoppingListId)
    {
        var shoppingList = await context.ShoppingLists
            .Include(sl => sl.Categories)
            .ThenInclude(c => c.Items)
            .FirstOrDefaultAsync(sl => sl.GuidId == shoppingListId);

        return shoppingList == null ? 
            Result<ShoppingListDto?>.FailureResult("Shopping list not found", HttpStatusCode.NotFound) : 
            Result<ShoppingListDto?>.SuccessResult(shoppingList.ConvertToDto());
    }

    public async Task<Result<Guid>> CreateShoppingList(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return Result<Guid>.FailureResult("Name cannot be empty", HttpStatusCode.BadRequest);
        }
        
        var newShoppingList = new ShoppingList { Name = name };
        
        await context.AddAsync(newShoppingList);
        await context.SaveChangesAsync();

        return Result<Guid>.SuccessResult(newShoppingList.GuidId);
    }
    
    public async Task<bool> Exists(Guid guid)
        => await context.ShoppingLists.AnyAsync(x => x.GuidId == guid);

    public async Task<Result> DeleteShoppingList(Guid guid)
    {
        var shoppingList = await context.ShoppingLists.FindAsync(guid);
        if (shoppingList == null)
        {
            return Result.FailureResult("Shopping list not found", HttpStatusCode.NotFound);
        }
        
        context.ShoppingLists.Remove(shoppingList);
        await context.SaveChangesAsync();
        
        return Result.SuccessResult();
    }
}