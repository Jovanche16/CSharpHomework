
static DateTime GetValidDate()
{
    DateTime birthDate;
    while (true)
    {
        Console.Write("Enter your birthdate: ");
        string input = Console.ReadLine();

        if (DateTime.TryParse(input, out birthDate))
        {
            return birthDate;
        }
        else
        {
            Console.WriteLine("Invalid date format. Please enter a valid date!");
        }
    }
}
static int AgeCalculator(DateTime birthDate)
{
    DateTime today = DateTime.Today;
    int age = today.Year - birthDate.Year;

    if (birthDate.Date > today.AddYears(-age))
    {
        age--;
    }

    return age;
}

DateTime birthDate = GetValidDate();
int age = AgeCalculator(birthDate);
Console.WriteLine($"You are {age} years old.");

Console.WriteLine();

