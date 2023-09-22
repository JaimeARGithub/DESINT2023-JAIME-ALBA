double acumulador = 0;
double divisor = 1;
for (int i=1; i<=10000000; i++)
{
    if (i%2!=0)
    {
        acumulador = acumulador + (1/divisor);
    } else
    {
        acumulador = acumulador - (1/divisor);
    }

    divisor = divisor + 2;
}

double pi = 4 * acumulador;
Console.WriteLine("The value of pi equals "+pi.ToString("F25"));
Console.WriteLine(" ");
Console.WriteLine("After trying with 50000, 100000, 1000000 and 10000000 iterations, I would say that");
Console.WriteLine("the offered series is suitable for computing pi depending on the required accuracy, since it doesn't matter how much");
Console.WriteLine("I augment the number of iterations, we never really get the most accurate value of pi (3.14159265358979323846264...), althought");
Console.WriteLine("we get closer to it every time the number of iterations increases.");