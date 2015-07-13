using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDotNetPF.Model
{
    class Leesboek : Boek
    {
        public string Onderwerp { get; private set; }

        public override decimal Winst
        {
            get
            {
                return Aankoopprijs * 1.5m;
            }
        }

        public Leesboek(Genre genre, string titel, string auteur, decimal aankoopprijs, string onderwerp)
            : base(genre, titel, auteur, aankoopprijs)
        {
            this.Onderwerp = onderwerp;
        }

        public override void GegevensTonen()
        {
            Console.WriteLine(this.ToString());
        }

        // override Boek.ToString
        public override string ToString()
        {
            return base.ToString() + ", Onderwerp: " + Onderwerp;
        }
    }
}
