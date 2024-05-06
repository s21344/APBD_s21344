using System.Collections;

namespace Zad5_RestAPI;

public class Product_Warehouse
{
    public static List<Product_Warehouse> extent = new List<Product_Warehouse>();
    
    public int IdProduct_Warehouse { get; set; }
    
    public int IdWarehouse { get; set; }
    
    public int IdProduct { get; set; }
    
    public int IdOrder { get; set; }

    public int Amount { get; set; }

    public double Price { get; set;} // ????/
    
    public DateOnly CreatedAt { get; set;} // ????


    public Product_Warehouse(int idProduct_Warehouse, int idWarehouse, int idProduct, int idOrder, int amount, double price, DateOnly createdAt)
    {
        IdProduct_Warehouse = idProduct_Warehouse;
        IdWarehouse = idWarehouse;
        IdProduct = idProduct;
        IdOrder = idOrder;
        Amount = amount;
        Price = price;
        CreatedAt = createdAt;
        extent.Add(this);
    }
}
