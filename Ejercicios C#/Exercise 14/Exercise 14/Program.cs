String[] binaries = {"0000 ", "0001 ", "0010 ", "0011 ", "0100 ", "0101 ", "0110 ", "0111 ", "1000 ", "1001 ", "1010 ", "1011 ", "1100 ", "1101 ", "1110 ", "1111 "};

Console.WriteLine("Please, enter a hexadecimal string.");
String numberString = Console.ReadLine();

bool isHexa = true;
for (int i = 0; i < numberString.Length; i++)
{
    if ((int)numberString[i] < 48 || (int)numberString[i] > 70 || (((int)numberString[i] > 57) && ((int)numberString[i] < 65)))
    {
        isHexa = false;
    }
}

if (!isHexa)
{
    Console.WriteLine("Error. Not a hexadecimal value.");
} else
{
    Console.Write("The equivalent binary for hexadecimal '"+numberString+"' is ");
    for (int i=0; i<numberString.Length; i++)
    {
        switch (numberString[i])
        {
            case '0':
                Console.Write(binaries[0]);
                break;
            case '1':
                Console.Write(binaries[1]);
                break;
            case '2':
                Console.Write(binaries[2]);
                break;
            case '3':
                Console.Write(binaries[3]);
                break;
            case '4':
                Console.Write(binaries[4]);
                break;
            case '5':
                Console.Write(binaries[5]);
                break;
            case '6':
                Console.Write(binaries[6]);
                break;
            case '7':
                Console.Write(binaries[7]);
                break;
            case '8':
                Console.Write(binaries[8]);
                break;
            case '9':
                Console.Write(binaries[9]);
                break;
            case 'A':
                Console.Write(binaries[10]);
                break;
            case 'B':
                Console.Write(binaries[11]);
                break;
            case 'C':
                Console.Write(binaries[12]);
                break;
            case 'D':
                Console.Write(binaries[13]);
                break;
            case 'E':
                Console.Write(binaries[14]);
                break;
            case 'F':
                Console.Write(binaries[15]);
                break;
        }
    }
    Console.WriteLine("");
    Console.WriteLine("");
}