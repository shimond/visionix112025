using Microsoft.AspNetCore.OutputCaching;
using MyFirstWebApi.Models;
using System.Threading.Tasks;

namespace MyFirstWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    [HttpGet]
    [OutputCache(Duration =400)]

    public async Task<string> GetTime()
    {
        Thread.Sleep(3000);
        return DateTime.Now.ToString("O");
    }
}


