using FestivalShoppingApi.Common.Dtos;
using FestivalShoppingApi.Common.Models;

namespace FestivalShoppingApi.Domain.Contracts;

public interface IShoppingListService
{
    Task<Result<ShoppingListDto?>> GetShoppingList(Guid guid);
    Task<Result<Guid>> CreateShoppingList(string name);
    Task<Result> DeleteShoppingList(Guid guid);
    Task<bool> Exists(Guid guid);
}