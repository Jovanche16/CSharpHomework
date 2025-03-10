static string[] FillStudentArray()
{
    string[] groupArray = new string[5];

    for (int i = 0; i < 5; i++)
    {
        while (true)
        {
            Console.Write($"Enter name of student {i + 1}: ");
            string input = Console.ReadLine().Trim();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Name cannot be empty. Please enter a valid name.");
            }
            else
            {
                groupArray[i] = input;
                break;
            }
        }
            
    }

    return groupArray;
}
int GetStudentGroup()
{

    while (true)
    {
        Console.Write("Enter number of student group (1 or 2): ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int studentGroup) && (studentGroup == 1 || studentGroup == 2))
        {
            return studentGroup; 
        }
        Console.WriteLine("Invalid input. Please enter a number between 1 and 2.");
    }

}

void ShowNames(string[] students)
{
    foreach (var student in students)
    {
        Console.WriteLine(student);
    }
}

Console.WriteLine("Enter the names for the G1 group:");
string[] studentsG1 = FillStudentArray();
Console.WriteLine("Enter the names for the G2 group:");
string[] studentsG2 = FillStudentArray();

int numberOfGroup = GetStudentGroup();

if(numberOfGroup == 1)
{
    Console.WriteLine("The Students in G1 are:");
    ShowNames(studentsG1);
}
else
{
    Console.WriteLine("The Students in G2 are:");
    ShowNames(studentsG2);
}

 Console.WriteLine();