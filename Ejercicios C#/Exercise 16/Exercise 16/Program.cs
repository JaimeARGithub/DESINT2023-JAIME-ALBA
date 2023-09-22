using Exercise_16;

public class Test
{
    public static void Main(String[] args)
    {
        int[,] a = { { 1, 2 }, { 3, 4 }, { 5, 6 } };
        int[,] b = { { 1, 1 }, { 1, 1 }, { 1, 1 } };
        int[,] c = Matrix.addition(a, b);
        for (int i = 0; i < c.GetLength(0); i++)
        {
            for (int j = 0; j < c.GetLength(1); j++)
            {
                Console.Write(c[i, j]+" ");
            }
            Console.WriteLine(" ");
        }
    }
}