using System;

namespace UMK.WzorceStrukturalne
{
    #region Klient i klasy używane przez niego
    class Punkt
    {
        public float X, Y;

        public Punkt(float x, float y)
        {
            X = x;
            Y = y;
        }
    }

    //target, interfejs używany przez clienta
    interface IWielokątForemny
    {
        Punkt Środek { get; }
        int LiczbaBoków { get; }
        float DługośćBoków { get; }

        void WyświetlParametry();
        void WyświetlNazwęFigury();
        float ObliczObwód();
        float ObliczPole();
    }

    abstract class WielokątForemny : IWielokątForemny
    {
        public Punkt Środek { get; private set; }
        public int LiczbaBoków { get; private set; }
        public float DługośćBoków { get; private set; }

        protected WielokątForemny(Punkt środek, int liczbaBoków, float długośćBoków)
        {
            this.Środek = środek;
            this.LiczbaBoków = liczbaBoków;
            this.DługośćBoków = długośćBoków;
        }

        public virtual void WyświetlParametry()
        {
            Console.WriteLine("srodek: (" + Środek.X + "," + Środek.Y + "), liczba bokow: " + LiczbaBoków + ", dlugosc bokow: " + DługośćBoków);
        }

        public abstract void WyświetlNazwęFigury();

        public float ObliczObwód() //bez modyfikatora virtual - implementacja "ostateczna"
        {
            return LiczbaBoków * DługośćBoków;
        }

        public abstract float ObliczPole();
    }

    //przykład klasy zgodnej z targetem
    class TrójkątForemny : WielokątForemny
    {

        public TrójkątForemny(Punkt środek, float długośćBoków)
            : base(środek, 3, długośćBoków)
        { }

        public override void WyświetlNazwęFigury()
        {
            Console.Write("Trojkat rownoboczny");
        }

        public override float ObliczPole()
        {
            return DługośćBoków * DługośćBoków * (float)(Math.Sqrt(3.0) / 4.0);
        }
    };

    //client
    class Klient
    {
        public static void WyświetlInformacjeOFigurze(IWielokątForemny wielokątForemny)
        {
            wielokątForemny.WyświetlNazwęFigury();
            Console.WriteLine(":");
            wielokątForemny.WyświetlParametry();
            Console.WriteLine("Obwod: " + wielokątForemny.ObliczObwód());
            Console.WriteLine("Pole: " + wielokątForemny.ObliczPole());
            Console.WriteLine();
        }
    }
    #endregion

    #region Kod niepasujący, którego jednak chcemy użyć
    //adaptee, klasa adaptowana
    class Prostokąt
    {
        protected Punkt p1; //lewy-górny róg
        protected Punkt p2; //prawy-dolny róg	

        protected float szerokość() { return p2.X - p1.X; }
        protected float wysokość() { return p2.Y - p1.Y; }

        public Prostokąt(Punkt p1, Punkt p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }

        public void WyświetlNazwęFigury() //inna nazwa funkcji
        {
            Console.Write("Prostokat");
        }

        public void WyświetlParametry() //wyświetla inny rodzaj parametrów
        {
            Console.WriteLine("lewa krawędź: " + p1.X + ", górna krawędź: " + p1.Y + ", szerokość: " + szerokość() + ", wysokość: " + wysokość());
        }

        public float ObliczPole()
        {
            return szerokość() * wysokość();
        }
    }
    #endregion

    #region Nakładka dostosowująca kod niepasującego do targetu
    //class ProstokątForemny : Prostokąt, IWielokątForemny
    //{
    //    private static Punkt obliczPunkt1(Punkt środek, float długośćBoku)
    //    {
    //        return new Punkt(środek.X - długośćBoku / 2f, środek.Y - długośćBoku / 2f);
    //    }

    //    private static Punkt obliczPunkt2(Punkt środek, float długośćBoku)
    //    {
    //        return new Punkt(środek.X + długośćBoku / 2f, środek.Y + długośćBoku / 2f);
    //    }        

    //    public ProstokątForemny(Punkt środek, float długośćBoku)
    //        : base(obliczPunkt1(środek, długośćBoku), obliczPunkt2(środek, długośćBoku))
    //    {
    //        this.Środek = środek;
    //        this.DługośćBoków = długośćBoku;
    //    }

    //    public Punkt Środek { get; private set; }

    //    public int LiczbaBoków => 4;

    //    public float DługośćBoków { get; private set; }

    //    public float ObliczObwód()
    //    {
    //        return 2 * szerokość() + 2 * wysokość();
    //    }

    //    public new void WyświetlNazwęFigury()
    //    {
    //        Console.Write("Kwadrat");
    //    }
    //}
    #endregion

    class ProstokątForemny : Prostokąt, IWielokątForemny
    {
        private static Punkt ObliczP1(Punkt środek, float bok)
        {
            return new Punkt(środek.X - bok / 2, środek.Y - bok / 2);
        }
        private static Punkt ObliczP2(Punkt środek, float bok)
        {
            return new Punkt(środek.X + bok / 2, środek.Y + bok / 2);
        }

        public ProstokątForemny(Punkt środek, float bok):
            base(ObliczP1(środek, bok), ObliczP2(środek, bok))
        {
        }

        public Punkt Środek => new Punkt((p1.X + p2.X) / 2.0f, (p1.Y + p2.Y) / 2.0f);
        public int LiczbaBoków => 4;
        public float DługośćBoków => szerokość();
        public float ObliczObwód() => DługośćBoków * LiczbaBoków;

        public new void WyświetlNazwęFigury()
        {
            base.WyświetlNazwęFigury();
            Console.Write(" foremny");
        }

        public new void WyświetlParametry() =>
            Console.WriteLine(
                $"Środek: ({Środek.X}, {Środek.Y}), Liczba boków: {LiczbaBoków}, Długość boku: {DługośćBoków}");
    }
}
