using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics.Metrics;


Console.WriteLine("Enter the first number:");
int firstNumber = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter the second number:");
int secondNumber = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter the operator:");
char operation = Convert.ToChar(Console.ReadLine());

switch(operation)
{
    case '+':
        Console.WriteLine($"The result is: {firstNumber + secondNumber}");
        break;
    case '-':
        Console.WriteLine($"The reult is: {firstNumber - secondNumber}");
        break;
    case '*':
        Console.WriteLine($"The result is: {firstNumber * secondNumber}");
        break;
    case '/':
        if (secondNumber != 0)
            Console.WriteLine($"The result is: {firstNumber / secondNumber}");
        else
        {
            Console.WriteLine("Error: Division by zero is not allowed.");
        }
        break;
    default:
        Console.WriteLine("You have entered a wrong operator!");
        break;
}
