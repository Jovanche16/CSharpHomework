

Console.WriteLine("Enter the first number:");
int a = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter the second number:");
int b = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Before:");
Console.WriteLine($"a = {a}, b =  {b}");

int temp = a;
a = b;
b = temp;

Console.WriteLine("After:");
Console.WriteLine($"a = {a}, b =  {b}");