using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final.Models
{
    public class Mage : Adventurer
    {
        public Mage(string name) : base(name)
        {
            Type = "Mage";
        }

        protected override double StrengthMultiplier
        {
            get { return 0.5; }
        }

        protected override double ManaMultiplier
        {
            get { return 1.5; }
        }

        public override string Greeting()
        {
            return "Magic is all around us.";
        }
    }
}