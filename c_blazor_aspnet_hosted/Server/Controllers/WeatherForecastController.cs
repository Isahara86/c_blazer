using Microsoft.AspNetCore.Mvc;
using c_blazor_aspnet_hosted.Shared;
using c_scharp_companies.Models;
using Microsoft.EntityFrameworkCore;
using c_scharp_companies.Data;

namespace c_blazor_aspnet_hosted.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{

    private readonly ApplicationDbContext _context;
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {

        await _addAddress();
        var addressesCount = await _getAddrssesCount();


        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)],
            TotalAddressesCount = addressesCount

        })
        .ToArray();
    }


    private async Task _addAddress()
    {
        _context.Address.Add(new Address()
        {
            Name = "New Address" + Random.Shared.Next(-20, 55)

        });
        await _context.SaveChangesAsync();
    }

    private async Task<int> _getAddrssesCount()
    {
        var totalCount = await _context.Address.CountAsync();

        return totalCount;
    }
}

