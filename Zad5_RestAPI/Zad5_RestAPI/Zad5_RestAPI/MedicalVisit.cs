namespace Zad5_RestAPI;

public class MedicalVisit
{
    public int Id { get; set; }
    
    public DateOnly Date { get; set; }

    public int AnimalId { get; set; }

    public string Description { get; set;}

    public int Price { get; set; }
    
    
}
