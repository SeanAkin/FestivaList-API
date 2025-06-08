using System.Net;
using FestivalShoppingApi.Common.Dtos;
using FestivalShoppingApi.Common.Models;
using FestivalShoppingApi.Data;
using FestivalShoppingApi.Data.Models;
using FestivalShoppingApi.Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FestivalShoppingApi.Domain.Services;

public class ShopperService(FestivalShoppingContext context) : IShopperService
{
    public async Task<Result<List<ShopperDto>>> GetShoppers(Guid shoppingListId)
    {
        if (!await context.ShoppingLists.AnyAsync(sl => sl.GuidId == shoppingListId))
        {
            return Result<List<ShopperDto>>.FailureResult("Shopping list not found", HttpStatusCode.NotFound);
        }

        var people = await context.Shoppers
            .Include(p => p.ItemStatuses)
            .ThenInclude(pi => pi.Item)
            .Where(p => p.ShoppingListId == shoppingListId)
            .ToListAsync();

        return Result<List<ShopperDto>>.SuccessResult(
            people.Select(p => p.ConvertToDto()).ToList());
    }

    public async Task<Result<ShopperDto?>> GetShopper(Guid personId)
    {
        var person = await context.Shoppers
            .Include(p => p.ItemStatuses)
            .ThenInclude(pi => pi.Item)
            .FirstOrDefaultAsync(p => p.PersonId == personId);

        return person == null ?
            Result<ShopperDto?>.FailureResult("Person not found", HttpStatusCode.NotFound) :
            Result<ShopperDto?>.SuccessResult(person.ConvertToDto());
    }

    public async Task<Result<Guid>> AddShopper(Guid shoppingListId, string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return Result<Guid>.FailureResult("Name cannot be empty", HttpStatusCode.BadRequest);
        }

        if (!await context.ShoppingLists.AnyAsync(sl => sl.GuidId == shoppingListId))
        {
            return Result<Guid>.FailureResult("Shopping list not found", HttpStatusCode.NotFound);
        }

        var newPerson = new Shopper
        {
            PersonId = Guid.NewGuid(),
            Name = name,
            ShoppingListId = shoppingListId
        };

        await context.Shoppers.AddAsync(newPerson);
        await context.SaveChangesAsync();
        
        return Result<Guid>.SuccessResult(newPerson.PersonId);
    }

    public async Task<Result> RemoveShopper(Guid personId)
    {
        var person = await context.Shoppers
            .Include(p => p.ItemStatuses)
            .FirstOrDefaultAsync(p => p.PersonId == personId);
            
        if (person == null)
        {
            return Result.FailureResult("Person not found", HttpStatusCode.NotFound);
        }
        
        context.ItemStatuses.RemoveRange(person.ItemStatuses);
        
        context.Shoppers.Remove(person);
        await context.SaveChangesAsync();
        
        return Result.SuccessResult();
    }

    public async Task<Result> UpdateItemStatus(Guid personId, Guid itemId, AcquisitionStatus status)
    {
        var personItem = await context.ItemStatuses
            .FirstOrDefaultAsync(pi => pi.ShopperId == personId && pi.ItemId == itemId);
            
        if (personItem == null)
        {
            var person = await context.Shoppers.FindAsync(personId);
            var item = await context.Items.FindAsync(itemId);
            
            if (person == null)
            {
                return Result.FailureResult("Person not found", HttpStatusCode.NotFound);
            }
            
            if (item == null)
            {
                return Result.FailureResult("Item not found", HttpStatusCode.NotFound);
            }
            
            personItem = new ItemStatus
            {
                ShopperId = personId,
                ItemId = itemId,
                Status = status
            };
            
            await context.ItemStatuses.AddAsync(personItem);
        }
        else
        {
            personItem.Status = status;
            context.ItemStatuses.Update(personItem);
        }
        
        await context.SaveChangesAsync();
        
        return Result.SuccessResult();
    }
} 