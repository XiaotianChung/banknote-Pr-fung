using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace banknote_Prüfung
{
    class Program
    {
        static void Main(string[] args)
        {
            string seriennummer,nochmal;
            Console.WriteLine("Geben sie die Seriennummer der Banknote ein:");
            seriennummer  = Console.ReadLine();
            

            bool überprüfen;
            do
            {
                if (seriennummer.Length != 12)
                {
                    Console.WriteLine("die seriennummer hat nicht die richtige Länge.");
                    überprüfen = false;
                }

                else if (char.IsLetter(seriennummer[0]) == false || char.IsLetter(seriennummer[1]) == false)
                {
                    Console.WriteLine("Die ersten zwei Zeichen müssen Buchstaben sein.");
                    überprüfen = false;
                }
                else if (Regex.IsMatch(seriennummer.Substring(2, seriennummer.Length - 2), "^[0-9]+$") == false)
                {
                    Console.WriteLine("die letzen zehn zeichen müssen Ziffern sein.");
                    überprüfen = true;
                }
            } while (überprüfen = false );

            int summe, stelle1, stelle2,rest, kontrollziffer;
            stelle1 = Convert.ToInt32(seriennummer[0] )- 64;
            stelle2 = Convert.ToInt32(seriennummer[1]) - 64;
            Console.WriteLine("Umwandlung:" + stelle1);

            summe = stelle1 + stelle2;
            for (int i = 2; i < seriennummer.Length-1; i++)
            {
                summe = summe + Convert.ToInt32(Convert.ToString(seriennummer[i]));
            }
            rest = summe % 9;
            kontrollziffer = Convert.ToInt32(Convert.ToString(seriennummer[11]));

            if (kontrollziffer == 7 - rest || (7 - rest == 0 && kontrollziffer == 9) || (7 - rest == -1 && kontrollziffer == 0))
            {
                Console.WriteLine("Die Seriennummer ist gültig!");
            }
            else
            {
                Console.WriteLine("Die Seriennummer ist nicht gültig!");
            }



            Console.WriteLine("Soll noch eine Seriennummer geprüft werden?(j/n)");
            nochmal = Console.ReadLine();

            while (nochmal == "j") ;

        
          

           
        }
    }
}
