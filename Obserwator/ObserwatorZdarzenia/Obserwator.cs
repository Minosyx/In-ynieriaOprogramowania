using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserwatorZdarzenia
{
    public class WartośćZmienionaEventArgs : EventArgs
    {
        public int Wartość;
    }

    public delegate void WartośćZmienionaEventHandler(object sender, WartośćZmienionaEventArgs e);

    public interface IObserwator
    {
        void Aktualizuj(object sender, WartośćZmienionaEventArgs e);
    }

    public class Dzielenie : IObserwator
    {
        private int wartość = 0;
        private int dzielnik;

        public Dzielenie(int dzielnik)
        {
            this.dzielnik = dzielnik;
        }

        public void Aktualizuj(object sender, WartośćZmienionaEventArgs e)
        {
            int dzielna = e.Wartość;
            wartość = dzielna / dzielnik;
            Console.WriteLine($"{dzielna} / {dzielnik} = {wartość}");
        }
    }

    public class Modulo : IObserwator
    {
        private int wartość = 0;
        private int dzielnik;

        public Modulo(int dzielnik)
        {
            this.dzielnik = dzielnik;
        }

        public void Aktualizuj(object sender, WartośćZmienionaEventArgs e)
        {
            int dzielna = e.Wartość;
            wartość = dzielna % dzielnik;
            Console.WriteLine($"{dzielna} % {dzielnik} = {wartość}");
        }
    }
    public class Podmiot
    {
        private int wartość;

        public event WartośćZmienionaEventHandler WartośćZmieniona;

        private void powiadom()
        {
            if (WartośćZmieniona != null) WartośćZmieniona(this, new WartośćZmienionaEventArgs() {Wartość = wartość});
        }

        public Podmiot()
        {
            wartość = 0;
        }

        public void ZmieńWartość(int nowaWartość)
        {
            wartość = nowaWartość;
            powiadom();
        }
    }
}
