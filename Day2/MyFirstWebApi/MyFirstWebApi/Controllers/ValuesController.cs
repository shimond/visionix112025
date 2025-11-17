using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ValuesController (IConfiguration configuration) : ControllerBase
{
    public string? Get()
    {
        return configuration["TestName"];
    }
}
