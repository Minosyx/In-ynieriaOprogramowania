using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observable
{
    public interface IObserwator
    {
        void Aktualizuj(int parametr);
    }

    public abstract class Obserwator : IObserver<int>
    {
        protected int wartość = 0;
        protected int dzielnik;

        public Obserwator(int dzielnik)
        {
            this.dzielnik = dzielnik;
        }

        public void OnCompleted()
        {
            Console.WriteLine("Działanie obserwabli zakończone");
        }

        public void OnError(Exception error)
        {
            Console.Error.WriteLine($"Błąd obserwabli {error.Message}");
        }

        public abstract void OnNext(int value);
    }

    public class Dzielenie : Obserwator
    {
        public Dzielenie(int dzielnik) : base(dzielnik)
        {}

        public override void OnNext(int dzielna)
        {
            wartość = dzielna / dzielnik;
            Console.WriteLine($"{dzielna} / {dzielnik} = {wartość}");
        }
    }

    public class Modulo : Obserwator
    {
        public Modulo(int dzielnik) : base(dzielnik)
        {}

        public override void OnNext(int dzielna)
        {
            wartość = dzielna % dzielnik;
            Console.WriteLine($"{dzielna} % {dzielnik} = {wartość}");
        }

    }
    public class Podmiot : IObservable<int>
    {
        private int wartość;
        private List<IObserver<int>> obserwatorzy = new();

        private void powiadom()
        {
            foreach (IObserwator obserwator in obserwatorzy) obserwator.Aktualizuj(wartość);
        }

        public IDisposable Subscribe(IObserver<int> obserwator)
        {
            if (!obserwatorzy.Contains(obserwator)) obserwatorzy.Add(obserwator);
            return new Unsubscriber(obserwatorzy, obserwator);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<int>> obserwatorzy;
            private IObserver<int> obserwator;

            public Unsubscriber(List<IObserver<int>> obserwatorzy, IObserver<int> obserwator)
            {
                this.obserwatorzy = obserwatorzy;
                this.obserwator = obserwator;
            }

            public void Dispose()
            {
                if (obserwator != null && obserwatorzy.Contains(obserwator))
                    obserwatorzy.Remove(obserwator);
            }
        }

        public void Zakończ()
        {
            foreach (IObserver<int> observer in obserwatorzy)
                observer.OnCompleted();
            obserwatorzy.Clear();
        }

        public Podmiot()
        {
            wartość = 0;
        }

        public void ZmieńWartość(int? nowaWartość)
        {
            foreach (IObserver<int> observer in obserwatorzy)
            {
                if (!nowaWartość.HasValue) observer.OnError(new NullReferenceException("Brak wartości"));
                else
                {
                    wartość = nowaWartość.Value;
                    observer.OnNext(wartość);
                }
            }
        }
    }
}
