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

    public class Telewizor : IUrządzenieRTV
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

    public class Radio : IUrządzenieRTV
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
        private IUrządzenieRTV urządzenie;
        int bieżącyKanał, poprzedniKanał;
        bool czyWłączony = false;

        public Pilot(IUrządzenieRTV urządzenie)
        {
            this.urządzenie = urządzenie;
            bieżącyKanał = -1;
            poprzedniKanał = -1;
        }

        public void Włącz()
        {
            urządzenie.Włącz();
            czyWłączony = true;
            PrzełączKanał(1);
        }

        public void PrzełączKanał(int numerKanału)
        {
            if(!czyWłączony)
            {
                Włącz();
                bieżącyKanał = 1;
                czyWłączony = true;
            }
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
            urządzenie.Wyłącz();
        }
    }
}
