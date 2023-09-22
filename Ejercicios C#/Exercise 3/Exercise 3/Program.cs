int upper = 100;
int acumulador = 0;
double average;

for (int i=1; i<=upper; i++)
{
    acumulador = acumulador + i;
}

double upperDec = (double)upper;
double acumuladorDec = (double)acumulador;
average = acumuladorDec / upperDec;

Console.WriteLine("The sum is " + acumulador);
Console.WriteLine("The average is " + average.ToString("F2"));
Console.WriteLine(" ");


// Modificación 1: bucle while
int contador = 1;
acumulador = 0;
while (contador<=upper)
{
    acumulador = acumulador + contador;
    contador++;
}
acumuladorDec = (double)acumulador;
average = acumuladorDec / upperDec;

Console.WriteLine("The sum is " + acumulador);
Console.WriteLine("The average is " + average.ToString("F2"));
Console.WriteLine(" ");


// Modificación 2: bucle do-while
contador = 1;
acumulador = 0;

do
{
    acumulador = acumulador + contador;
    contador++;
} while (contador <= upper);
acumuladorDec = (double)acumulador;
average = acumuladorDec / (contador-1);

Console.WriteLine("The sum is " + acumulador);
Console.WriteLine("The average is " + average.ToString("F2")); ;
Console.WriteLine(" ");


// Modificación 3: sólo impares y su media
acumulador = 0;
int contaImpares = 0;
for (int i=1; i<=upper; i++)
{
    if (i%2!=0)
    {
        acumulador = acumulador + i;
        contaImpares++;
    }
}
acumuladorDec = (double)acumulador;
average = acumuladorDec / contaImpares;
Console.WriteLine("The sum is " + acumulador);
Console.WriteLine("The average is " + average.ToString("F2")); ;
Console.WriteLine(" ");


// Modificación 4: sólo divisibles entre 7 y su media
acumulador = 0;
int contaDiv = 0;
for (int i = 1; i <= upper; i++)
{
    if (i % 7 == 0)
    {
        acumulador = acumulador + i;
        contaDiv++;
    }
}
acumuladorDec = (double)acumulador;
average = acumuladorDec / contaDiv;
Console.WriteLine("The sum is " + acumulador);
Console.WriteLine("The average is " + average.ToString("F2")); ;
Console.WriteLine(" ");


// Modificación 5: suma de cuadrados
int acumulaCuad = 0;
for (int i=1; i<=upper; i++)
{
    acumulaCuad = acumulaCuad + (i*i);
}
Console.WriteLine("The sum is "+acumulaCuad);
