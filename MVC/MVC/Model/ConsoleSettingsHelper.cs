using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Model
{
    public static class ConsoleSettingsHelper
    {
        public static ConsoleSettings CurrentSettings =>
            new ConsoleSettings
            {
                BackgroundColor = Console.BackgroundColor,
                FontColor = Console.ForegroundColor,
                WindowSize =
                {
                    Width = Console.WindowWidth,
                    Height = Console.WindowHeight,
                },
                BufferSize =
                {
                    Width = Console.BufferWidth,
                    Height = Console.BufferHeight,
                },
                Title = Console.Title
            };

        public static ConsoleSettings DefaultSettings { get; } = new ConsoleSettings
        {
            BackgroundColor = ConsoleColor.Black,
            FontColor = ConsoleColor.Gray,
            WindowSize = {Width = 120, Height = 30},
            BufferSize = {Width = 120, Height = 9001},
            Title = System.Reflection.Assembly.GetEntryAssembly().Location
        };
    }
}
