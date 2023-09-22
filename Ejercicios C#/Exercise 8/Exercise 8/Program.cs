Console.WriteLine("Please, enter a double (using comma) value for the radius: _____ m");
String radiusString = Console.ReadLine();

double radius = Convert.ToDouble(radiusString);


double area = 4 * Math.PI * Math.Pow(radius, 2);
double volume = (4 * Math.PI * Math.Pow(radius, 3)) / 3;

Console.WriteLine("The surface area is "+area+ " m2");
Console.WriteLine("The volume is "+volume+" m3");
