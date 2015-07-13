using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestDotNetPF.Exceptions;

namespace TestDotNetPF.Model
{
    class Boekenrek : IVoorwerpen
    {
        // hier geen controles op: ook negatieve dimensies kunnen => WHOEHA!!!HA!!! flipie
        public double Hoogte { get; private set; }
        public double Breedte { get; private set; }

        private decimal aankoopprijsValue;

        public decimal Aankoopprijs
        {
            get { return aankoopprijsValue; }
            set
            {
                if (value >= 0m)
                    aankoopprijsValue = value;
                else throw new NegatiefGetalException("Aankoopprijs mag niet negatief zijn", value);
            }
        }

        public decimal Winst
        {
            get
            {
                return Aankoopprijs * 2;
            }
        }

        public Boekenrek(double hoogte, double breedte, decimal aankoopprijs)
        {
            this.Hoogte = hoogte;
            this.Breedte = breedte;
            this.Aankoopprijs = aankoopprijs;
        }

        public void GegevensTonen()
        {
            // dat euroteken ... pfff... ook '@' wil niet
            Console.WriteLine("Boekenrek {0} \u20AC ({1}hoogte*{2}breedte), winst = {3}", Aankoopprijs, Hoogte, Breedte, Winst);
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Boekenrek Other = (Boekenrek)obj;
            return (this.Hoogte == Other.Hoogte && this.Breedte == Other.Breedte && this.Aankoopprijs == Other.Aankoopprijs);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            int HashCode = 13 + (int)Hoogte * 17;
            HashCode = HashCode * 100 + (int)Breedte * 17;
            HashCode = HashCode * 100 + (int)Aankoopprijs * 17;
            return HashCode;
        }

        // override object.ToString
        public override string ToString()
        {
            return string.Format("Dit is een boekenrek ({0}h*{1}b).", Hoogte, Breedte);
        }
    }
}
