namespace Conteners;

public abstract class ContainerBase
{
    protected int Height { get; }
    protected int Width { get; }
    protected int Length { get; }
    
    protected double ContainerWeight { get; }
    protected double MaxWeight { get; }

    protected double LoadWeight;
    
    protected string SerialNumber;


    public double getLoadWeight()
    {
        return LoadWeight;
    }

    public void setLoadWeight(double weight)
    {
        
        if (weight < MaxWeight)
            LoadWeight = weight;
        else
        {
            throw new OverfillException("The student cannot be found.");
        }
    }

    
    


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


    protected ContainerBase()
    {
    }


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