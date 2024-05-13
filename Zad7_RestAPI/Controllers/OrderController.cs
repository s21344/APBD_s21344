using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace Zad5_RestAPI.Controllers;

[ApiController]
[Route("api/order")]
public class OrderController : ControllerBase
{
    
    private static List<Order> _orders = Order.extent;

    private readonly ILogger<OrderController> _logger;

    public OrderController(ILogger<OrderController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetOrders")]
    public IActionResult GetOrders()
    {
        return Ok(_orders);
    }
    
    [HttpGet("{id:int}")]
    public IActionResult GetOrders(int id)
    {
        var order = _orders.FirstOrDefault(wa => wa.IdOrder == id);
        if (order == null)
            return NotFound($"Order with id {id} was not found");
        return Ok(_orders[id]);
    }
    
    [HttpPost(Name = "PostOrder")]
    public IActionResult Post(Order order)
    {
        _orders.Add(order);
        return StatusCode(StatusCodes.Status201Created);
    }
    
    [HttpPut("{id:int}")]
    public IActionResult PutAnimal(int id, Order order)
    {
        var orderToEdit = _orders.FirstOrDefault(wa => wa.IdOrder == id);
        if (orderToEdit == null)
            return NotFound($"Order with id {id} was not found");
        if(id!=order.IdOrder)
            return StatusCode(404);
        
        _orders.Remove(orderToEdit);
        _orders.Add(order);
        return NoContent();
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult DeleteOrder(int id)
    {
        var order= _orders.FirstOrDefault(wa => wa.IdOrder == id);
        if (order== null)
            return NotFound($"Order with id {id} was not found");
        _orders.Remove(order);
        return NoContent();
    }
}