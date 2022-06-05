using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodaSzablonowa
{
    public abstract class Pizza
    {
        private void przygotuj()
        {
            przygotujCiasto();
            dodajSos();
            połóżDodatki();
            dodajPrzyprawy();
            upiecz();
        }

        public Pizza() => przygotuj();

        private void dodajSosPomidorowy() => Console.WriteLine("Dodaje sos pomidorowy!");

        protected virtual void dodajSos()
        {
            dodajSosPomidorowy();
        }

        private void upiecz() => Console.WriteLine($"Włączam pieczenie na czas {pobierzCzasPieczenia()}");

        protected virtual string pobierzCzasPieczenia() => "15 minut";

        protected abstract void przygotujCiasto();
        protected abstract void połóżDodatki();
        protected abstract void dodajPrzyprawy();
    }

    public class PizzaMargherita : Pizza
    {
        protected override void przygotujCiasto()
        {
            Console.WriteLine("Przygotowuje cienkie ciasto");
        }

        protected override void połóżDodatki()
        {
            Console.WriteLine("Dodaje ser mozzarella");
        }

        protected override void dodajPrzyprawy()
        {
            Console.WriteLine("Dodaje bazylii i odrobinę oliwy");
        }
    }

    public class PizzaSycylijska : Pizza
    {
        protected override void przygotujCiasto()
        {
            Console.WriteLine("Przygotowuje grube ciasto");
        }

        protected override void połóżDodatki()
        {
            Console.WriteLine("Dodaje oliwki i kapary");
        }

        protected override void dodajPrzyprawy()
        {
            Console.WriteLine("Dodaje specjalną mieszankę przypraw");
        }

        protected override string pobierzCzasPieczenia() => "20 minut";
    }
}
