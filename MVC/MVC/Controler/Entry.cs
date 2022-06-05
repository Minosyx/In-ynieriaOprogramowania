using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Controler
{
    using static Console;
    public static class Entry
    {
        private static readonly Func<string, int, string> _format = (x, start) =>
        {
            if (x.Any(char.IsWhiteSpace)) x = string.Join("", x.Split(" "));
            return char.ToUpper(x[start]) + x.ToLower().Substring(start + 1);
        };

        public static int GetInteger(string promtp, int maxValue, int minValue = 0)
        {
            int? number = null;
            do
            {
                try
                {
                    string s;
                    do
                    {
                        Write(promtp);
                        s = ReadLine();
                    } while (string.IsNullOrWhiteSpace(s));

                    number = int.Parse(s);
                    if (number < minValue || number > maxValue)
                        throw new Exception("Niepoprawna wartość liczby!");
                }
                catch (Exception ex)
                {
                    WriteLine($"Błąd: {ex.Message}");
                    WriteLine("Niepoprawna wartość. Spróbuj jeszcze raz");
                }
            } while (!number.HasValue);
            return number.Value;
        }

        public static ConsoleColor GetColor(string prompt)
        {
            ConsoleColor? color = null;
            do
            {
                try
                {
                    string s;
                    do
                    {
                        Write(prompt);
                        s = ReadLine();
                        //s = char.ToUpper(s[0]) + s.ToLower().Substring(1);
                        s = _format(s, 0);
                        if (s.StartsWith("Dark") && s.Length > 5)
                            //s = $"Dark{char.ToUpper(s[4])}{s.ToLower().Substring(5)}";
                            s = $"Dark{_format(s, 4)}";
                    } while (string.IsNullOrWhiteSpace(s));

                    color = (ConsoleColor) Enum.Parse(typeof(ConsoleColor), s);
                }
                catch (Exception ex)
                {
                    WriteLine($"Błąd: {ex.Message}");
                    WriteLine("Niepoprawna nazwa koloru. Spróbuj jeszcze raz");
                }
            } while (!color.HasValue);

            return color.Value;
        }
    }
}
