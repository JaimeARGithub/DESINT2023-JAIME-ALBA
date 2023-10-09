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

        
        

        
        

        
    }
}