using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDotNetPF.Exceptions
{
    public class NegatiefGetalException : Exception
    {        
        private decimal getalValue;

        public decimal Getal
        {
            get
            {
                return getalValue;
            }
            set
            {
                getalValue = value;
            }
        }

        public NegatiefGetalException(string message, decimal getal)
            : base(message)
        {
            this.Getal = getal;
        }
    }
}
