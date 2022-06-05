using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UMK
{
    public sealed class Log
    {
        #region Singleton
        private const int liczbaInstancji = 4;
        private static List<Log> logList = null;
        private static int index;

        private Log()
        {
        }

        public static Log Instancja
        {
            get
            {
                if (logList == null)
                {
                    logList = new List<Log>();
                    index = -1;
                }

                index++;
                if (index >= liczbaInstancji)
                {
                    index = 0;
                    return logList[index];
                }

                if (index >= logList.Count)
                {
                    logList.Add(new Log());
                }

                return logList[index];
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

        public static void Zapisz(params string[] ścieżkiPliku)
        {
            IEnumerator e = logList.GetEnumerator();
            foreach (var path in ścieżkiPliku)
            {
                if (e.MoveNext())
                    (e.Current as Log).zapisz(path);
                else
                    break;
            }
        }
    }
}
