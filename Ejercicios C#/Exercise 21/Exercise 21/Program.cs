// See https://aka.ms/new-console-template for more information
using Exercise_21;

public class List
{
    public static void Main(String[]args)
    {
        Console.WriteLine("Please, write an upper bound.");
        int upper = int.Parse(Console.ReadLine());

        double countPerfect = 0;
        double countNeither = 0;


        Console.WriteLine(" "); 
        Console.WriteLine("These numbers are perfect: ");
        for (int i=1; i<=upper; i++)
        {
            if (Methods.isPerfect(i))
            {
                countPerfect++;
                Console.Write(i+" ");
            }
        }
        Console.WriteLine(" ");
        Console.WriteLine("[" + countPerfect + " perfect numbers found (" + ((countPerfect / upper) * 100).ToString("F2") + "%)]");

        Console.WriteLine(" ");
        Console.WriteLine(" ");
        Console.WriteLine("These numbers are neither deficient nor perfect: ");
        for (int i = 1; i <= upper; i++)
        {
            if (!Methods.isPerfect(i) && !Methods.isDeficient(i))
            {
                countNeither++;
                Console.Write(i + " ");
            }
        }
        Console.WriteLine(" ");
        Console.WriteLine("[" + countNeither + " numbers found (" + ((countNeither / upper) * 100).ToString("F2") + "%)]");
    }
}