namespace TutorTracker.Api.CustomResults;

public class Ok : IResult
{
    private readonly object _obj;
    
    public Ok(object obj)
    {
        _obj = obj;
    }

    public Task ExecuteAsync(HttpContext httpContext)
    {
        httpContext.Response.StatusCode = 200;
        httpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
        return httpContext.Response.WriteAsJsonAsync(_obj);
    }
}