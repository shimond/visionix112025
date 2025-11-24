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

var retryPolicy =  HttpPolicyExtensions.HandleTransientHttpError().WaitAndRetryAsync(3, x =>
{
    return TimeSpan.FromSeconds(1);
});

builder.Services.AddHttpClient<IPaymentClient, PaymentClient>(client =>
{
    client.BaseAddress = new Uri("https://PaymentService");

}).AddPolicyHandler(retryPolicy)
  .AddServiceDiscovery();


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
