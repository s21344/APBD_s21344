using LinqTasks.Models;

namespace LinqTasks;

class Program
{

    private static int[] Array = { 1, 1, 1, 1, 1, 1, 10, 1, 1, 1, 1, 10, 2, 10, 10 };

    static void Main(string[] args)
    {
        Console.WriteLine("======= ZAD 1 =======");

        IEnumerable<Emp> Zad1 = Tasks.Task1();

        foreach (Emp emp in Zad1)
        {
            Console.WriteLine(emp);
        }


        Console.WriteLine("======= ZAD 2 =======");

        IEnumerable<Emp> Zad2 = Tasks.Task2();

        foreach (Emp emp in Zad2)
        {
            Console.WriteLine(emp);
        }

        Console.WriteLine("======= ZAD 3 =======");

        Console.WriteLine(Tasks.Task3());


        Console.WriteLine("======= ZAD 4 =======");

        IEnumerable<Emp> Zad4 = Tasks.Task4();

        foreach (Emp emp in Zad4)
        {
            Console.WriteLine(emp);
        }


        Console.WriteLine("======= ZAD 5 =======");

        IEnumerable<object> Zad5 = Tasks.Task5();

        foreach (object emp in Zad5)
        {
            Console.WriteLine(emp);
        }

        Console.WriteLine("======= ZAD 6 =======");

        IEnumerable<object> Zad6 = Tasks.Task6();

        foreach (object emp in Zad6)
        {
            Console.WriteLine(emp);
        }

        Console.WriteLine("======= ZAD 7 =======");

        IEnumerable<object> Zad7 = Tasks.Task7();

        foreach (object emp in Zad7)
        {
            Console.WriteLine(emp);
        }

        Console.WriteLine("======= ZAD 8 =======");

        Console.WriteLine(Tasks.Task8());


        Console.WriteLine("======= ZAD 9 =======");
        
        Emp Zad9 = Tasks.Task9();
        Console.WriteLine(Zad9);
        

        Console.WriteLine("======= ZAD 10 =======");

        IEnumerable<object> Zad10 = Tasks.Task10();

        foreach (object emp in Zad10)
        {
            Console.WriteLine(emp);
        }

        Console.WriteLine("======= ZAD 11 =======");

        IEnumerable<object> Zad11 = Tasks.Task11();

        foreach (object emp in Zad11)
        {
            Console.WriteLine(emp);
        }

        Console.WriteLine("======= ZAD 12 =======");

        IEnumerable<Emp> Zad12 = Tasks.Task12();

        foreach (Emp emp in Zad12)
        {
            Console.WriteLine(emp);
        }

        Console.WriteLine("======= ZAD 13 =======");

        var Zad13 = Tasks.Task13(Array);
        Console.WriteLine("Zad 13 number = " + Zad13);


        Console.WriteLine("======= ZAD 14 =======");

        IEnumerable<Dept> Zad14 = Tasks.Task14();

        foreach (Dept dept in Zad14)
        {
            Console.WriteLine(dept);
        }

    }

}





