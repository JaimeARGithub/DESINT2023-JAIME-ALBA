Console.WriteLine("* | 1  2  3  4  5  6  7  8  9");
Console.WriteLine("-----------------------------");
int res;

for (int i=1; i<=9; i++)
{
    Console.Write(i+" | ");
    
    for (int j=1; j<=9; j++)
    {
        res = i * j;
        Console.Write(res+" ");
        if (res<10)
        {
            Console.Write(" ");
        }
    }
    Console.WriteLine(" ");
}

Console.WriteLine(" "); 
Console.WriteLine(" ");
Console.WriteLine(" ");


// Modificación: utilizando un único bucle for
Console.WriteLine("* | 1  2  3  4  5  6  7  8  9");
Console.WriteLine("-----------------------------");

int multiplicador = 1;
for (int i=1; i<=9; i++)
{
    Console.Write(i+" | ");
    while (multiplicador<=9)
    {
        res = i * multiplicador;
        Console.Write(res+" ");
        if (res < 10)
        {
            Console.Write(" ");
        }
        multiplicador++;
    }
    multiplicador = 1;
    Console.WriteLine(" ");
}
