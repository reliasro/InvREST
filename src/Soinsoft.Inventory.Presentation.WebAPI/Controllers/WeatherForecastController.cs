using Microsoft.AspNetCore.Mvc;
using Soinsoft.Inventory.Domain.Contracts;
using Soinsoft.Inventory.Domain.Model;
using MediatR;
using Soinsoft.Inventory.Application.Commands.Product.Commands;

namespace Soinsoft.Inventory.Presentation.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IRepository<Product> _productRepo;
    private readonly IMediator _mediator;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IRepository<Product> productRepo, IMediator mediator)
    {
        _logger = logger;
        _productRepo = productRepo;
        _mediator = mediator;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        _mediator.Send(new AddProductCmd());
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
