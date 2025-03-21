using FestivalShoppingApi.Common.Models;
using FestivalShoppingApi.Data.Dtos;
using FestivalShoppingApi.Data.RequestModels;
using FestivalShoppingApi.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace FestivalShoppingApi.Controllers;

[ApiController]
[Route("categories")]
[EnableRateLimiting("Default")]
public class CategoryController : BaseController
{
    private readonly ICategoryService _categoryService;
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    
    [HttpPost("{shoppingListId}")]
    public async Task<ActionResult<Result<CategoryDto>>> CreateCategory(Guid shoppingListId, [FromBody] NewCategoryRequest newCategoryRequest)
        => ResolveResult(await _categoryService.CreateCategory(shoppingListId, newCategoryRequest));

    [HttpDelete("{categoryId}")]
    public async Task<ActionResult<Result>> DeleteCategory(Guid categoryId)
        => ResolveResult(await _categoryService.DeleteCategory(categoryId));
}