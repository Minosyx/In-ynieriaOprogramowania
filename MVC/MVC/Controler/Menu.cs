using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;
using MVC.View;

namespace MVC.Controler
{
    using static Entry;
    using Model;
    using Interfaces;

    public interface ILockable
    {
        static bool Lock { get; set; }
    }

    public class Menu : Feedable<ConsoleSettings>, ILockable
    {
        private ConsoleSettings _settings, _previouSettings = ConsoleSettingsHelper.CurrentSettings;

        public static bool Lock { get; set; }

        private List<ConsoleSettings> settingsList = new List<ConsoleSettings>();
        private static int index = 0;

        public static void IncreaseIndex()
        {
            index++;
        }

        public static void DecreaseIndex()
        {
            index--;
        }

        //public Dictionary<int, Item> Data { get; init; }


        public Menu(ConsoleSettings settings, Dictionary<int, Item<ConsoleSettings>> entries)
        {
            this._settings = settings;
            Data = entries;
            TryApplying();
        }

        private void TryApplying()
        {
            if (!Lock && ConsoleSettingsInjector.ApplySettings(_settings))
            {
                settingsList.Add((ConsoleSettings) _settings.Clone());
                index = settingsList.Count - 1;
                //_previouSettings = (ConsoleSettings) _settings.Clone();
            }
            else if (Lock)
            {
                if (index < 0) index++;
                else if (index >= settingsList.Count) index--;
                _settings = settingsList[index];
                ConsoleSettingsInjector.ApplySettings(_settings);
            }
            else
            {
                Console.Error.WriteLine("Przywracam poprzednie ustawienia");
                //ConsoleSettingsInjector.ApplySettings(_previouSettings);
                _settings = settingsList.Last();
                ConsoleSettingsInjector.ApplySettings(_settings);
            }
        }

        public void Run()
        {
            int choice = 0;
            do
            {
                ConsoleSettingsInjector.ShowMenu(Data);
                choice = GetInteger("Wybierz pozycję z menu wpisując liczbę i naciskając klawisz Enter: ", 6);
                Lock = false;
                if (Data.ContainsKey(choice))
                    Data[choice].Action.Invoke(_settings);
                else Lock = true;
                //switch (choice)
                //{
                //    case 1:
                //        Console.WriteLine("Przywracam ustawienia domyślne");
                //        _settings.BackgroundColor = ConsoleSettingsHelper.DefaultSettings.BackgroundColor;
                //        _settings.FontColor = ConsoleSettingsHelper.DefaultSettings.FontColor;
                //        _settings.WindowSize = ConsoleSettingsHelper.DefaultSettings.WindowSize;
                //        _settings.BufferSize = ConsoleSettingsHelper.DefaultSettings.BufferSize;
                //        _settings.Title = ConsoleSettingsHelper.DefaultSettings.Title;
                //        break;
                //    case 2:
                //        ConsoleColor backgroundColor = GetColor("Podaj kolor tła (po angielsku): ");
                //        _settings.BackgroundColor = backgroundColor;
                //        break;
                //    case 3:
                //        ConsoleColor fontColor = GetColor("Podaj kolor czcionki (po angielsku): ");
                //        _settings.FontColor = fontColor;
                //        break;
                //    case 4:
                //    {
                //        int x = GetInteger("Podaj szerokość okna: ", Console.LargestWindowWidth);
                //        int y = GetInteger("Podaj wysokość okna: ", Console.LargestWindowHeight);
                //        Size size = new Size
                //        {
                //            Width = x,
                //            Height = y
                //        };
                //        _settings.WindowSize = size;
                //    }
                //        break;
                //    case 5:
                //    {
                //        int x = GetInteger("Podaj szerokość bufora: ", short.MaxValue);
                //        int y = GetInteger("Podaj wysokość bufora: ", short.MaxValue);
                //        Size size = new Size
                //        {
                //            Width = x,
                //            Height = y
                //        };
                //        _settings.BufferSize = size;
                //    }
                //        break;
                //    case 6:
                //        Console.Write("Podaj tytuł okna: ");
                //        string title = Console.ReadLine();
                //        _settings.Title = title;
                //        break;
                //}
                TryApplying();
            } while (choice != 0);
        }
    }
}
