using System.Collections;
using System.Runtime.Intrinsics.X86;

public class Ejercicio15
{
    public static void Main(String[] args)
    {
        Console.WriteLine("Please, enter a number of students.");
        String numberString = Console.ReadLine();
        int number = int.Parse(numberString);


        int[] grades = new int[number];
        String gradeString;
        int grade;
        for (int i = 0; i < grades.Length; i++)
        {
            Console.WriteLine("Please, enter the grade for the student number " + (i + 1));
            gradeString = Console.ReadLine();
            grade = int.Parse(gradeString);
            while (grade < 0 || grade > 100)
            {
                Console.WriteLine("Invalid grade. Try again.");
                gradeString = Console.ReadLine();
                grade = int.Parse(gradeString);
            }
            grades[i] = grade;
        }

        for (int i = 0; i < grades.Length; i++)
        {
            Console.WriteLine("The student number " + (i + 1) + " has a grade of " + grades[i]);
        }

        Console.WriteLine("The average value for the grades of the students is " + avg(grades).ToString("F3"));
        Console.WriteLine("The maximum value for the grades of the students is " + max(grades));
        Console.WriteLine("The minimum value for the grades of the students is " + min(grades));
        Console.WriteLine("The standard deviation is " + standDev(grades).ToString("F14"));



    }

    static double avg(int[] arrayInt)
    {
        int sum = 0;
        for (int i = 0; i < arrayInt.Length; i++)
        {
            sum = sum + arrayInt[i];
        }
        double avg = (double)sum / arrayInt.Length;

        return avg;
    }

    static int max(int[] arrayInt)
    {
        int max = 0;

        for (int i=0; i<arrayInt.Length; i++)
        {
            if (arrayInt[i]>max)
            {
                max = arrayInt[i];
            }
        }
        
        return max;
    }

    static int min(int[] arrayInt)
    {
        int min = 100;

        for (int i = 0; i < arrayInt.Length; i++)
        {
            if (arrayInt[i] < min)
            {
                min = arrayInt[i];
            }
        }

        return min;
    }

    static double standDev(int[] arrayInt)
    {
        double dev;
        double mean = avg(arrayInt);

        double sum = 0;
        for (int i=0; i<arrayInt.Length; i++)
        {
            sum = sum + Math.Pow(((double)arrayInt[i]-mean),2);
        }

        double term = sum / arrayInt.Length;
        dev = Math.Sqrt(term);

        return dev;
    }
}







