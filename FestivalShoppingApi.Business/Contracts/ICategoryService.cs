using FestivalShoppingApi.Common.Models;
using FestivalShoppingApi.Data.Dtos;
using FestivalShoppingApi.Data.RequestModels;

namespace FestivalShoppingApi.Domain.Contracts;

public interface ICategoryService
{
   Task<Result<CategoryDto>> CreateCategory(Guid guid, NewCategoryRequest newCategoryRequest);
   Task<Result> DeleteCategory(Guid guid);
}