using Microsoft.AspNetCore.Mvc;

namespace Zad5_RestAPI.Controllers;

[ApiController]
[Route("api/MedicalVisit")]
public class MedicalVisitController : ControllerBase
{
    private static readonly string[] Desciptions = new[]
    {
        "Vaccination", "Control Visit", "Weighting", "Prescribing medicine"
    };
    private static List<MedicalVisit> _medicalVisits = Enumerable.Range(1, 6).Select(index => new MedicalVisit()
        {
            Id =index-1,
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            AnimalId = Random.Shared.Next(5),
            Description = Desciptions[Random.Shared.Next(Desciptions.Length)],
            Price =Random.Shared.Next(50,200)
        })
        .ToList();

    private readonly ILogger<MedicalVisitController> _logger;

    public MedicalVisitController(ILogger<MedicalVisitController> logger)
    {
        _logger = logger;
    }
   
    [HttpGet]
    public IActionResult GetVisits()
    {
        return Ok(_medicalVisits);
    }
    
    
    
    [HttpGet("{id:int}")]
    public IActionResult GetMedicalVisitsWithAnimal(int id)
    {
        List<MedicalVisit> tempMedicalList = new List<MedicalVisit>();
        for (int i = 0; i < _medicalVisits.Count; i++)
        {
            if (_medicalVisits[i].AnimalId==id){
                tempMedicalList.Add(_medicalVisits[i]);
            }
        }
        if (!tempMedicalList.Any())
            return NotFound($"There aren't appointments with animal having id {id}");
        return Ok(tempMedicalList);
    }

    
    [HttpPost(Name = "PostMedicalVisit")]
    public IActionResult Post(MedicalVisit medicalVisit)
    {
        _medicalVisits.Add(medicalVisit);
        return StatusCode(StatusCodes.Status201Created);
    }
}