
namespace tempcontrol;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Please insert how many days you want");
        int days_int = int.Parse(Console.ReadLine() ?? "0");

        float[] temps = new float[days_int];
        float temp_avg = 0;
        int days_above_avg = 0;

        for (int day = 0; day < days_int; day++)
        {
            Console.WriteLine($"Please insert the temperature for day {day+1}");
            float temp = float.Parse(Console.ReadLine() ?? "0");

            temps[day] = temp;
            temp_avg += temp;

        }

        temp_avg /= days_int;
        Console.WriteLine($"The average temperature is: {temp_avg}");

        foreach (float temp in temps)
        {
            if (temp >= temp_avg)
            {
                days_above_avg ++;
            }
        }

        Console.WriteLine($"The amount of days with temperature equal or above avg was {days_above_avg}");
    }
}