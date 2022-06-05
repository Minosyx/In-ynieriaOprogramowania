using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obserwator
{
    public interface IObserwator
    {
        void Aktualizuj(int parametr);
    }

    public class Dzielenie : IObserwator
    {
        private int wartość = 0;
        private int dzielnik;

        public Dzielenie(int dzielnik)
        {
            this.dzielnik = dzielnik;
        }

        public void Aktualizuj(int dzielna)
        {
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

        public void Aktualizuj(int dzielna)
        {
            wartość = dzielna % dzielnik;
            Console.WriteLine($"{dzielna} % {dzielnik} = {wartość}");
        }
    }
    public class Podmiot
    {
        private int wartość;
        private List<IObserwator> obserwatorzy = new List<IObserwator>();

        private void powiadom()
        {
            foreach (IObserwator obserwator in obserwatorzy) obserwator.Aktualizuj(wartość);
        }

        public void PrzyłączObserwator(IObserwator obserwator)
        {
            if (!obserwatorzy.Contains(obserwator)) obserwatorzy.Add(obserwator);
        }

        public void OdłączObserwator(IObserwator obserwator)
        {
            if (obserwatorzy.Contains(obserwator)) obserwatorzy.Remove(obserwator);
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
