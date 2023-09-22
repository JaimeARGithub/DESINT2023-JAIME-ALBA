using System.Text;

Console.WriteLine("Please, enter a word.");
String enteredWord = Console.ReadLine();
String word = enteredWord.ToLower();

bool palindrome = true;

for (int i=0; i<word.Length; i++)
{
    if (word[i] != word[(word.Length)-i-1])
    {
        palindrome = false;
    }
}

if (palindrome)
{
    Console.WriteLine("It is a palindrome.");
} else
{
    Console.WriteLine("It is not a palindrome.");
}

Console.WriteLine(" ");
Console.WriteLine(" ");


// Modificación: comprobar frases-palíndromo
Console.WriteLine("Please, enter a phrase.");
String enteredPhrase = Console.ReadLine();
String enteredPhraseL = enteredPhrase.ToLower();

StringBuilder sb = new StringBuilder();
for (int i=0; i<enteredPhraseL.Length; i++)
{
    if (char.IsLetter(enteredPhraseL[i]))
    {
        sb.Append(enteredPhraseL[i]);
    }
}

String phrase = sb.ToString();
bool palindromePhrase = true;

for (int i=0; i<phrase.Length; i++)
{
    if (phrase[i] != phrase[(phrase.Length)-i-1])
    {
        palindromePhrase = false;
    }
}

if (palindromePhrase)
{
    Console.WriteLine("The phrase is a palindrome.");
}
else
{
    Console.WriteLine("The phrase is not a palindrome.");
}