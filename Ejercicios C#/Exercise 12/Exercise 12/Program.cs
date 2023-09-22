using System.ComponentModel.Design;

Console.WriteLine("Please, enter a hexadecimal string.");
String number = Console.ReadLine();
bool esHexa = true;

for (int i=0; i<number.Length; i++)
{
    if ((int)number[i]<48 || (int)number[i] > 70 || (((int)number[i] > 57) && ((int)number[i] < 65)))
    {
        esHexa = false;
    } 
}

if (!esHexa)
{
    Console.WriteLine("Error: Invalid hexadecimal string '" + number + "'");
} else
{
    String numberOperar = new String(number.Reverse().ToArray());
    int numDec = 0;
    int currValue = 0;

    for (int i=0; i<numberOperar.Length; i++)
    {
        switch (numberOperar[i])
        {
            case '0':
                currValue = 0;
                break;
            case '1':
                currValue = 1;
                break;
            case '2':
                currValue = 2;
                break;
            case '3':
                currValue = 3;
                break;
            case '4':
                currValue = 4;
                break;
            case '5':
                currValue = 5;
                break;
            case '6':
                currValue = 6;
                break;
            case '7':
                currValue = 7;
                break;
            case '8':
                currValue = 8;
                break;
            case '9':
                currValue = 9;
                break;
            case 'A':
                currValue = 10;
                break;
            case 'B':
                currValue = 11;
                break;
            case 'C':
                currValue = 12;
                break;
            case 'D':
                currValue = 13;
                break;
            case 'E':
                currValue = 14;
                break;
            case 'F':
                currValue = 15;
                break;
        }
        numDec = numDec + (currValue * (int)Math.Pow(16, i));
    }

    Console.WriteLine("The equivalent decimal number for hexadecimal "+number+" is "+numDec);
}



