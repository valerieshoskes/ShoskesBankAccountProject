﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ShoskesBankAccountProject
{
    class ReserveAccount : Account
    {
        //Fields

        public string accountName;
        public string accountSettings;

        //Properties

        //Constructors

        public ReserveAccount(string id) : base("Reserve", id)
        {
            //follows the default constructor, but passes in the reserve type
        }

        //Methods
        //Can't order checks from a reserve account!
        public override void OrderChecks(double numberOfChecks)
        {
            Console.WriteLine("Sorry, we don't allow checks to be ordered from reserve accounts.");
        }
        //Setting the check color
        public override void SetCheckColor(string color)
        {
            Console.WriteLine("Your checks are now {0}.", color);
            this.CheckColor = color;
        }
    }
}
