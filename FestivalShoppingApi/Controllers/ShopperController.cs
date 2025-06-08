using FestivalShoppingApi.Common.Dtos;
using FestivalShoppingApi.Common.Models;
using FestivalShoppingApi.Data.Models;
using FestivalShoppingApi.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FestivalShoppingApi.Controllers;

public class ShopperController(IShopperService shopperService) : BaseController
{
    [HttpGet("shopping-list/{shoppingListId:guid}/shoppers")]
    public async Task<ActionResult<Result<IEnumerable<ShopperDto>>>> GetShoppers(Guid shoppingListId)
    {
        var result = await shopperService.GetShoppers(shoppingListId);
        return ResolveResult(result);
    }
    
    [HttpGet("shopper/{shopperId:guid}")]
    public async Task<ActionResult<Result<ShopperDto>>> GetShopper(Guid shopperId)
    {
        var result = await shopperService.GetShopper(shopperId);
        return ResolveResult(result);
    }
    
    [HttpPost("shopping-list/{shoppingListId:guid}/shopper")]
    public async Task<ActionResult<Result<Guid>>> AddShopper(Guid shoppingListId, [FromBody] string name)
    {
        var result = await shopperService.AddShopper(shoppingListId, name);
        return ResolveResult(result);
    }
    
    [HttpDelete("shopper/{shopperId:guid}")]
    public async Task<ActionResult<Result>> RemoveShopper(Guid shopperId)
    {
        var result = await shopperService.RemoveShopper(shopperId);
        return ResolveResult(result);
    }
    
    [HttpPut("shopper/{shopperId:guid}/items/{itemId:guid}/status")]
    public async Task<ActionResult<Result>> UpdateItemStatus(Guid shopperId, Guid itemId, [FromBody] AcquisitionStatus status)
    {
        var result = await shopperService.UpdateItemStatus(shopperId, itemId, status);
        return ResolveResult(result);
    }
} 