// See https://aka.ms/new-console-template for more information
public class NumberGuessingGame
{
    public static void Main(String[] args)
    {
        Random aleatorio = new Random();
        int num = aleatorio.Next(0, 100);

        bool guessed = false;
        int tries = 0;

        Console.WriteLine("Let's play guessing game! Try a number between 0 and 99!");
        int numEntered = int.Parse(Console.ReadLine());
        int lowerLimit = 0;
        int upperLimit = 99;


        while (!guessed)
        {
            tries = tries + 1;
            if (numEntered < 0 || numEntered > 99)
            {
                Console.WriteLine("Please, follow the rules of the game! :(");
                numEntered = int.Parse(Console.ReadLine());

            } else
            {
                if (numEntered == num)
                {
                    Console.WriteLine("That's it! You guessed it!");
                    guessed = true;

                } else if ((numEntered < num) && (numEntered >= lowerLimit))
                {
                    lowerLimit = numEntered;
                    Console.WriteLine("Try higher! The number is between "+lowerLimit+" and "+upperLimit+"!");
                    numEntered = int.Parse(Console.ReadLine());
                } else if ((numEntered > num) && (numEntered <= upperLimit))
                {
                    upperLimit = numEntered;
                    Console.WriteLine("Try lower! The number is between "+lowerLimit+" and "+upperLimit+"!");
                    numEntered = int.Parse(Console.ReadLine());
                }
            }
        }

        Console.WriteLine("You got it in "+tries+" tries!");
    }
}
