var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"))
    .AddServiceDiscoveryDestinationResolver();

builder.Services.AddOpenApi();

var app = builder.Build();
app.MapDefaultEndpoints();
app.MapReverseProxy();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.Run();

