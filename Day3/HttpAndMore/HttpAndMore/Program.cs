using HttpAndMore.Services;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

builder.Services.AddServiceDiscovery();

builder.Services.AddScoped<IPaymentClient, PaymentClient>();


builder.Services.AddHttpClient<IPaymentClient, PaymentClient>(client =>
{
    client.BaseAddress = new Uri("https://PaymentService");
    client.DefaultRequestHeaders.Add("X-test", "OOOOOO");
});
  


var app = builder.Build();
app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.MapGet("/TestPaymentService", async (IPaymentClient paymentClient) =>
{
    var payment = await paymentClient.Pay(100, "USD", "CreditCard");
    return Results.Ok(payment);
});
app.Run();
