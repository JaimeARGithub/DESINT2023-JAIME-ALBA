using Exercise_16;

public class Test
{
    public static void Main(String[] args)
    {
        int[,] a = { { 1, 2 }, { 3, 4 }, { 5, 6 } };
        int[,] b = { { 1, 1 }, { 1, 1 }, { 1, 1 } };
        int[,] c = Matrix.addition(a, b);
        int[,] c2 = Matrix.substraction(a, b);
        Visor.ver(c);
        Console.WriteLine(" ");
        Console.WriteLine(" ");
        Visor.ver(c2);
        Console.WriteLine(" ");
        Console.WriteLine(" ");


        double[,] d = { { 1.1, 2.2 }, { 3.3, 4.4 }, { 5.5, 6.6 } };
        double[,] e = { { 1.1, 1.1 }, { 1.1, 1.1 }, { 1.1, 1.1 } };
        double[,] f = Matrix.addition(d,e);
        double[,] f2 = Matrix.substraction(d, e);
        Visor.ver(f);
        Console.WriteLine(" ");
        Console.WriteLine(" ");
        Visor.ver(f2);
        Console.WriteLine(" ");
        Console.WriteLine(" ");


        int[,] g = { { 2, 3 }, { 3, 4 }, { 1, 2 } };
        int[,] h = { { 1, 2, 3 }, { 1, 2, 3} };
        int[,] i = Matrix.multiplication(g, h);
        Visor.ver(i);
        Console.WriteLine(" ");
        Console.WriteLine(" ");

        double[,] g2 = { { 2.2, 3.3 }, { 3.3, 4.4 }, { 1.1, 2.2 } };
        double[,] h2 = { { 1.1, 2.2, 3.3 }, { 1.1, 2.2, 3.3 } };
        double[,] i2 = Matrix.multiplication(g2, h2);
        Visor.ver(i2);
        Console.WriteLine(" ");
        Console.WriteLine(" ");



    }
}