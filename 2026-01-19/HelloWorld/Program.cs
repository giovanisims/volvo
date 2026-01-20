namespace HelloWorld;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Type your name");
        string name = Console.ReadLine();
        
        Console.WriteLine($"Hello {name}!");

        Console.WriteLine("Please insert your CPF");
        string CPF = Console.ReadLine();
        Console.WriteLine($"You inserted {CPF}");

        Console.WriteLine("Please insert your cellphone");
        string cellphone = Console.ReadLine();
        Console.WriteLine($"You inserted {cellphone}");

        Console.WriteLine("Please insert your birth year");
        int birthyear = int.Parse(Console.ReadLine());
        Console.WriteLine($"You inserted {birthyear}");

    }
}
