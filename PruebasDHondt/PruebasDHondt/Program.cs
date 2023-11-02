int escañosMadrid = 37;
int habitantesMadrid = 6921267;
int habitantesVotaron = 4345230;
int votosNulos = habitantesVotaron / 20;

int votosValidos = habitantesVotaron - votosNulos;

double[] porcentajes = { 35.25, 24.75, 15.75, 14.25, 3.75, 3.25, 1.5, 0.5, 0.25, 0.25 };
int cuenta3 = 0;
for (int i = 0; i < porcentajes.Length; i++)
{
    if (porcentajes[i] < 3)
    {
        porcentajes[i] = 0;
    }
}

int[] votos1 = new int[37];
votos1[0] = (int)((porcentajes[0] * votosValidos) / 100);

int[] votos2 = new int[37];
votos2[0] = (int)((porcentajes[1] * votosValidos) / 100);

int[] votos3 = new int[37];
votos3[0] = (int)((porcentajes[2] * votosValidos) / 100);

int[] votos4 = new int[37];
votos4[0] = (int)((porcentajes[3] * votosValidos) / 100);

int[] votos5 = new int[37];
votos5[0] = (int)((porcentajes[4] * votosValidos) / 100);

int[] votos6 = new int[37];
votos6[0] = (int)((porcentajes[5] * votosValidos) / 100);

int[] votos7 = new int[37];
votos7[0] = (int)((porcentajes[6] * votosValidos) / 100);

int[] votos8 = new int[37];
votos8[0] = (int)((porcentajes[7] * votosValidos) / 100);

int[] votos9 = new int[37];
votos9[0] = (int)((porcentajes[8] * votosValidos) / 100);

int[] votos10 = new int[37];
votos10[0] = (int)((porcentajes[9] * votosValidos) / 100);

for (int i = 1; i < 37; i++)
{
    votos1[i] = votos1[0] / (i + 1);
    votos2[i] = votos2[0] / (i + 1);
    votos3[i] = votos3[0] / (i + 1);
    votos4[i] = votos4[0] / (i + 1);
    votos5[i] = votos5[0] / (i + 1);
    votos6[i] = votos6[0] / (i + 1);
    votos7[i] = votos7[0] / (i + 1);
    votos8[i] = votos8[0] / (i + 1);
    votos9[i] = votos9[0] / (i + 1);
    votos10[i] = votos10[0] / (i + 1);
}

List<int> todosVotos = new List<int>();
for (int i = 0; i < 37; i++)
{
    todosVotos.Add(votos1[i]);
    todosVotos.Add(votos2[i]);
    todosVotos.Add(votos3[i]);
    todosVotos.Add(votos4[i]);
    todosVotos.Add(votos5[i]);
    todosVotos.Add(votos6[i]);
    todosVotos.Add(votos7[i]);
    todosVotos.Add(votos8[i]);
    todosVotos.Add(votos9[i]);
    todosVotos.Add(votos10[i]);
}

List<int> todosVotosCopia = new List<int>(todosVotos);

int escaños1 = 0;
int escaños2 = 0;
int escaños3 = 0;
int escaños4 = 0;
int escaños5 = 0;
int escaños6 = 0;
int escaños7 = 0;
int escaños8 = 0;
int escaños9 = 0;
int escaños10 = 0;

int max = 0;

for (int e = 0; e < escañosMadrid; e++)
{
    foreach (int z in todosVotos)
    {
        if (z > max)
        {
            max = z;
        }
    }

    todosVotosCopia.Remove(max);
    todosVotos = todosVotosCopia;

    for (int i = 0; i < 10; i++)
    {
        if (max == votos1[i])
        {
            escaños1++;
        }
        else if (max == votos2[i])
        {
            escaños2++;
        }
        else if (max == votos3[i])
        {
            escaños3++;
        }
        else if (max == votos4[i])
        {
            escaños4++;
        }
        else if (max == votos5[i])
        {
            escaños5++;
        }
        else if (max == votos6[i])
        {
            escaños6++;
        }
        else if (max == votos7[i])
        {
            escaños7++;
        }
        else if (max == votos8[i])
        {
            escaños8++;
        }
        else if (max == votos9[i])
        {
            escaños9++;
        }
        else if (max == votos10[i])
        {
            escaños10++;
        }
    }

    max = 0;
}

Console.WriteLine(escaños1);
Console.WriteLine(escaños2);
Console.WriteLine(escaños3);
Console.WriteLine(escaños4);
Console.WriteLine(escaños5);
Console.WriteLine(escaños6);
Console.WriteLine(escaños7);
Console.WriteLine(escaños8);
Console.WriteLine(escaños9);
Console.WriteLine(escaños10);