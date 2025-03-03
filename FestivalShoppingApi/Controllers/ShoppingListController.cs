using FestivalShoppingApi.Common.Models;
using FestivalShoppingApi.Data;
using FestivalShoppingApi.Data.Dtos;
using FestivalShoppingApi.Data.Models;
using FestivalShoppingApi.Data.RequestModels;
using FestivalShoppingApi.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;

namespace FestivalShoppingApi.Controllers
{
    [ApiController]
    [Route("shopping-list")]
    public class ShoppingListController : BaseController
    {
        private readonly IShoppingListService _shoppingListService;
        private readonly FestivalShoppingContext _context;
        public ShoppingListController(IShoppingListService shoppingListService, FestivalShoppingContext context)
        {
            _shoppingListService = shoppingListService;
            _context = context;
        }

        [HttpPost(Name = "")]
        [EnableRateLimiting("Create-New-List")]
        public async Task<ActionResult<Result<Guid>>> CreateNewShoppingList(string name)
            => ResolveResult(await _shoppingListService.CreateShoppingList(name));
        
        [HttpGet("{shoppingListId}")]
        public async Task<ActionResult<Result<ShoppingListDto?>>> Get(Guid shoppingListId)
            => ResolveResult(await _shoppingListService.GetShoppingList(shoppingListId));

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ShoppingListDto>>> GetAllShoppingList()
        {
            var shoppingList = await _context.ShoppingLists.
                Include(c => c.Categories)
                .ThenInclude(c => c.Items).ToListAsync();
            
            var shoppingListDto = shoppingList.Select(sl => sl.ConvertToDto()).ToList();
            
            return Ok(shoppingListDto);
        }
    }
}
