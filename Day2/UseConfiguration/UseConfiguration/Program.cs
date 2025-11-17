using UseConfiguration.Model.Config;
using UseConfiguration.Services;

var builder = WebApplication.CreateBuilder(args);

// Add motors.json configuration file
builder.Configuration.AddJsonFile("motors.json", optional: false, reloadOnChange: true);

builder.Services.Configure<RedisConfiguration>(builder.Configuration.GetSection("Redis"));
builder.Services.Configure<MotorsConfiguration>(builder.Configuration);

builder.Services.AddHostedService<HostedServiceEx>();
builder.Services.AddScoped<VxConfigurationManager>();
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
