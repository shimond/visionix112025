using MyFirstWebApi.Contracts;
using MyFirstWebApi.Middlewares;
using MyFirstWebApi.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();
//builder.Services.AddTransient<IProductRepository, InMemoryTestProductRepository>();
//builder.Services.AddScoped<IProductRepository, InMemoryTestProductRepository>();
builder.Services.AddSingleton<IProductRepository, InMemoryTestProductRepository>();

var app = builder.Build();
app.UseShimonMiddleware();
app.MapControllers();


app.Run();

