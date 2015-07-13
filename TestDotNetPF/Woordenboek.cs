using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDotNetPF.Model
{
    class Woordenboek : Boek
    {
        public string Taal { get; private set; }

        public override decimal Winst
        {
            get
            {
                return Aankoopprijs * 1.75m;
            }
        }

        public Woordenboek(Genre genre, string titel, string auteur, decimal aankoopprijs, string taal)
            : base(genre, titel, auteur, aankoopprijs)
        {
            this.Taal = taal;
        }

        public override void GegevensTonen()
        {
            Console.WriteLine(this.ToString());
        }

        // override Boek.ToString
        public override string ToString()
        {
            return base.ToString() + ", Taal: " + Taal;
        }
    }
}
