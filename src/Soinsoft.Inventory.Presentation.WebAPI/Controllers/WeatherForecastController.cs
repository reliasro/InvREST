using Microsoft.AspNetCore.Mvc;
using Soinsoft.Inventory.Application.Commands.FProduct.Commands;
using MediatR;
using AutoMapper;

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
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IMapper mapper, IMediator mediator)
    {
        _logger = logger;
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        AddProductCmd cmd = new(){
            Description="",
            Maximun=150,
            Minimum=3,
            Price=6500,
            Cost=1500,
            Unit="Unit"
         };        
        var result = _mediator.Send(cmd);
        Console.WriteLine(result);

        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
