double[] EnterArrayElements()
{
    double[] arr = new double[6];
    for (int i = 0; i < arr.Length; i++)
    {
        while (true)
        {
            Console.Write($"Enter number {i + 1}: ");
            string input = Console.ReadLine();

            if (double.TryParse(input, out arr[i]))
                break; 

            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }
    return arr;
}
double SumOfEven(double[] arr)
{
    double sum = 0;
    for(int i=0; i<arr.Length; i++)
    {
        if (arr[i]%2==0)
        {
            sum += arr[i];
        }
    }
    return sum;
}

double[] array = EnterArrayElements();

Console.WriteLine($"The sum of the numbers is {SumOfEven(array)}");

Console.WriteLine();