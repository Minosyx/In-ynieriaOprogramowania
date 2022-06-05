using System;
using System.Collections.Generic;
using System.Text;

namespace InnaPrzestrzeńNazw
{
    public interface IUrządzenieRTV
    {
        void Włącz();
        void Wyłącz();
        void UstawKanał(int numerKanału);
    }

    class Telewizor : IUrządzenieRTV
    {
        public void Włącz()
        {
            Console.WriteLine("Telewizor został włączony");
        }

        public void Wyłącz()
        {
            Console.WriteLine("Telewizor został wyłączony");
        }

        public void UstawKanał(int numerKanału)
        {
            Console.WriteLine("Telewizor ustawiony na kanał " + numerKanału);
        }
    }

    class Radio : IUrządzenieRTV
    {
        public void Włącz()
        {
            Console.WriteLine("Radio zostało włączone");
        }

        public void Wyłącz()
        {
            Console.WriteLine("Radio zostało wyłączone");
        }

        public void UstawKanał(int numerKanału)
        {
            Console.WriteLine("Radio przełączone na stację " + numerKanału);
        }
    }

    public class Pilot
    {
        private IUrządzenieRTV[] urządzenia;
        int bieżącyKanał, poprzedniKanał;
        bool czyWłączony = false;

        protected IUrządzenieRTV[] Urządzenia // pełnomocnik
        {
            get
            {
                if (urządzenia == null)
                    urządzenia = new IUrządzenieRTV[2] {new Telewizor(), new Radio()};
                return urządzenia;
            }
        }

        public Pilot(params IUrządzenieRTV[] urządzenia) : this() //most dla wielu
        {
            this.urządzenia = urządzenia;
        }

        public Pilot()
        {
            bieżącyKanał = -1;
            poprzedniKanał = -1;
        }

        public void Włącz()
        {
            foreach (IUrządzenieRTV urządzenie in Urządzenia)
            {
                urządzenie.Włącz();
                czyWłączony = true;
            }
            PrzełączKanał(1);
        }

        public void PrzełączKanał(int numerKanału)
        {
            if(!czyWłączony)
            {
                Włącz();
                //bieżącyKanał = 1;
                //czyWłączony = true;
            }
            foreach (IUrządzenieRTV urządzenie in Urządzenia)
                urządzenie.UstawKanał(numerKanału);
            poprzedniKanał = bieżącyKanał;
            bieżącyKanał = numerKanału;
        }

        public void CofnijKanał()
        {
            PrzełączKanał(poprzedniKanał);
        }

        public void Wyłącz()
        {
            foreach (IUrządzenieRTV urządzenie in Urządzenia)
                urządzenie.Wyłącz();
        }
    }
}
