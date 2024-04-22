using Microsoft.AspNetCore.Mvc;

namespace Zad5_RestAPI.Controllers;

[ApiController]
[Route("api/animal")]
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
    
    private static List<Animal> _animals = Enumerable.Range(1, 6).Select(index => new Animal
        {
            Id =index-1,
            Name = Names[Random.Shared.Next(Names.Length)],
            Category = Categories[Random.Shared.Next(Categories.Length)],
            Mass = Random.Shared.Next(1,40),
            Color = Colors[Random.Shared.Next(Colors.Length)],
        })
        .ToList();

    private readonly ILogger<AnimalController> _logger;

    public AnimalController(ILogger<AnimalController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetAnimals")]
    public IActionResult GetAnimals()
    {
        return Ok(_animals);
    }
    
    [HttpGet("{id:int}")]
    public IActionResult GETAnimals(int id)
    {
        var animal = _animals.FirstOrDefault(an => an.Id == id);
        if (animal == null)
            return NotFound($"Animal with id {id} was not found");
        return Ok(_animals[id]);
    }
    
    [HttpPost(Name = "PostAnimal")]
    public IActionResult Post(Animal animal)
    {
        _animals.Add(animal);
        return StatusCode(StatusCodes.Status201Created);
    }
    
    [HttpPut("{id:int}")]
    public IActionResult PutAnimal(int id, Animal animal)
    {
        var animalToEdit = _animals.FirstOrDefault(an => an.Id == id);
        if (animalToEdit == null)
            return NotFound($"Animal with id {id} was not found");
        if(id!=animal.Id)
            return StatusCode(404);
        
        _animals.Remove(animalToEdit);
        _animals.Add(animal);
        return NoContent();
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animal= _animals.FirstOrDefault(an => an.Id == id);
        if (animal== null)
            return NotFound($"Animal with id {id} was not found");
        _animals.Remove(animal);
        return NoContent();
    }
}