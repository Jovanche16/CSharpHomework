
List<int> numbers = new List<int>();

Console.WriteLine($"Enter 4 numbers: ");
for (int i = 1; i <= 4; i++)
{
    numbers.Add(Convert.ToInt32(Console.ReadLine()));
}

double sum = 0;
foreach (int num in numbers)
{
    sum += num;
}
double average = sum / numbers.Count;

Console.Write("The average of ");
for (int i = 0; i < numbers.Count; i++)
{
    if (i == numbers.Count - 1)
        Console.Write(numbers[i]);
    else
        Console.Write(numbers[i] + ", ");
}
Console.WriteLine($" is: {average}");
