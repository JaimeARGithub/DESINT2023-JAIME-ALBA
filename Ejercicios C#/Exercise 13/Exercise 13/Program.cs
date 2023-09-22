Console.WriteLine("Please, enter a number of students.");
String numberString = Console.ReadLine();
int number = int.Parse(numberString);


int[] grades = new int[number];
String gradeString;
int grade;
for (int i=0; i<grades.Length; i++)
{
    Console.WriteLine("Please, enter the grade for the student number "+(i+1));
    gradeString = Console.ReadLine();
    grade = int.Parse(gradeString);
    while (grade < 0 || grade > 100 )
    {
        Console.WriteLine("Invalid grade. Try again.");
        gradeString = Console.ReadLine();
        grade = int.Parse(gradeString);
    }
    grades[i] = grade;
}

int sum = 0;
for (int i=0; i<grades.Length; i++)
{
    sum = sum + grades[i];
    Console.WriteLine("The student number "+(i+1)+" has a grade of " + grades[i]);
}
double avg = (double)sum / grades.Length;
Console.WriteLine("The average value for the grades of the students is "+avg.ToString("F4"));