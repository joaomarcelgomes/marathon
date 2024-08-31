using Backend.Domain.Auth.Auth;

namespace Backend.Domain.Api.Middlewares;

public class TokenValidationMiddleware(RequestDelegate next)
{
    private readonly List<string> _routesToIgnore = ["user/create", "user/login", "swagger"];
    
    public async Task InvokeAsync(HttpContext context)
    {
        var path = context.Request.Path.Value;

        if (path != null && _routesToIgnore.Any(x => path.Contains(x)))
        {
            await next(context);
            return;
        }

        var token = context.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();
        
        var tokenService = new TokenService();

        try
        {
            if (string.IsNullOrWhiteSpace(token) || !tokenService.Validate(token))
                throw new UnauthorizedAccessException();
        }
        catch (Exception)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.ContentType = "application/json";

            var response = new
            {
                success = false,
                message = "Usuário não autorizado"
            };

            await context.Response.WriteAsJsonAsync(response);
            return;
        }

        await next(context);
    }
}