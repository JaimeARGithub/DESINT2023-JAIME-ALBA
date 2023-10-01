// See https://aka.ms/new-console-template for more information
using System.Text;

public class WordGuess
{
    public static void Main(string[] args)
    {
        String word = new String("interfaces");
        Console.WriteLine("Time to play! Please, key a character or your guess word.");
        int tries = 0;

        StringBuilder sb = new StringBuilder();
        for (int i=0; i<word.Length; i++)
        {
            sb.Append('_');
        }
        Console.WriteLine(sb.ToString());
        Console.WriteLine(" ");
        Console.WriteLine(" ");




        String charOrWord = null;
        String progress = sb.ToString();
        sb.Clear();
        char entered;
        bool guessed = false;
        while (!guessed)
        {
            tries = tries + 1;
            Console.WriteLine("Your character or guess word: ");
            charOrWord = Console.ReadLine();

            if (charOrWord.Length==1)
            {
                entered = charOrWord[0];

                
                
                for (int i=0; i<word.Length; i++)
                {
                    if (entered == word[i])
                    {
                        sb.Append(entered);
                    } else
                    {
                        sb.Append(progress[i]);
                    }
                }
                
                progress = sb.ToString();
                Console.WriteLine("Attempt number "+tries+": "+progress);
                sb.Clear();
            } 
            
            else
            {
                if (!charOrWord.Equals(word))
                {
                    Console.WriteLine("Wrong! Keep trying!");
                } else
                {
                    guessed = true;
                    Console.WriteLine("Yay! You guessed it!");
                    Console.WriteLine("You needed "+tries+" attempts!");
                }
            }
        }

        


    }
}