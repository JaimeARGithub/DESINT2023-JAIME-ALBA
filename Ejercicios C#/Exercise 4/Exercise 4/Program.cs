double acumulador1 = 0;

for (double i=1; i<=50000; i++)
{
    acumulador1 = acumulador1 + (1/i);
}
Console.WriteLine("The sum of the harmonic series from left to right equals " + acumulador1.ToString("F25"));

Console.WriteLine(" ");

double acumulador2 = 0;
for (double j=50000; j>=1; j--)
{
    acumulador2 = acumulador2 + (1/j);
}
Console.WriteLine("The sum of the harmonic series from right to left equals " + acumulador2.ToString("F25"));

Console.WriteLine(" ");

Console.WriteLine("The difference between both sums equals " + (acumulador2-acumulador1).ToString("F25"));
Console.WriteLine(" ");
Console.WriteLine("Apparently, there is a slight difference between both sums when doing them in a computer.");
Console.WriteLine("When doing it from left to right, it is possible to have accuracy problems when the numbers");
Console.WriteLine("becoma very small, due to the limited accuracy when representing floating point numbers.");
Console.WriteLine("On the other hand, when doing the sum from right to left, we will get a sum of small numbers");
Console.WriteLine("that offers a higher level of accuracy, because the small numbers 'have an opportunity of ");
Console.WriteLine("getting together' before becoming part of bigger numbers.");
