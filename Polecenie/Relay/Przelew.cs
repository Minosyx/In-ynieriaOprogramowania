using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relay
{
    public class Konto
    {
        private int numerKonta;
        private decimal saldo;

        public Konto(int numerKonta, decimal saldo)
        {
            this.numerKonta = numerKonta;
            this.saldo = saldo;
        }

        public void Wpłata(decimal kwota)
        {
            if (kwota < 0) throw new Exception("Kwota nie może być ujemna!");
            saldo += kwota;
            Console.WriteLine($"Nastąpiła wpłata na konto {numerKonta} kwoty {kwota}. Saldo po operacji {saldo}.");
        }

        public bool Wypłata(decimal kwota)
        {
            if (kwota < 0) throw new Exception("Kwota nie może być ujemna!");
            if (saldo >= kwota)
            {
                saldo -= kwota;
                Console.WriteLine($"Nastąpiła wypłata z konta {numerKonta} kwoty {kwota}. Saldo po operacji {saldo}.");
                return true;
            }
            else return false;
        }

        public void WyświetlSaldo()
        {
            Console.WriteLine($"Saldo konta {numerKonta}: {saldo}.");
        }

        public static bool Przelew(Konto kontoPłatnika, Konto kontoOdbiorcy, decimal kwota)
        {
            if (kontoPłatnika.numerKonta == kontoOdbiorcy.numerKonta)
                throw new Exception("Nie można przelać pieniędzy na konto wychodzące!");

            Console.WriteLine($"Przygotowanie do przelewu z konta {kontoPłatnika.numerKonta} na konto {kontoOdbiorcy.numerKonta} kwoty {kwota}.");

            if (kontoPłatnika.Wypłata(kwota))
            {
                kontoOdbiorcy.Wpłata(kwota);
                Console.WriteLine($"Wykonany został przelew z konta {kontoPłatnika.numerKonta} na konto {kontoOdbiorcy.numerKonta} kwoty {kwota}.");
                return true;
            }

            return false;
        }
    }

    public interface IPolecenie
    {
        bool CzyMożnaWykonać();
        void Wykonaj();
    }

    public class PoleceniePrzelewu : IPolecenie
    {
        private Konto kontoPłatnika, kontoOdbiorcy;
        private decimal kwota;
        private bool wykonany = false;

        public PoleceniePrzelewu(Konto kontoPłatnika, Konto kontoOdbiorcy, decimal kwota)
        {
            this.kontoPłatnika = kontoPłatnika;
            this.kontoOdbiorcy = kontoOdbiorcy;
            this.kwota = kwota;
        }

        public bool CzyMożnaWykonać()
        {
            return !wykonany && kwota > 0;
        }

        public void Wykonaj()
        {
            if (wykonany) throw new Exception("Polecenie przelewu zostało już zrealizowane!");
            Konto.Przelew(kontoPłatnika, kontoOdbiorcy, kwota);
            wykonany = true;
        }
    }
}
