using System;

namespace Dekorator12
{
    static class Program
    {
        static void WyświetlInformacjeONapoju(this Napój napój)
        {
            Console.Write(napój.ToString());
            Console.WriteLine(napój.Cena());
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Ile dodać plastrów cytryny? ");
            string s = Console.ReadLine();
            try
            {
                int l = int.Parse(s);
                Napój herbata = MenuNapojów.HerbataZCytryną(l);
                herbata.WyświetlInformacjeONapoju();
            }
            catch (Exception exc)
            {
                Console.WriteLine("Błąd: " + exc.Message);
            }

            Console.WriteLine("Ile dodać łyżeczek cukru? ");
            string s1 = Console.ReadLine();
            Console.WriteLine("Ile dodać szczypt cynamonu? ");
            string s2 = Console.ReadLine();
            try
            {
                int l1 = int.Parse(s1);
                Console.WriteLine(l1);
                int l2 = int.Parse(s2);
                Console.WriteLine(l2);
                Napój kawa = MenuNapojów.KawaPiernikowa(l1, l2);
                kawa.WyświetlInformacjeONapoju();
            }
            catch(Exception exc)
            {
                Console.WriteLine("Błąd: " + exc.Message);
            }
        }
    }
}
