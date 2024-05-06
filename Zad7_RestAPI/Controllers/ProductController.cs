using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace Zad5_RestAPI.Controllers;

[ApiController]
[Route("api/animal")]
public class ProductController : ControllerBase
{
    private static List<Product> _products = Product.extent;

    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetProducts")]
    public IActionResult GetProducts()
    {
        return Ok(_products);
    }
    
    [HttpGet("{id:int}")]
    public IActionResult GetProducts(int id)
    {
        var product = _products.FirstOrDefault(wa => wa.IdProduct == id);
        if (product == null)
            return NotFound($"Product with id {id} was not found");
        return Ok(_products[id]);
    }
    
    [HttpPost(Name = "PostProduct")]
    public IActionResult Post(Product product)
    {
        _products.Add(product);
        return StatusCode(StatusCodes.Status201Created);
    }
    
    [HttpPut("{id:int}")]
    public IActionResult PutAnimal(int id, Product product)
    {
        var productToEdit = _products.FirstOrDefault(wa => wa.IdProduct == id);
        if (productToEdit == null)
            return NotFound($"Product with id {id} was not found");
        if(id!=product.IdProduct)
            return StatusCode(404);
        
        _products.Remove(productToEdit);
        _products.Add(product);
        return NoContent();
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult DeleteProduct(int id)
    {
        var product= _products.FirstOrDefault(wa => wa.IdProduct == id);
        if (product== null)
            return NotFound($"Product with id {id} was not found");
        _products.Remove(product);
        return NoContent();
    }
}