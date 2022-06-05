using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odwiedzający
{
    public interface IOdwiedzający
    {
        void Odwiedź(IPracownik pracownik);
        void Resetuj();
    }

    public class OdwiedzającyWyświetlającyInformacje : IOdwiedzający
    {
        public int głębokość = 0;
        public void Odwiedź(IPracownik pracownik)
        {
            if (pracownik is Pracownik pracownik1) pracownik1?.zróbWcięcie(głębokość);
            else (pracownik as Kierownik)?.zróbWcięcie(głębokość);
            Console.WriteLine(pracownik.ToString());
            if (pracownik is Kierownik)
            {
                for (int i = 0; i < głębokość; i++)
                {
                    Console.Write('\t');
                }
                Console.WriteLine("Podwładni:");
                głębokość++;
            }
        }

        public void Resetuj()
        {
            głębokość = 0;
        }
    }

    public class OdwiedzającyZliczający : IOdwiedzający
    {
        private int licznikWszystkichPracowników = 0;
        private int licznikKierowników = 0;

        public void Odwiedź(IPracownik pracownik)
        {
            licznikWszystkichPracowników++;
            if (pracownik is Kierownik) licznikKierowników++;
        }

        public void Resetuj()
        {
            licznikKierowników = 0;
            licznikWszystkichPracowników = 0;
        }

        public void WyświetlLiczbęPracowników()
        {
            Console.WriteLine($"Liczba wszystkich pracowników {licznikWszystkichPracowników}, w tym kierowników {licznikKierowników}");
        }
    }

    public class OdwiedzającyLista : IOdwiedzający
    {
        public List<IPracownik> ListaPracowników { get; private set; } = new List<IPracownik>();
        public void Odwiedź(IPracownik pracownik)
        {
            ListaPracowników.Add(pracownik);
        }

        public void Resetuj()
        {
            ListaPracowników.Clear();
        }
    }

    //Component
    public interface IPracownik
    {
        void PrzyjmijWizytę(IOdwiedzający odwiedzający, int głębokość);
        void Resetuj();
    }

    //Liść
    public class Pracownik : IPracownik
    {
        private string imię, nazwisko, stanowisko;
        protected internal bool odwiedzony, zresetowany;

        public virtual void Resetuj()
        {
            odwiedzony = false;
            zresetowany = true;
        }

        public Pracownik(string imię, string nazwisko, string stanowisko)
        {
            this.imię = imię;
            this.nazwisko = nazwisko;
            this.stanowisko = stanowisko;
            Resetuj();
        }

        public void zróbWcięcie(int głębokość)
        {
            for (int i = 0; i < głębokość; i++) Console.Write('\t');
        }

        public override string ToString() => $"{imię} {nazwisko} ({stanowisko})";

        public virtual void PrzyjmijWizytę(IOdwiedzający odwiedzający, int głębokość)
        {
            odwiedzający.Odwiedź(this);
            odwiedzony = true;
            zresetowany = false;
        }
    }

    //Composite
    public class Kierownik : Pracownik, IEnumerable<IPracownik>
    {
        private List<IPracownik> podwładni = new List<IPracownik>();

        public Kierownik(string imię, string nazwisko, string stanowisko) : base(imię, nazwisko, stanowisko) { }

        public void DodajPodwładnego(IPracownik podwładny)
        {
            podwładni.Add(podwładny);
        }

        public override void PrzyjmijWizytę(IOdwiedzający odwiedzający, int głębokość = 0)
        {
            if (głębokość == 0) odwiedzający.Resetuj();
            base.PrzyjmijWizytę(odwiedzający, głębokość);
            foreach (Pracownik podwładny in podwładni)
            {
                if (!podwładny.odwiedzony)
                    podwładny.PrzyjmijWizytę(odwiedzający, głębokość + 1);
                //else Console.WriteLine("Znaleziono cykl");
            }

            if (głębokość == 0)
            {
                Resetuj();
            }
        }

        public override void Resetuj()
        {
            base.Resetuj();
            foreach (Pracownik pracownik in podwładni)
                if (!pracownik.zresetowany)
                    pracownik.Resetuj();
        }

        List<IPracownik> ToList()
        {
            OdwiedzającyLista ol = new();
            this.PrzyjmijWizytę(ol);
            return ol.ListaPracowników;
        }

        public IEnumerator<IPracownik> GetEnumerator()
        {
            return ToList().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        //Iterator
        public class IteratorPodwładnych : IEnumerator<IPracownik>
        {
            private int indeksBieżącegoPodwładnego = 0;
            private List<IPracownik> listaPodwładnych;
            public IteratorPodwładnych(Kierownik kierownik)
            {
                listaPodwładnych = kierownik.ToList();
            }

            public IPracownik Current => listaPodwładnych[indeksBieżącegoPodwładnego];

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                
            }

            public bool MoveNext()
            {
                indeksBieżącegoPodwładnego++;
                return indeksBieżącegoPodwładnego < listaPodwładnych.Count;
            }

            public void Reset()
            {
                indeksBieżącegoPodwładnego = 0;
            }
        }
    }
}
