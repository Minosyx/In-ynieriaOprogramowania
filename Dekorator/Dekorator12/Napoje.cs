using System;
using System.Collections.Generic;
using System.Text;

namespace Dekorator12
{
    //abstract component
    abstract class Napój
    {
        public abstract decimal Cena();

        public int ObjętośćWMililitrach()
        {
            return 330;
        }
    }

    //concrete components
    class Herbata : Napój
    {
        public override decimal Cena()
        {
            return 4.5M;
        }

        public override string ToString()
        {
            return "Herbata ";
        }
    }

    class Kawa : Napój
    {
        public override decimal Cena()
        {
            return 5.4M;
        }

        public override string ToString()
        {
            return "Kawa ";
        }
    }

    //abstract decorator
    abstract class NapójZDodatkiem : Napój
    {
        protected Napój napój;

        public NapójZDodatkiem(Napój napój)
        {
            this.napój = napój;
        }
    }

    //concrete decorat
    class NapójZCukrem : NapójZDodatkiem
    {
        private int liczbaŁyżeczek;

        public NapójZCukrem(Napój napój, int liczbaŁyżeczek = 2)
            :base(napój)
        {
            this.liczbaŁyżeczek = liczbaŁyżeczek;
        }

        public override decimal Cena()
        {
            return napój.Cena() + liczbaŁyżeczek * 0.1M;
        }

        public override string ToString()
        {
            return napój.ToString() + "z cukrem (liczba łyżeczek: " + liczbaŁyżeczek + ") ";
        }
    }

    class NapójZCynamonem : NapójZDodatkiem
    {
        public NapójZCynamonem(Napój napój)
            :base(napój)
        {
        }

        public override decimal Cena()
        {
            return napój.Cena() + 0.3M;
        }

        public override string ToString()
        {
            return napój.ToString() + "z cynamonem ";
        }
    }

    class NapójZCytryną : NapójZDodatkiem
    {
        public NapójZCytryną(Napój napój) : base(napój)
        {
        }

        public override decimal Cena()
        {
            return napój.Cena() + 0.4M;
        }

        public override string ToString()
        {
            return napój.ToString() + "z plastrem cytryny ";
        }
    }

    static class MenuNapojów
    {
        public static Napój KawaPiernikowa(int liczbaŁyżeczekCukru, int liczbaSzczyptCynamonu)
        {
            Napój kawa = new Kawa();
            kawa = new NapójZCukrem(kawa, liczbaŁyżeczekCukru);
            for (int i = 0; i < liczbaSzczyptCynamonu; ++i)
                kawa = new NapójZCynamonem(kawa);
            return kawa;
        }

        public static Napój HerbataZCytryną(int liczbaPlastrów = 1)
        {
            Napój herbata = new Herbata();
            for (int i = 0; i < liczbaPlastrów; ++i)
                herbata = new NapójZCytryną(herbata);
            return herbata;
        }
    }
}
