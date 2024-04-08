using Microsoft.AspNetCore.Mvc;

namespace Zad5_RestAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ZwierzeController : ControllerBase
{
    private static readonly string[] Names = new[]
    {
        "Płotka", "Rorek", "Wiki", "Atlas", "Porek", "Wilk", "Wrak", "Coco", "Mina", "Pies"
    };
    private static readonly string[] Categories = new[]
    {
        "kot", "pies", "rybka", "hipopotam", "świnia", "Wilk"
    };
    
    private static readonly string[] Colors = new[]
    {
        "czerwony", "czarny", "biały", "żółty"
    };
    
    private static readonly Animal[] animals = Enumerable.Range(1, 5).Select(index => new Animal
        {
            Id = Random.Shared.Next(100),
            Name = Names[Random.Shared.Next(Names.Length)],
            Category = Categories[Random.Shared.Next(Categories.Length)],
            Mass = Random.Shared.Next()*100+5,
            Color = Colors[Random.Shared.Next(Colors.Length)],
        })
        .ToArray();

    private readonly ILogger<ZwierzeController> _logger;

    public ZwierzeController(ILogger<ZwierzeController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetTestForecast")]
    public IEnumerable<Animal> Get()
    {
        return animals;
    }
    
    public IEnumerable<Animal> Set()
    {
        Random random = new Random();
        return Enumerable.Range(1, 5).Select(index => new Animal
            {
                Id = Random.Shared.Next(100),
                Name = Names[Random.Shared.Next(Names.Length)],
                Category = Categories[Random.Shared.Next(Categories.Length)],
                Mass = random.Next()*100+2,
                Color = Colors[Random.Shared.Next(Colors.Length)],
            })
            .ToArray();
    }
}