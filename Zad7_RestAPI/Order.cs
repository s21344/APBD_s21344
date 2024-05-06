using System.Collections;

namespace Zad5_RestAPI;

public class Order
{
    
    public static List<Order> extent = new List<Order>();
    public int IdOrder { get; set; }
    
    public int IdProduct { get; set; }

    public int Amount { get; set; }

    public DateOnly CreatedAt { get; set;}
    
    public DateOnly FulfilledAt { get; set;}


    public Order(int idOrder, int idProduct, int amount, DateOnly createdAt, DateOnly fulfilledAt)
    {
        IdOrder = idOrder;
        IdProduct = idProduct;
        Amount = amount;
        CreatedAt = createdAt;
        FulfilledAt = fulfilledAt;
        extent.Add(this);
    }
}
