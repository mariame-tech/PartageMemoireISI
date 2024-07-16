using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PMGateway;

[ApiController]
[Route("[controller]")]
[Authorize]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IActionResult Get()
    {
        var currentUser = HttpContext.User;

        var realmAccessRoles = currentUser.FindFirst("realm_access")?.Value;

        var roles = realmAccessRoles != null ? GetRolesFromRealmAccess(realmAccessRoles) : Enumerable.Empty<string>();

        var isAdmin = roles.Contains("Admin");

        var rng = new Random();
        var forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = rng.Next(-20, 55),
            Summary = Summaries[rng.Next(Summaries.Length)]
        }).ToArray();

        if (isAdmin)
        {
            return Ok(forecasts);
        }
        else
        {
            return Unauthorized();
        }
    }

    [HttpGet("roles")]
    public IEnumerable<string> GetRolesFromRealmAccess(string realmAccessRoles)
    {
        var json = JObject.Parse(realmAccessRoles);
        var rolesArray = json["roles"] as JArray;
        if (rolesArray != null)
        {
            return rolesArray.Select(r => r.ToString());
        }
        return Enumerable.Empty<string>();
    }
}
