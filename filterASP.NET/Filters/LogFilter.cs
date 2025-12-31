namespace filterASP.NET.Filters;

using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

public class LogFilter : IActionFilter
{
    private Stopwatch? _stopwatch;

    public void OnActionExecuting(ActionExecutingContext context)
    {
        _stopwatch = Stopwatch.StartNew();
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        _stopwatch?.Stop();

        var endpoint = context.HttpContext.Request.Path;
        var time = _stopwatch?.ElapsedMilliseconds;

        Console.WriteLine($"[LOG] Endpoint: {endpoint}, Time: {time} ms");
    }
}