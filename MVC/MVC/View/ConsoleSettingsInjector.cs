using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using MVC.Model;

namespace MVC.View
{
    using Model;
    using static Interfaces.Feedable<ConsoleSettings>;

    public class ConsoleSettingsInjector
    {
        public static void ShowMenu(Dictionary<int, Item<ConsoleSettings>> Data)
        {
            StringBuilder s = new StringBuilder();
            s.AppendLine("\nMenu:");
            foreach (var entry in Data)
            {
                s.AppendLine($"{entry.Key}. {entry.Value.Text}");
            }
            //s.AppendLine("1. Przywróć ustawienia domyślne");
            //s.AppendLine("2. Zmień kolor tła");
            //s.AppendLine("3. Zmień kolor czcionki");
            //s.AppendLine("4. Zmień rozmiar okna");
            //s.AppendLine("5. Zmień rozmiar bufora");
            //s.AppendLine("6. Zmień tytuł okna");
            //s.AppendLine("0. Zakończ program");
            Console.WriteLine(s);
        }

        public static bool ApplySettings(ConsoleSettings settings, bool clearConsole = true)
        {
            try
            {
                Console.BackgroundColor = settings.BackgroundColor;
                Console.ForegroundColor = settings.FontColor;
                Console.SetWindowSize(settings.WindowSize.Width, settings.WindowSize.Height);
                Console.SetBufferSize(settings.BufferSize.Width, settings.BufferSize.Height);
                Console.Title = settings.Title;
                if (clearConsole) Console.Clear();
                return true;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Wystąpił błąd: {ex.Message}");
                return false;
            }
        }
    }
}
