using Microsoft.AspNetCore.Mvc;

namespace Zad5_RestAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AnimalController : ControllerBase
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
    
    private static readonly Animal[] animals = Enumerable.Range(1, 6).Select(index => new Animal
        {
            Id =index-1,
            Name = Names[Random.Shared.Next(Names.Length)],
            Category = Categories[Random.Shared.Next(Categories.Length)],
            Mass = Random.Shared.Next(1,40),
            Color = Colors[Random.Shared.Next(Colors.Length)],
        })
        .ToArray();

    private readonly ILogger<AnimalController> _logger;

    public AnimalController(ILogger<AnimalController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetAnimals")]
    public IEnumerable<Animal> GET(int id)
    {
        return animals;
    }
    
    
    [HttpPut(Name = "PutAnimal")]
    public IEnumerable<Animal> PUT(string name, string category, int mass, string color)
    {
        animals.Append(new Animal
        {
            Id = animals.Length,
            Name=name,
            Category = category,
            Mass = mass,
            Color = color
        });
        return animals;
    }
}