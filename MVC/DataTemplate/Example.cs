using Interfaces;

namespace DataTemplate
{
    public class Example : Feedable
    {
        public Example()
        {
            Data[1] = new Item
            {
                Text = "Przywróć ustawienia domyślne",
                Action = () =>
                {
                    Console.WriteLine("Przywracam ustawienia domyślne");
                    _settings.BackgroundColor = ConsoleSettingsHelper.DefaultSettings.BackgroundColor;
                    _settings.FontColor = ConsoleSettingsHelper.DefaultSettings.FontColor;
                    _settings.WindowSize = ConsoleSettingsHelper.DefaultSettings.WindowSize;
                    _settings.BufferSize = ConsoleSettingsHelper.DefaultSettings.BufferSize;
                    _settings.Title = ConsoleSettingsHelper.DefaultSettings.Title;
                }
            };
        }
    }
}