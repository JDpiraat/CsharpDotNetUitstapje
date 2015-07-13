using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestDotNetPF.Exceptions;

namespace TestDotNetPF.Model
{
    class Genre
    {
        public enum Doelgroep
        {
            Jeugd,
            Volwassenen
        }

        public Doelgroep Categorie { get; private set; }

        private int leeftijdValue;

        public int Leeftijd
        {
            get { return leeftijdValue; }
            set
            {
                if (value >= 0)
                {
                    leeftijdValue = value;
                    Categorie = (value < 18) ? Doelgroep.Jeugd : Doelgroep.Volwassenen;
                }
                else throw new NegatiefGetalException("Een negatieve leeftijd kan echt niet toegelaten worden", value);
            }
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            // eens niet het auto-gegenereerde gebruiken ...
            if (obj is Genre)
            {
                Genre other = (Genre)obj;
                return this.Leeftijd == other.Leeftijd;
            }
            else
                return false;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {            
            return this.Leeftijd.GetHashCode();
        }

        // override object.ToString
        public override string ToString()
        {
            return Categorie + " (" + Leeftijd + "jaar)";
        }

    }
}
