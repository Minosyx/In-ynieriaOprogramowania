using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Model
{
    public struct Size
    {
        public int Width, Height;

        public override string ToString() => $"{Width} x {Height}";
    }
    public class ConsoleSettings : ICloneable
    {
        public ConsoleColor BackgroundColor, FontColor;
        public Size WindowSize, BufferSize;
        public string Title;

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.Append($"Background color: {BackgroundColor}");
            s.Append($"\nFont color: {FontColor}");
            s.Append($"\nWindow size: {WindowSize}");
            s.Append($"\nBuffer size: {BufferSize}");
            s.Append($"\nTitle: {Title}");
            return s.ToString();
        }

        public object Clone()
        {
            return new ConsoleSettings
            {
                BackgroundColor = this.BackgroundColor,
                FontColor = this.FontColor,
                WindowSize = this.WindowSize,
                BufferSize = this.BufferSize,
                Title = this.Title
            };
        }
    }
}
