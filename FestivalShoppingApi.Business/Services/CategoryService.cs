using System.Net;
using FestivalShoppingApi.Common.Models;
using FestivalShoppingApi.Data;
using FestivalShoppingApi.Data.Dtos;
using FestivalShoppingApi.Data.Models;
using FestivalShoppingApi.Data.RequestModels;
using FestivalShoppingApi.Domain.Contracts;

namespace FestivalShoppingApi.Domain.Services;

public class CategoryService(FestivalShoppingContext context, IShoppingListService shoppingListService)
    : ICategoryService
{
    public async Task<Result<CategoryDto>> CreateCategory(Guid guid, NewCategoryRequest newCategoryRequest)
    {
        var shoppingListExists = await shoppingListService.Exists(guid);
        if (shoppingListExists is false)
        {
            return Result<CategoryDto>.FailureResult("Shopping list doesn't exist", HttpStatusCode.NotFound);
        }
    
        var categoryToAdd = new Category()
        {
            Name = newCategoryRequest.Name,
            ShoppingListId = guid
        };
    
        await context.AddAsync(categoryToAdd);
        await context.SaveChangesAsync();
    
        return Result<CategoryDto>.SuccessResult(categoryToAdd.ConvertToDto());
    }

    public async Task<Result> DeleteCategory(Guid guid)
    {
        var category = await context.Categories.FindAsync(guid);
        if (category is null)
        {
            return Result.FailureResult("Category doesn't exist", HttpStatusCode.NotFound);
        }
        
        context.Categories.Remove(category);
        await context.SaveChangesAsync();
        
        return Result.SuccessResult();
    }
}