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
        private static void PrintTussenLijn()
        {
            Console.WriteLine();
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine();
        }

        private static void DoeExtras()
        {
            Console.WriteLine();
            Console.WriteLine("++++++++++++++++ EXTRA (poor man's testing ;-) ) +++++++++++++++");
            Console.WriteLine();
            // check negatieve aankoopprijs boek
            try
            {
                Leesboek boek2 = new Leesboek(new Genre { Leeftijd = 17 }, "titeltje", "auteurtje", -250m, "een onderwerp");
            }
            catch (NegatiefGetalException ex)
            {
                Console.WriteLine("Fout:" + ex.Message + ':' + ex.Getal);
            }

            // check negatieve leeftijd
            try
            {
                Woordenboek woordenboek2 = new Woordenboek(new Genre { Leeftijd = -5 }, "titeltjeW", "auteurtjeW", 20m, "Nederlands-Engels");
            }
            catch (NegatiefGetalException ex)
            {
                Console.WriteLine("Fout:" + ex.Message + ':' + ex.Getal);
            }

            // check negatieve aankoopprijs boekenrek
            try
            {
                IVoorwerpen eenBoekenrekVoorwerp = new Boekenrek(2.15d, 0.95d, -50m);
                // check toegankelijkheid readonly property: da ga dus nie, joepi...?! : ((Boekenrek)EenBoekerrekVoorwerp).Breedte = 5d;
            }
            catch (NegatiefGetalException ex)
            {
                Console.WriteLine("Fout:" + ex.Message + ':' + ex.Getal);
            }

            // check lege Titel (Lees)Boek
            try
            {
                Leesboek boek3 = new Leesboek(new Genre { Leeftijd = 17 }, "   ", "auteurtje", 250m, "een onderwerp");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Fout:" + ex.Message);
            }

            // check null Auteur (Woorden)Boek
            try
            {
                Woordenboek woordenboek3 = new Woordenboek(new Genre { Leeftijd = 17 }, "jep", null, 250m, "een taal");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Fout:" + ex.Message);
            }
        }
    }
}
