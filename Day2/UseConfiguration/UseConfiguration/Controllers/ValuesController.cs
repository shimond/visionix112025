using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using UseConfiguration.Model.Config;
using UseConfiguration.Services;

namespace UseConfiguration.Controllers
{

    //Ioptions
    //IoptionsSnapshot
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController(IConfiguration configuration,
        VxConfigurationManager configurationManager, 
        IOptionsSnapshot<RedisConfiguration> redisConfiguration, 
        IOptionsSnapshot<MotorsConfiguration> motorsConfiguration) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var mySetting = configuration["TestName"];
            return Ok(mySetting);
        }

        [HttpGet("complex")]
        public IActionResult GetComplex()
        {
            RedisConfiguration redis = redisConfiguration.Value;
            return Ok(redis);
        }

        [HttpGet("motors")]
        public IActionResult GetMotors()
        {
            MotorsConfiguration motors = motorsConfiguration.Value;
            return Ok(motors);
        }

        [HttpGet("motors/active")]
        public IActionResult GetActiveMotors()
        {
            var activeMotors = motorsConfiguration.Value.Motors
                .Where(m => m.IsActive)
                .ToList();
            return Ok(activeMotors);
        }

        [HttpPatch("motor/{id}/{name}")]
        public async Task<IActionResult> UpdateMotorName(string id, string name)
        {
            await configurationManager.UpdateName(id, name);
            return NoContent();
        }
    }
}
