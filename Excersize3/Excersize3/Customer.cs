using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excersize3
{
    class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long CardNumber { get; private set; }
        private string Pin { get; set; }
        private decimal Balance { get; set; }

        public Customer(string firstName, string lastName, long cardNumber, string pin, decimal balance)
        {
            FirstName = firstName;
            LastName = lastName;
            CardNumber = cardNumber;
            Pin = pin;
            Balance = balance;
        }

        public decimal GetBalance()
        {
            return Balance;
        }
        public void Withdraw(decimal amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;

                Console.WriteLine($"Successfully withdrew ${amount:f2}.");
                Console.WriteLine($"Your new balance is: ${Balance:f2}.");
            }
            else
            {
                Console.WriteLine("Insufficient funds for withdrawal.");
            }
            
        }
        public void Deposit(decimal amount)
        {
            Balance += amount;
            Console.WriteLine($"Successfully deposited ${amount:N2}. Your new balance is: ${Balance:N2}.");
        }
        public bool IsPinCorrect(string pin)
        {
            return Pin == pin;
        }
    }
}
