using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace Zad5_RestAPI.Controllers;

[ApiController]
[Route("api/animal")]
public class Product_WarehouseController : ControllerBase
{
    
    private static List<Product_Warehouse> _product_Warehouses = Product_Warehouse.extent;

    private readonly ILogger<Product_WarehouseController> _logger;

    public Product_WarehouseController(ILogger<Product_WarehouseController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetProduct_Warehouses")]
    public IActionResult GetProduct_Warehouses()
    {
        return Ok(_product_Warehouses);
    }
    
    [HttpGet("{id:int}")]
    public IActionResult GetProduct_Warehouses(int id)
    {
        var product_Warehouse = _product_Warehouses.FirstOrDefault(wa => wa.IdProduct_Warehouse == id);
        if (product_Warehouse == null)
            return NotFound($"Product_Warehouse with id {id} was not found");
        return Ok(_product_Warehouses[id]);
    }
    
    [HttpPost(Name = "PostProduct_Warehouse")]
    public IActionResult Post(Product_Warehouse product_Warehouse)
    {
        _product_Warehouses.Add(product_Warehouse);
        return StatusCode(StatusCodes.Status201Created);
    }
    
    [HttpPut("{id:int}")]
    public IActionResult PutAnimal(int id, Product_Warehouse product_Warehouse)
    {
        var product_WarehouseToEdit = _product_Warehouses.FirstOrDefault(wa => wa.IdProduct_Warehouse == id);
        if (product_WarehouseToEdit == null)
            return NotFound($"Product_Warehouse with id {id} was not found");
        if(id!=product_Warehouse.IdProduct_Warehouse)
            return StatusCode(404);
        
        _product_Warehouses.Remove(product_WarehouseToEdit);
        _product_Warehouses.Add(product_Warehouse);
        return NoContent();
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult DeleteProduct_Warehouse(int id)
    {
        var product_Warehouse= _product_Warehouses.FirstOrDefault(wa => wa.IdProduct_Warehouse == id);
        if (product_Warehouse== null)
            return NotFound($"Product_Warehouse with id {id} was not found");
        _product_Warehouses.Remove(product_Warehouse);
        return NoContent();
    }
}