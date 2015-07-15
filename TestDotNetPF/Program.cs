using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDotNetPF.Model;
using TestDotNetPF.Exceptions;

namespace TestDotNetPF
{
    partial class Program
    {
        static void Main(string[] args)
        {
            // voorwerpen maken
            IVoorwerpen[] voorwerpen = new IVoorwerpen[3];
            voorwerpen[0] = new Boekenrek(2.15d, 0.95d, 50m);

            Leesboek Boek = new Leesboek(new Genre { Leeftijd = 17 }, "titeltje", "auteurtje", 250m, "een onderwerp");
            Woordenboek Woordenboek = new Woordenboek(new Genre { Leeftijd = 18 }, "titeltjeW", "auteurtjeW", 20m, "Nederlands-Engels");

            voorwerpen[1] = Boek;
            voorwerpen[2] = Woordenboek;

            // print alle IVoorwerpen (gewoon lusje)
            Console.WriteLine("- gewoon lusje:");
            foreach (IVoorwerpen voorwerp in voorwerpen)
            {
                if (voorwerp != null)
                {
                    voorwerp.GegevensTonen();
                }
            }

            PrintTussenLijn();

            // print alle IVoorwerpen (delegate)
            Console.WriteLine("- delegate:");
            Action<IVoorwerpen[]> ToonDeGegevenes = voorwerpDinges =>
            {
                foreach (IVoorwerpen voorwerpje in voorwerpDinges) if (voorwerpje != null)
                    { voorwerpje.GegevensTonen(); }
            };
            ToonDeGegevenes(voorwerpen);

            PrintTussenLijn();

            // print totale winst            
            Console.WriteLine("totale winst = {0}", voorwerpen.Sum(voorwerp =>
            {
                if (voorwerp != null) return voorwerp.Winst;
                else return 0;
            }));

            //++++++ BEGIN extra blabla ++++++
            DoeExtras();
            //++++++ EINDE extra blabla ++++++

            // hou console open
            Console.WriteLine();
            Console.WriteLine("+----+ press <enter> to quit +----+");
            Console.Read();
        }       
    }
}
