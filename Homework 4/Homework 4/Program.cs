using Homework_4;

Car[] cars = new Car[]
{
    new Car("Ferrari", 200),
    new Car("Lamborghini", 210),
    new Car("Porsche", 190),
    new Car("BMW", 180)
};

Driver[] drivers = new Driver[]
{
    new Driver("Alex", 5),
    new Driver("Ivan", 7),
    new Driver("Marija", 6),
    new Driver("David", 8)
};

bool playAgain = true;

while (playAgain)
{
    StartGame(cars, drivers);

    Console.WriteLine("\nWanna play again? (y/n)");
    string choice = Console.ReadLine();
    if (choice.ToUpper() == "N")
    {
        playAgain = false;
    }
}
Console.WriteLine("Thanks for playing!");
Console.WriteLine();

static void StartGame(Car[] cars, Driver[] drivers)
{
    bool[] carSelected = new bool[cars.Length];
    Array.Clear(carSelected, 0, carSelected.Length);

    Car firstCar = ChooseCar(cars, carSelected);
    Driver firstDriver = ChooseDriver(drivers);
    firstCar.Driver = firstDriver;


    Car scndCar = ChooseCar(cars, carSelected);
    Driver scndDriver = ChooseDriver(drivers);
    scndCar.Driver = scndDriver;

    RaceCars(firstCar, scndCar);
}
    static Car ChooseCar(Car[] cars, bool[] carSelected)
{
    while (true)
    {
        Console.WriteLine("Choose a car:");

        for (int i = 0; i < cars.Length; i++)
        {
            if (!carSelected[i])
            {
                Console.WriteLine($"{i + 1}. {cars[i].Model} (Speed: {cars[i].Speed})");
            }
        }

        int carChoice = GetValidInput() - 1;

        if (!carSelected[carChoice])
        {
            carSelected[carChoice] = true;
            return cars[carChoice];
        }
        Console.WriteLine("This car is already selected. Choose another one.\n");
    }
}
static Driver ChooseDriver(Driver[] drivers)
{
    Console.WriteLine("Choose a driver:");

    for (int i = 0; i < drivers.Length; i++)
    {
        Console.WriteLine($"{i + 1}. {drivers[i].Name} (Skill: {drivers[i].Skill})");
    }
    int driverChoice = GetValidInput() - 1;
    return drivers[driverChoice];
}

static void RaceCars(Car car1, Car car2)
{
    int car1Speed = car1.CalculateSpeed(car1.Driver);
    int car2Speed = car2.CalculateSpeed(car2.Driver);

    Console.WriteLine(car1Speed + " " + car2Speed);

    if (car1Speed > car2Speed)
    {
        Console.WriteLine($"The winner is {car1.Model} driven by {car1.Driver.Name} with a speed of {car1Speed}!\n");
    }
    else if (car1Speed < car2Speed)
    {
        Console.WriteLine($"The winner is {car2.Model} driven by {car2.Driver.Name} with a speed of {car2Speed}!\n");
    }
    else
    {
        Console.WriteLine("It's a tie!\n");
    }
}
static int GetValidInput()
{
    int input;

    while (true)
    {
        Console.WriteLine($"\nEnter a number between 1 and 4:");
        string userInput = Console.ReadLine();
        bool isValid = int.TryParse(userInput, out input);

        if (isValid && input > 0 && input < 5)
        {
            return input;
        }
        Console.WriteLine("Invalid input! Please enter a valid number.");
    }
}