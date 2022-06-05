using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyłek
{
    public abstract class Znak
    {
        protected char litera;

        public Znak(char litera)
        {
            this.litera = litera;
        }

        public void Wyświetl(ConsoleColor kolor)
        {
            ConsoleColor originalnyKolor = Console.ForegroundColor;
            Console.ForegroundColor = kolor;
            Console.Write(litera);
            Console.ForegroundColor = originalnyKolor;
        }
    }

    class ZnakA : Znak
    {
        public ZnakA() : base('A'){}
    }

    class ZnakB : Znak
    {
        public ZnakB() : base('B'){}
    }

    class ZnakD : Znak
    {
        public ZnakD() : base('D'){}
    }

    class ZnakJ : Znak
    {
        public ZnakJ() : base('J'){}
    }

    class ZnakU : Znak
    {
        public ZnakU() : base('U'){}
    }

    class ZnakPusty : Znak
    {
        public ZnakPusty() : base('?'){}
    }

    class FabrykaZnaków
    {
        private Dictionary<char, Znak> znaki = new();

        public Znak PobierzZnak(char litera)
        {
            Znak znak = null;
            if (znaki.Keys.Contains(litera)) znak = znaki[litera];
            else
            {
                znak = litera switch
                {
                    'A' => new ZnakA(),
                    'B' => new ZnakB(),
                    'D' => new ZnakD(),
                    'J' => new ZnakJ(),
                    'U' => new ZnakU(),
                    _ => new ZnakPusty(),
                };
            }

            return znak;
        }
    }
}
