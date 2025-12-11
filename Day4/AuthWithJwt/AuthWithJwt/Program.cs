using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<Program>>();
            logger.LogInformation("JwtBearer OnMessageReceived: Path {Path}, AuthHeader present: {HasAuth}", context.HttpContext.Request.Path, context.Request.Headers.ContainsKey("Authorization"));
            return Task.CompletedTask;
        },
        OnTokenValidated = context =>
        {
            var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<Program>>();
            logger.LogInformation("JwtBearer OnTokenValidated: Name {Name}, AuthType {AuthType}", context.Principal?.Identity?.Name ?? "(no name)", context.Principal?.Identity?.AuthenticationType ?? "(none)");
            return Task.CompletedTask;
        },
        OnChallenge = context =>
        {
            var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<Program>>();
            logger.LogWarning("JwtBearer OnChallenge: Scheme {Scheme}, Error {Error}, Description {Description}", context.Scheme.Name, context.Error, context.ErrorDescription);
            return Task.CompletedTask;
        },
        OnAuthenticationFailed = context =>
        {
            var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<Program>>();
            logger.LogError(context.Exception, "JwtBearer OnAuthenticationFailed: {Message}", context.Exception.Message);
            return Task.CompletedTask;
        },
        OnForbidden = context =>
        {
            var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<Program>>();
            logger.LogWarning("JwtBearer OnForbidden: User {User}, Path {Path}", context.HttpContext.User?.Identity?.Name ?? "(anonymous)", context.HttpContext.Request.Path);
            return Task.CompletedTask;
        }
    };
});
builder.Services.AddAuthorization(x => x.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin")));

builder.Services.AddHttpContextAccessor();
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/All", () => "Hello World!");

var ep = app.MapGet("/Auth", (IHttpContextAccessor httpContextAccessor) =>
{
    return Results.Ok("Auth end point");
}).RequireAuthorization();


app.MapGet("/Admin-Auth", (IHttpContextAccessor httpContextAccessor) =>
{
   return Results.Ok("Admin-auth end point");
}).RequireAuthorization("AdminPolicy");




//if (true)
//{
//    ep.RequireAuthorization("");
//}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.Run();
