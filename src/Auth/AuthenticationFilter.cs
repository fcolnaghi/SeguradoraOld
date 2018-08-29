using System.Linq;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Seguradora.src.Auth
{
    public class AuthenticationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext ctx)
        {
            string authKey = ctx.HttpContext.Request.Headers["Authorization"].SingleOrDefault();
 
            if (string.IsNullOrWhiteSpace(authKey))
                throw new System.UnauthorizedAccessException();
        }
    }
}