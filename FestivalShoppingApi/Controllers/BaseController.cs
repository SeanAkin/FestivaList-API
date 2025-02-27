using FestivalShoppingApi.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace FestivalShoppingApi.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected ActionResult ResolveResult<T>(Result<T> result)
            => StatusCode(result.ResponseCode, result);
        
        protected ActionResult ResolveResult(Result result)
            => StatusCode(result.ResponseCode, result);
    }
}