using System;
using UMK;

namespace Singleton12
{
    class Program
    {
        private static Log log1 = Log.Instancja;

        static Program()
        {
            log1.Dodaj("Konstruktor statyczny klasy Program");
        }

        static void Main(string[] args)
        {            
            Log log2 = Log.Instancja;
            log2.Dodaj("Metoda Main klasy Program");
            new DeepSpace();

            for (int i = 0; i < 20; ++i) Log.Instancja.Dodaj(i.ToString());

            //log2.Zapisz("log" + DateTime.Now.ToString().Replace(':','-').Replace('/','-') + ".txt");
            string suffix = DateTime.Now.ToString().Replace(':', '-').Replace('/', '-') + ".txt";
            Log.Zapisz("log1 " + suffix, "log2 " + suffix);            
        }
    }
}
