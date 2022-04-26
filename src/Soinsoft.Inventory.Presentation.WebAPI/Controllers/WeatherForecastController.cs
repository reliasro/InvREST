using Microsoft.AspNetCore.Mvc;
using Soinsoft.Inventory.Domain.Contracts;
using Soinsoft.Inventory.Domain.Model;
using MediatR;
using Soinsoft.Inventory.Application.Commands.FProduct.Commands;

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
        AddProductCmd cmd = new(){
            Description="Probando",
            Maximun=100,
            Minimum=25,
            Price=2500,
            Cost=1300,
            Unit="Boxes"
         };        
        var result = _mediator.Send(cmd);

        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
