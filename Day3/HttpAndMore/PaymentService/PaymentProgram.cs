var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();



app.MapPost("/pay", (PaymentRequest p) => p);

app.Run();

public record  PaymentRequest(decimal Amount, string Currency, string PaymentMethod);
