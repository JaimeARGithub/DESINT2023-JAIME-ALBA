using MatrixSimulation;
using System.Security.Claims;

public class Simulation
{
    public static void Main (string[] args)
    {
        String[] names = { "Michelle", "Alexander", "James", "Caroline", "Claire", "Jessica", "Erik", "Mike" };
        String[] cities = { "Nueva York", "Boston", "Baltimore", "Atlanta", "Detroit", "Dallas", "Denver" };
        MatrixCharacter[] queue = new MatrixCharacter[200];
        for (int i=0; i<queue.Length; i++)
        {
            queue[i] = new MatrixCharacter(names[AuxiliarMethods.generateRandom(0,7)], AuxiliarMethods.generateRandom(0,80), 
                AuxiliarMethods.generateRandom(0,90), cities[AuxiliarMethods.generateRandom(0,6)]);
        }

        MatrixCharacter[,] matrix = new MatrixCharacter[5, 5];
        matrix[AuxiliarMethods.generateRandom(0, 4), AuxiliarMethods.generateRandom(0, 4)] = new Neo();

        int xSmith = AuxiliarMethods.generateRandom(0, 4);
        int ySmith = AuxiliarMethods.generateRandom(0, 4);
        while (matrix[xSmith, ySmith] != null)
        {
            xSmith = AuxiliarMethods.generateRandom(0, 4);
            ySmith = AuxiliarMethods.generateRandom(0, 4);
        }
        matrix[xSmith, ySmith] = new Smith();

        for (int i=0; i<matrix.GetLength(0); i++)
        {
            for (int j=0; j<matrix.GetLength(1); j++)
            {
                if (matrix[i,j] is Neo)
                {
                    Console.Write(" N ");
                } else if (matrix[i, j] is Smith)
                {
                    Console.Write(" S ");
                } else if (matrix[i, j] is MatrixCharacter)
                {
                    Console.Write(" 1 ");
                } else
                {
                    Console.Write(" 0 ");
                }
            }
            Console.WriteLine("");
        }
    }
}