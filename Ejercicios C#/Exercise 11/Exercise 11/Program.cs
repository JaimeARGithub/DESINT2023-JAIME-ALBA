Console.WriteLine("Please, enter a binary string.");
String number = Console.ReadLine();

bool esBinario = true;
for (int i=0; i<number.Length; i++)
{
    if (number[i]!='1' && number[i]!='0')
    {
        esBinario = false;
    }
}

if (!esBinario)
{
    Console.WriteLine("Error: Invalid binary string '" + number + "'");
} else
{
    String numberOperar = new String(number.Reverse().ToArray());

    int numDec = 0;
    for (int i = 0; i < numberOperar.Length; i++)
    {
        if (numberOperar[i] == '1')
        {
            numDec = numDec + (int)Math.Pow(2, i);
        }
    }
    Console.WriteLine("The equivalent decimal number for binary "+number+" is "+numDec);
}