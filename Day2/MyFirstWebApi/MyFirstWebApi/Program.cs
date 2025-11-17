using Microsoft.EntityFrameworkCore;
using MyFirstWebApi.Apis;
using MyFirstWebApi.DataBase;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
builder.Services.AddScoped<IProductRepository, DbProductRepository>();
builder.Services.AddDbContext<VxDataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("vxDbConnection")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<VxDataContext>();
    await dbContext.Database.EnsureCreatedAsync();
}

app.UseShimonMiddleware();

app.MapProductApis(app.Configuration);

app.Run();


