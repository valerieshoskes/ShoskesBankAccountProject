using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ShoskesBankAccountProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string userID;
            Console.WriteLine("Welcome to the banking app for John Doe and Bob Smith!");
            Console.WriteLine("John, is that you? Type yes if it is.");
            string johnPassword = Console.ReadLine();
            if (johnPassword.ToLower() == "yes")
            {
                Console.WriteLine("Welcome John.");
                userID = "Doe_John_01";
            }
            else
            {
                Console.WriteLine("Welcome Bob.");
                userID = "Smith_Bob_02";
            }
            SavingsAccount userSavingsAccount = new SavingsAccount(userID);
            CheckingAccount userCheckingAccount = new CheckingAccount(userID);
            ReserveAccount userReserveAccount = new ReserveAccount(userID);
            string accountOption;
            bool quitting = false;
            do
            {
                Console.WriteLine("Which account would you like to view?");
                Console.WriteLine("\t1 Checking");
                Console.WriteLine("\t2 Savings");
                Console.WriteLine("\t3 Reserve");
                Console.WriteLine("\t Any other input: Close the program.");
                accountOption = Console.ReadLine();
                switch (accountOption)
                {
                    case "1":
                        AccountOptions(userCheckingAccount);
                        break;
                    case "2":
                        AccountOptions(userSavingsAccount);
                        break;
                    case "3":
                        AccountOptions(userReserveAccount);
                        break;
                    default:
                        Console.WriteLine("Goodbye");
                        quitting = true;
                        break;
                }
            }
            while (!quitting);
        }
        //The method for displaying the account menu and calling the 
        //class methods on the accounts
        public static void AccountOptions(Account userAccount)
        {
            bool quitting = false;
            do
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("\t1 Deposit");
                Console.WriteLine("\t2 Withdraw");
                Console.WriteLine("\t3 View Balance");
                Console.WriteLine("\t4 Order Checks");
                Console.WriteLine("\t5 Set Check Design");
                Console.WriteLine("\tAny other input: Return to account selection menu.");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Console.WriteLine("How much are you depositing?");
                        try
                        {
                            userAccount.Deposit(Double.Parse(Console.ReadLine()));
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input, please enter a numeric amount.");
                        }
                        break;
                    case "2":
                        Console.WriteLine("How much are you withdrawing?");
                        try
                        {
                            userAccount.Withdraw(Double.Parse(Console.ReadLine()));
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input, please enter a numeric amount.");

                        }
                        break;
                    case "3":
                        userAccount.ViewAccountBalance(true);
                        break;
                    case "4":
                        Console.WriteLine("How many boxes of checks would you like? They are $5 apiece with a(n) {0} design.", userAccount.CheckColor);
                        try
                        {
                            double numberOfChecks = Double.Parse(Console.ReadLine());
                            userAccount.OrderChecks(numberOfChecks);
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Invalid input, please enter a numeric amount.");
                            break;
                        }
                    case "5":
                        Console.WriteLine("What design would you like for your checks?");
                        string design = Console.ReadLine();
                        userAccount.SetCheckColor(design);
                        break;
                    default:
                        Console.WriteLine("Goodbye.");
                        quitting = true;
                        break;
                }
            }
            while (!quitting);
        
    }
    }
}
