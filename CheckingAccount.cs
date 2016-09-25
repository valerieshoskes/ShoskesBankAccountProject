using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ShoskesBankAccountProject
{
    class CheckingAccount : Account
    {
        //Fields

        public string accountName;
        public string accountSettings;

        //Properties

        public string AccountName
        {
            get { return this.accountName; }
            set { this.accountName = value; }
        }

        public string AccountSettings
        {
            get { return this.accountSettings; }
            set { this.accountSettings = value; }
        }

        //Constructors

        public CheckingAccount(string id) : base("Checking", id)
        {
            //follows the default constructor, but passes in the checking type
        }

        //Methods

        //The method for ordering checks
        public override void OrderChecks(double numberOfChecks)
        {
            Console.WriteLine("Ordering {0} checkbooks with a {1} design at $5.00 apiece.", numberOfChecks, this.CheckColor);
            Withdraw(numberOfChecks * 5.00);
        }
        //Setting the check color
        public override void SetCheckColor(string color)
        {
            Console.WriteLine("Your checks are now {0}.", color);
            this.CheckColor = color;
        }
    }
}
