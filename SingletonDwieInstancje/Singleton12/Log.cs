using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UMK
{
    public sealed class Log
    {
        #region Singleton
        /*
        private static Log instancja = new Log();

        private Log()
        {
        }

        public static Log Instancja => instancja;
        */

        private static Log instancja1 = null, instancja2 = null;
        private static bool ostaniaByłaInstancja1 = false;

        private Log()
        {
        }

        public static Log Instancja
        {
            get
            {
                if (!ostaniaByłaInstancja1)
                {
                    if (instancja1 == null) instancja1 = new Log();
                    ostaniaByłaInstancja1 = true;
                    return instancja1;
                }
                else
                {
                    if (instancja2 == null) instancja2 = new Log();
                    ostaniaByłaInstancja1 = false;
                    return instancja2;
                }
            }
        }
        #endregion

        private List<string> komunikaty = new List<string>();

        public void Dodaj(string komunikat)
        {
            komunikaty.Add(DateTime.Now.ToString() + "; " + Environment.MachineName + "; " + komunikat);
        }

        private void zapisz(string ścieżkaPliku)
        {
            File.AppendAllLines(ścieżkaPliku, komunikaty);
        }

        public static void Zapisz(string ścieżkaPliku1, string ścieżkaPliku2)
        {
            instancja1.zapisz(ścieżkaPliku1);
            instancja2.zapisz(ścieżkaPliku2);
        }
    }
}
