namespace Conteners;

public abstract class ContainerBase
{
    protected int Height { get; }
    protected int Width { get; }
    protected int Length { get; }
    
    protected double ContainerWeight { get; }
    protected double MaxWeight { get; }

    protected double LoadWeight { get; set; }

    


    // public double SetLoadWeight(double loadWeight)
    // {
    //     if (loadWeight<MaxWeight)
    //     {
    //         this.LoadWeight = loadWeight;
    //     }
    // }
    //
    // set
    //     {
    //         if (value < MaxWeight)
    //             LoadWeight = value;
    //         else
    //         {
    //             //throw error
    //         }
    //     }
    // }
    
    


    protected string SerialNumber;
    
    public ContainerBase(int height, int width,int length, double containerWeight,double maxWeight ,double loadWeight, string serialNumber)
    {
        this.Height = height;
        this.Width = width;
        this.Length = length;

        this.ContainerWeight = containerWeight;
        // this.LoadWeight = loadWeight;
        this.MaxWeight = maxWeight;
        

        this.SerialNumber = SerialNumber;
    }
    
    
    




}