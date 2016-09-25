using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ShoskesBankAccountProject
{
    class SavingsAccount : Account
    {
        //Fields

        public string accountName;
        public string accountSettings;

        //Properties

        //Constructors

        public SavingsAccount(string id) : base("Savings", id)
        {
            //follows the default constructor, but passes in the savings type
        }

        //Methods

        //Can't order checks from a savings account!
        public override void OrderChecks(double numberOfChecks)
        {
            Console.WriteLine("Sorry, we don't allow checks to be ordered from savings");
            Console.WriteLine("accounts. Part of our ultra-mega security!");
        }
        //Setting the check color
        public override void SetCheckColor(string color)
        {
            Console.WriteLine("Your checks are now {0}, this makes perfect sense!", color);
            this.CheckColor = color;
        }
    }
}
