using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ShoskesBankAccountProject
{
    abstract class Account
    {
        //Fields
        private double balance;
        private string accountType;
        private string userID;
        private string checkColor;

        //Properties
        
        public double Balance
        {
            get { return this.Balance; }
        }

        public string AccountType
        {
            get { return this.accountType; }
            set { this.accountType = value; }
        }
        public string UserID
        {
            get { return this.userID; }
            set { this.userID = value; }
        }

        public string FileName
        {
            get { return this.userID + "_" + this.accountType + ".txt"; }
        }

        public string CheckColor
        {
            get { return this.checkColor; }
            set { this.checkColor = value; }
        }

        //Constructors

        public Account(string type, string id)
        {
            accountType = type;
            userID = id;
            //balance = FindLastBalance(type, id);
            balance = 0.0;
            checkColor = "blue";
        }

        //Methods

        //My attempt at finding the last balance from the file and using it as 
        //the starting balance. Right now, it doesn't work

        //private double FindLastBalance(string type, string id)
        //{
        //    string lastLine = "0 0";
        //    try {
        //        StreamReader reader = new StreamReader(id+"_"+type+".txt");
        //        StreamReader nextReader = new StreamReader(id + "_" + type + ".txt");
        //        string line = reader.ReadLine();
        //        while (line != null)
        //        {
        //            line = reader.ReadLine();
        //            if (line != null && line.Contains(' '))
        //            {
        //                lastLine = line;
        //            }
        //        }
        //        reader.Close();
        //        string[] lineArray;
        //        lineArray = lastLine.Split(' ');
        //        Console.WriteLine(lastLine);
        //        Console.ReadKey();
        //        string startingBalance = lineArray[(lineArray.Length - 1)].Remove('$');

        //        return Double.Parse(startingBalance);
        //    }
        //    catch (IOException)
        //    {
        //        return 0.0;
        //    }
        //}

        //The withdrawing method
        public void Withdraw(double amount)
        {
            if (amount < balance)
            {
                balance -= amount;
                string withdrawText = "Withdrawing $" + amount + " from " + accountType;
                string fileText = userID + " " + " " + accountType + " " + DateTime.Now + " -" + amount + " " + balance;
                StreamWriter writer = new StreamWriter(FileName, true);
                Console.WriteLine(withdrawText);
                writer.WriteLine(fileText);
                string balanceText = ViewAccountBalance(true);
                writer.WriteLine(balanceText);
                writer.Close();
            }
            else
            {
                Console.WriteLine("I'm sorry, you do not have enough money in your account for this withdrawl.");
            }
        }

        //The depositing method
        public void Deposit(double amount)
        {
            balance += amount;
            string depositText = "Depositing $" + amount + " to " + accountType;
            string fileText = userID+" "+" "+accountType+" "+DateTime.Now+" +"+amount+" "+balance;
            StreamWriter writer = new StreamWriter(FileName, true);
            Console.WriteLine(depositText);
            writer.WriteLine(fileText);
            string balanceText = ViewAccountBalance(true);
            writer.WriteLine(balanceText);
            writer.Close();
        }
        //The view account balance method
        public string ViewAccountBalance(bool writeToConsole)
        {
            string balanceText = "The most recent balance on your " + accountType + " is $" + balance;
            if (balance < 0)
            {
                balanceText += "\nYOU ARE IN DEBT!";
            }
            if (writeToConsole)
            {
                Console.WriteLine(balanceText);
            }
            return balanceText;
        }
        public abstract void OrderChecks(double numberOfChecks);
        public abstract void SetCheckColor(string color);
    }
}
