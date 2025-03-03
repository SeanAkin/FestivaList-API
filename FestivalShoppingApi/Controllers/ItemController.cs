using FestivalShoppingApi.Data.Models;
using FestivalShoppingApi.Data.RequestModels;
using FestivalShoppingApi.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FestivalShoppingApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemController(IItemService itemService) : BaseController
{
    [HttpPost]
    [Route("")]
    public async Task<ActionResult<Item>> CreateItem(NewItemRequest newItemRequest)
        => ResolveResult(await itemService.CreateItem(newItemRequest));

    [HttpDelete]
    [Route("{itemId}")]
    public async Task<ActionResult> DeleteItem(Guid itemId)
        => ResolveResult(await itemService.DeleteItem(itemId));
}