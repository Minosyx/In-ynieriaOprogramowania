using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kompozyt
{
    //Component
    public interface IPracownik
    {
        void WyświetlInformacje(int głębokość);
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

        protected void zróbWcięcie(int głębokość)
        {
            for (int i = 0; i < głębokość; i++) Console.Write('\t');
        }

        public override string ToString() => $"{imię} {nazwisko} ({stanowisko})";

        public virtual void WyświetlInformacje(int głębokość)
        {
            zróbWcięcie(głębokość);
            Console.WriteLine(ToString());
            odwiedzony = true;
            zresetowany = false;
        }
    }

    //Composite
    public class Kierownik : Pracownik
    {
        private List<IPracownik> podwładni = new List<IPracownik>();

        public Kierownik(string imię, string nazwisko, string stanowisko) : base(imię, nazwisko, stanowisko) { }

        public void DodajPodwładnego(IPracownik podwładny)
        {
            podwładni.Add(podwładny);
        }

        public override void WyświetlInformacje(int głębokość = 0)
        {
            base.WyświetlInformacje(głębokość);
            zróbWcięcie(głębokość);
            Console.WriteLine("Podwładni:");
            foreach (Pracownik podwładny in podwładni)
            {
                if (!podwładny.odwiedzony)
                    podwładny.WyświetlInformacje(głębokość + 1);
                else Console.WriteLine("Znaleziono cykl");
            }
            if (głębokość == 0) Resetuj();
        }

        public override void Resetuj()
        {
            base.Resetuj();
            foreach (Pracownik pracownik in podwładni)
                if (!pracownik.zresetowany)
                    pracownik.Resetuj();
        }
    }
}
