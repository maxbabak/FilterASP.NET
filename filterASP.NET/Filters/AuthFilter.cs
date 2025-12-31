namespace filterASP.NET.Filters;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class AuthFilter : IAuthorizationFilter
{
    private const string ApiKey = "SECRET123";

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        if (!context.HttpContext.Request.Headers.TryGetValue("X-API-KEY", out var key)
            || key != ApiKey)
        {
            context.Result = new UnauthorizedObjectResult("Invalid or missing API key");
        }
    }
}