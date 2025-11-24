var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();




app.MapGet("/GetOS", () =>
{
    return Environment.OSVersion;
});

app.MapGet("/GetFileContent", () =>
{
    return System.IO.File.ReadAllText("c:\\temp\\vin.txt");
});

app.Run();

