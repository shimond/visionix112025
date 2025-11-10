using MyFirstWebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddControllers();
//builder.Services.AddOpenApi();

var app = builder.Build();

app.UseStaticFiles();

app.Use(async (context, next) => { 
    await context.Response.WriteAsync("  Middleware A 1: Before   ");
    await next();
    await context.Response.WriteAsync("  Middleware A 2: Before   ");
});

app.Use(async (context, next) => {
    await context.Response.WriteAsync("   Middleware B 1: Before   ");
    await next();
    await context.Response.WriteAsync("   Middleware B 2: Before   ");
});

app.Use(async (context, next) => {
    await context.Response.WriteAsync("  Middleware C 1: Before  ");
    await next();
    await context.Response.WriteAsync("  Middleware C 2: Before  ");
});

app.Run(async (context) =>
{
    await context.Response.WriteAsync("Hello, World!");
});

app.Run();



var names = new string[] { "Alice", "Bob", "Charlie", "David", "Eve" };
var shortNames = names.Where(name => name.Length <= 3);
var upperNames = names.Select(name => name.ToUpper());
var FirstLetterNames = names.Select(name => name[0]);   
var namesOrderd = names.OrderBy(name => name.Length).ThenBy(name => name);




























