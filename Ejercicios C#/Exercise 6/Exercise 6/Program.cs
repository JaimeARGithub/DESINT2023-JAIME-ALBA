int a = 0;
int b = 0;
int c = 1;

Console.WriteLine(a);
Console.WriteLine(b);
Console.WriteLine(c);

int term;
int auxC;
int auxB;

for (int i=1; i<=17; i++)
{
    term = a + b + c;
    Console.WriteLine(term);

    auxC = c;
    auxB = b;

    c = term;
    b = auxC;
    a = auxB;

}