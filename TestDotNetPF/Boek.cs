using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDotNetPF.Exceptions;

namespace TestDotNetPF.Model
{
    abstract class Boek : IVoorwerpen
    {

        public abstract decimal Winst
        {
            get;
        }

        private static string eigenaarValue = "VDAB";

        public static string Eigenaar
        {
            get { return eigenaarValue; }
        }

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

        private string titelValue;

        public string Titel
        {
            get { return titelValue; }
            set 
            {
                if (!String.IsNullOrWhiteSpace(value))
                    titelValue = value;
                else throw new ArgumentException("moet een zinnige inhoud hebben ...", "Titel");
            }
        }

        private string auteurValue;

        public string Auteur
        {
            get { return auteurValue; }
            set 
            { 
                if (!String.IsNullOrWhiteSpace(value)) 
                    auteurValue = value;
                else throw new ArgumentException("moet een zinnige inhoud hebben ...", "Auteur");
            }
        }

        public Genre Genre { get; private set; }

        protected Boek(Genre genre, string titel, string auteur, decimal aankoopprijs)
        {
            this.Genre = genre;
            this.Titel = titel;
            this.Auteur = auteur;
            this.Aankoopprijs = aankoopprijs;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            // titel en auteur idem => zelfde boek ; quick (and dirty ;-) )          
            return this.Titel.Equals(((Boek)obj).Titel) && this.Auteur.Equals(((Boek)obj).Auteur);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            // analoog met Equals: HashCode gebaseerd op Titel en Auteur            
            return this.Titel.GetHashCode() + this.Auteur.GetHashCode();
        }

        // override object.ToString
        public override string ToString()
        {
            StringBuilder BoekToString = new StringBuilder();
            BoekToString.Append("Eigenaar: " + Eigenaar);
            BoekToString.Append(", Titel: " + Titel);
            BoekToString.Append(", Auteur: " + Auteur);
            BoekToString.Append(", Genre: " + Genre);
            BoekToString.Append(", Aankoopprijs: " + Aankoopprijs);
            BoekToString.Append(", Winst: " + Winst);
            return BoekToString.ToString();
        }

        public abstract void GegevensTonen();
    }
}
