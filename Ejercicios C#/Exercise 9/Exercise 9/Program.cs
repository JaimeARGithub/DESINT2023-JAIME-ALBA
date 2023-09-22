Console.WriteLine("Please, enter a String: ");
String userString = Console.ReadLine();
String reversed = new string(userString.Reverse().ToArray());
Console.WriteLine("The reverse of the String "+userString+" is "+reversed+".");