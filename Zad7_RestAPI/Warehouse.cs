using System.Collections;

namespace Zad5_RestAPI;

public class Warehouse
{
    public static List<Warehouse> extent = new List<Warehouse>();
    public int IdWarehouse { get; set; }

    public string Name { get; set; }

    public string Address { get; set;}


    public Warehouse(int idWarehouse, string name, string address)
    {
        IdWarehouse = idWarehouse;
        Name = name;
        Address = address;
        extent.Add(this);
    }
}
