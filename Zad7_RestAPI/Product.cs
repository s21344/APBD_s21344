using System.Collections;

namespace Zad5_RestAPI;

public class Product
{
    public static List<Product> extent = new List<Product>();
    public int IdProduct { get; set; }

    public string Name { get; set; }

    public string Description { get; set;}
    
    public double Price { get; set;}
    
    public Product(int idProduct, string name, string description, double price)
    {
        IdProduct = idProduct;
        Name = name;
        Description = description;
        Price = price;
        extent.Add(this);
    }
}
