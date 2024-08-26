using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using ResourceService.Config;


namespace ResourceService.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
      //  NotificationHub hub;
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [Authorize(Policy =Policies.Admin)]
        [HttpGet]
        [Route("forecast")]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [Authorize]
        [HttpGet]
        [Route("colors")]
        public IActionResult Colors()
        {
            var str= new string[]{ "red", "green", "blue" };
            return Ok(str);
        }

        [Authorize(Policy = Policies.Manager)]
        [HttpGet]
        [Route("seasons")]
        public IActionResult Seasons()
        {
            var str = new string[] { "winter", "spring", "summer","autumn" };
            return Ok(str);
        }
    }
}
