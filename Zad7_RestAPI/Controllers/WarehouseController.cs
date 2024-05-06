using Microsoft.AspNetCore.Mvc;

namespace Zad5_RestAPI.Controllers;

[ApiController]
[Route("api/animal")]
public class WarehouseController : ControllerBase
{
    
    private static List<Warehouse> _warehouses = Warehouse.extent;

    private readonly ILogger<WarehouseController> _logger;

    public WarehouseController(ILogger<WarehouseController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWarehouses")]
    public IActionResult GetWarehouses()
    {
        return Ok(_warehouses);
    }
    
    [HttpGet("{id:int}")]
    public IActionResult GetWarehouses(int id)
    {
        var warehouse = _warehouses.FirstOrDefault(wa => wa.IdWarehouse == id);
        if (warehouse == null)
            return NotFound($"Warehouse with id {id} was not found");
        return Ok(_warehouses[id]);
    }
    
    [HttpPost(Name = "PostWarehouse")]
    public IActionResult Post(Warehouse warehouse)
    {
        _warehouses.Add(warehouse);
        return StatusCode(StatusCodes.Status201Created);
    }
    
    [HttpPut("{id:int}")]
    public IActionResult PutAnimal(int id, Warehouse warehouse)
    {
        var warehouseToEdit = _warehouses.FirstOrDefault(wa => wa.IdWarehouse == id);
        if (warehouseToEdit == null)
            return NotFound($"Warehouse with id {id} was not found");
        if(id!=warehouse.IdWarehouse)
            return StatusCode(404);
        
        _warehouses.Remove(warehouseToEdit);
        _warehouses.Add(warehouse);
        return NoContent();
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult DeleteWarehouse(int id)
    {
        var warehouse= _warehouses.FirstOrDefault(wa => wa.IdWarehouse == id);
        if (warehouse== null)
            return NotFound($"Warehouse with id {id} was not found");
        _warehouses.Remove(warehouse);
        return NoContent();
    }
}