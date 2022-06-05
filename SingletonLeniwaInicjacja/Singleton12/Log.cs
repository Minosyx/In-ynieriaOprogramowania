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

        private static Log instancja = null;

        private Log()
        {
        }

        public static Log Instancja
        {
            get
            {
                if (instancja == null) instancja = new Log();
                return instancja;
            }
        }
        #endregion

        private List<string> komunikaty = new List<string>();

        public void Dodaj(string komunikat)
        {
            komunikaty.Add(DateTime.Now.ToString() + "; " + Environment.MachineName + "; " + komunikat);
        }

        public void Zapisz(string ścieżkaPliku)
        {
            File.AppendAllLines(ścieżkaPliku, komunikaty);
        }
    }
}
