using System.Reflection.Metadata.Ecma335;
using Interfaces;
using MVC.Model;

namespace MVC.Controler
{
    public class MenuTemplate : Feedable<ConsoleSettings>
    {
        public MenuTemplate()
        {
            Data = new Dictionary<int, Item<ConsoleSettings>>
            {
                [1] = new Item<ConsoleSettings>
                {
                    Text = "Przywróć ustawienia domyślne",
                    Action = (ConsoleSettings cs) =>
                    {
                        Console.WriteLine("Przywracam ustawienia domyślne");
                        cs.BackgroundColor = ConsoleSettingsHelper.DefaultSettings.BackgroundColor;
                        cs.FontColor = ConsoleSettingsHelper.DefaultSettings.FontColor;
                        cs.WindowSize = ConsoleSettingsHelper.DefaultSettings.WindowSize;
                        cs.BufferSize = ConsoleSettingsHelper.DefaultSettings.BufferSize;
                        cs.Title = ConsoleSettingsHelper.DefaultSettings.Title;
                    }
                },

                [2] = new Item<ConsoleSettings>
                {
                    Text = "Zmień kolor tła",
                    Action = (ConsoleSettings cs) =>
                    {
                        ConsoleColor backgroundColor = Entry.GetColor("Podaj kolor tła (po angielsku): ");
                        cs.BackgroundColor = backgroundColor;
                    }
                },

                [3] = new Item<ConsoleSettings>
                {
                    Text = "Zmień kolor czcionki",
                    Action = (ConsoleSettings cs) =>
                    {
                        ConsoleColor fontColor = Entry.GetColor("Podaj kolor czcionki (po angielsku): ");
                        cs.FontColor = fontColor;
                    }
                },

                [4] = new Item<ConsoleSettings>
                {
                    Text = "Zmień rozmiar okna",
                    Action = (ConsoleSettings cs) =>
                    {
                        int x = Entry.GetInteger("Podaj szerokość okna: ", Console.LargestWindowWidth);
                        int y = Entry.GetInteger("Podaj wysokość okna: ", Console.LargestWindowHeight);
                        Size size = new Size
                        {
                            Width = x,
                            Height = y
                        };
                        cs.WindowSize = size;
                    }
                },

                [5] = new Item<ConsoleSettings>
                {
                    Text = "Zmień rozmiar bufora",
                    Action = (ConsoleSettings cs) =>
                    {
                        int x = Entry.GetInteger("Podaj szerokość bufora: ", short.MaxValue);
                        int y = Entry.GetInteger("Podaj wysokość bufora: ", short.MaxValue);
                        Size size = new Size
                        {
                            Width = x,
                            Height = y
                        };
                        cs.BufferSize = size;
                    }
                },

                [6] = new Item<ConsoleSettings>
                {
                    Text = "Zmień tytuł okna",
                    Action = (ConsoleSettings cs) =>
                    {
                        Console.Write("Podaj tytuł okna: ");
                        string title = Console.ReadLine();
                        cs.Title = title;
                    }
                },
                [7] = new Item<ConsoleSettings>()
                {
                    Text = "Cofnij zmiany",
                    Action = (ConsoleSettings cs) =>
                    {
                        Menu.DecreaseIndex();
                        Menu.Lock = true;
                    }
                },
                [8] = new Item<ConsoleSettings>()
                {
                    Text = "Powtórz zmiany",
                    Action = (ConsoleSettings cs) =>
                    {
                        Menu.IncreaseIndex();
                        Menu.Lock = true;
                    }
                }
            };
        }
    }
}
