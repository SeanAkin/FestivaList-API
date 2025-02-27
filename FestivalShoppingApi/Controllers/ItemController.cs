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
    [Route("Create")]
    public async Task<ActionResult<IEnumerable<Item>>> CreateItem(NewItemRequest newItemRequest)
        => ResolveResult(await itemService.CreateItem(newItemRequest));

    [HttpDelete]
    [Route("Delete")]
    public async Task<ActionResult> DeleteItem(Guid categoryId, Guid itemId)
        => ResolveResult(await itemService.DeleteItem(categoryId, itemId));
}