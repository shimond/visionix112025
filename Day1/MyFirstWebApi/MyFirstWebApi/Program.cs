using MyFirstWebApi.Middlewares;
using MyFirstWebApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddOutputCache(); // in memory cache
var app = builder.Build();

app.UseOutputCache();
app.MapControllers();


app.Run();


// Status codes:
// 200, 201, 202, 204 - OK
// 400,401, 404, 405, 409 - Client error
// 500 - server error



// GET  - API/PRODUCTS/PAGE/3/4/OB-{FIELD}?FULL=1&SORT=DESC
// POST -  Insert  - 201 - body object to insert
// DELTE - Delete - body empty
// PUT - Update - body object to update - full update
// PATCH - Partial update - body object with fields to update
// OPTIONS - Get supported methods
