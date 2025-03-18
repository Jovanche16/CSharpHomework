using Excersize3;

Customer[] customers = new Customer[15];

customers[0] = new Customer("Aleksandar", "Trajkovski", 1234123412341234, "1234", 5000);
customers[1] = new Customer("Marija", "Petrovska", 9876987698769876, "4321", 3000);
customers[2] = new Customer("Goran", "Stojanovski", 5556555655565556, "5678", 1500);

while (true)
{
    Customer authenticateCustomer = Authenticate(customers);
    if (authenticateCustomer != null)
    {
        Console.WriteLine($"\n-----------------Greetings {authenticateCustomer.FirstName} {authenticateCustomer.LastName}!-----------------");
        DisplayOptions(authenticateCustomer, customers);
    }
   
}
static void DisplayOptions(Customer customer, Customer[] customers)
{
    while (true)
    {
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1. Balance Checking");
        Console.WriteLine("2. Cash Withdrawal");
        Console.WriteLine("3. Cash Deposit");
        Console.WriteLine("4. Exit");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.WriteLine($"Your balance is: ${customer.GetBalance():N2}");
                break;

            case "2":
                Console.Write("Enter amount to withdraw: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount))
                {
                    customer.Withdraw(withdrawAmount);
                }
                else
                {
                    Console.WriteLine("Invalid amount.");
                }
                break;

            case "3":
                Console.Write("Enter amount to deposit: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
                {
                    customer.Deposit(depositAmount);
                }
                else
                {
                    Console.WriteLine("Invalid amount.");
                }
                break;

            case "4":
                Console.WriteLine("Goodbye!");
                return;

            default:
                Console.WriteLine("Invalid option.");
                break;
        }

        Console.Write("Do you want to perform another action (Y/N)? ");
        string continueAction = Console.ReadLine();
        if (continueAction.ToUpper() != "Y")
        {
            Console.WriteLine("Goodbye!");
            break; 
        }
    }
}
static Customer Authenticate(Customer[] customers)
{
    Console.Write("Enter your card number (or enter register if you like to register a new card): ");
    string cardNumberInput = Console.ReadLine().Replace("-", "");

    if (cardNumberInput.ToLower() == "register")
    {
        RegisterNewCard(customers);
        return null;
    }

    if (long.TryParse(cardNumberInput, out long cardNumber))
    {
        Customer customer = null;
        foreach (var c in customers)
        {
            if (c != null && c.CardNumber == cardNumber)
            {
                customer = c;
                break;
            }
        }

        if (customer != null)
        {
            int pinAttempts = 0;
            while (pinAttempts < 3)
            {
                Console.Write("Enter your PIN: ");
                string pin = Console.ReadLine();

                if (customer.IsPinCorrect(pin))
                {
                    return customer;
                }
                else
                {
                    pinAttempts++;
                    Console.WriteLine($"Incorrect PIN. {3 - pinAttempts} attempts remaining.");
                }
            }
            Console.WriteLine("Too many incorrect attempts. Please try again later.");
        }

        else
        {
            Console.WriteLine("Card number not found.Try again or type 'register' to create a new card.");
        }
    }
    else
    {
        Console.WriteLine("Invalid card number format.");
    }
    return null;

}
static void RegisterNewCard(Customer[] customers)
{
    Console.WriteLine("\n-----------------Registration------------------");

    Console.Write("Enter First Name: ");
    string firstName = Console.ReadLine();

    Console.Write("Enter Last Name: ");
    string lastName = Console.ReadLine();

    long cardNumber;
    while (true)
    {
        Console.Write("Enter a 16-digit card number: ");
        string cardInput = Console.ReadLine().Replace("-", "");

        if (long.TryParse(cardInput, out cardNumber) && cardInput.Length == 16)
        {
            if (CardExists(cardNumber, customers))
            {
                Console.WriteLine("This card number is already in use. Try again.");
            }
            else
            {
                break;
            }
        }
        else
        {
            Console.WriteLine("Invalid card number. Please enter a valid 16-digit number.");
        }
    }

    Console.Write("Enter a 4-digit PIN: ");
    string pin;
    while (true)
    {
        pin = Console.ReadLine();
        if (pin.Length == 4 && int.TryParse(pin, out _))
        {
            break;
        }
        Console.WriteLine("Invalid PIN. Please enter exactly 4 digits.");
    }

    decimal initialBalance;
    while (true)
    {
        Console.Write("Enter initial deposit amount: ");
        if (decimal.TryParse(Console.ReadLine(), out initialBalance) && initialBalance >= 0)
        {
            break;
        }
        Console.WriteLine("Invalid amount. Please enter a positive number.");
    }

    Customer newCustomer = new Customer(firstName, lastName, cardNumber, pin, initialBalance);
    AddCustomer(newCustomer, customers);

}

static bool CardExists(long cardNumber, Customer[] customers)
{
    foreach (var c in customers)
    {
        if (c != null && c.CardNumber == cardNumber)
        {
            return true;
        }
    }
    return false;
}

static void AddCustomer(Customer customer,  Customer[] customers)
{
    for (int i = 0; i < customers.Length; i++)
    {
        if (customers[i] == null)
        {
            customers[i] = customer;
            Console.WriteLine("Registration successful! You can now log in.");
            return;
        }
    }
   
    Console.WriteLine("Registration failed! The system has reached the maximum number of customers.");

}