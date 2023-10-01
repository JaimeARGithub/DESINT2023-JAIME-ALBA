// See https://aka.ms/new-console-template for more information
using System.Runtime.Intrinsics.X86;

public class GCD
{
    public static void Main(String[] args)
    {
        Console.WriteLine("Please, enter two numbers.");
        int first = int.Parse(Console.ReadLine());
        int second = int.Parse(Console.ReadLine());
        int solution;

        if (first == second)
        {
            solution = first;
            Console.WriteLine("GCD(" + first + "," + second + ") = " + solution);
        } else
        {
            int a;
            int b;
            int aux;


            if (first > second)
            {
                a = first;
                b = second;
            }
            else
            {
                a = second;
                b = first;
            }


            while (b != 0)
            {
                Console.Write("GCD(" + a + "," + b + ") = ");
                aux = b;
                b = a % b;
                a = aux;
            }
            solution = a;
            Console.Write("GCD(" + a + "," + b + ") = " + solution);
        }

        
    }
}
