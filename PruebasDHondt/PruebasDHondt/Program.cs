using System.Collections.Immutable;
using System.Numerics;

int[] partido1 = { 1, 2, 3, 4, 5, 6 };
int votos1 = 0;
int[] partido2 = { 7, 8, 9, 10, 11, 12 };
int votos2 = 0;
int[] partido3 = { 13, 14, 15, 16, 17, 18 };
int votos3 = 0;

List<int> lista = new List<int>();

for (int i=0; i<6; i++)
{
    lista.Add(partido1[i]);
    lista.Add(partido2[i]);
    lista.Add(partido3[i]);
}

int max;


for (int i=0; i<3; i++)
{
    List<int> listaCopia = new List<int>(lista);
    max = 0;
    
    foreach (int e in listaCopia)
    {
        if (e > max)
        {
            max = e;
            
        }
    }
    lista.Remove(max);
    Console.WriteLine(max);




    for (int j = 0; j < 6; j++)
    {
        if (partido1[j] == max)
        {
            votos1++;
        }
        else if ((partido2[j] == max))
        {
            votos2++;
        }
        else if ((partido3[j] == max))
        {
            votos3++;
        }
    }
}


Console.WriteLine(votos1);
Console.WriteLine(votos2);
Console.WriteLine(votos3);

