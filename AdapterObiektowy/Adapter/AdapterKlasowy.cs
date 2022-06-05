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

        public Punkt P1 => p1;
        public Punkt P2 => p2;

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
    //class ProstokątForemny : WielokątForemny
    //{
    //    /*
    //    private static Punkt obliczPunkt1(Punkt środek, float długośćBoku)
    //    {
    //        return new Punkt(środek.X - długośćBoku / 2f, środek.Y - długośćBoku / 2f);
    //    }

    //    private static Punkt obliczPunkt2(Punkt środek, float długośćBoku)
    //    {
    //        return new Punkt(środek.X + długośćBoku / 2f, środek.Y + długośćBoku / 2f);
    //    }        

    //    public ProstokątForemny(Punkt środek, float długośćBoku)
    //        //: base(obliczPunkt1(środek, długośćBoku), obliczPunkt2(środek, długośćBoku))
    //        :base(środek, 4, długośćBoku)            
    //    {
    //        this.prostokąt = new Prostokąt(obliczPunkt1(środek, długośćBoku), obliczPunkt2(środek, długośćBoku));
    //    }
    //    */

    //    private static Punkt obliczŚrodek(Punkt p1, Punkt p2)
    //    {
    //        return new Punkt((p1.X + p2.X) / 2f, (p1.Y + p2.Y) / 2f);
    //    }

    //    private static float obliczDługośćBoku(Punkt p1, Punkt p2)
    //    {
    //        float szerokość = Math.Abs(p1.X - p2.X);
    //        float wysokość = Math.Abs(p1.Y - p2.Y);
    //        if (szerokość != wysokość) throw new Exception("Prostokąt nie jest foremny");
    //        return szerokość;
    //    }

    //    public ProstokątForemny(Prostokąt prostokąt)
    //        :base(obliczŚrodek(prostokąt.P1, prostokąt.P2), 4, obliczDługośćBoku(prostokąt.P1, prostokąt.P2))
    //    {
    //        this.prostokąt = prostokąt;
    //    }

    //    private Prostokąt prostokąt;

    //    public override void WyświetlNazwęFigury()
    //    {
    //        Console.Write("Kwadrat");
    //    }

    //    public override float ObliczPole()
    //    {
    //        return prostokąt.ObliczPole();
    //    }
    //}
    #endregion

    class ProstokątForemny : WielokątForemny
    {
        private static Punkt obliczŚrodek(Punkt p1, Punkt p2)
        {
            return new Punkt((p1.X + p2.X) / 2f, (p1.Y + p2.Y) / 2f);
        }

        private static float obliczDługośćBoku(Punkt p1, Punkt p2)
        {
            float szerokość = p2.Y - p1.Y;
            float wysokość = p2.X - p1.X;
            if (szerokość != wysokość) throw new ArgumentException("Nie jest foremny!");
            return szerokość;
        }

        private Prostokąt prostokąt;

        public ProstokątForemny(Prostokąt p) : base(obliczŚrodek(p.P1, p.P2), 4, obliczDługośćBoku(p.P1, p.P2))
        {
            prostokąt = p;
        }

        public override void WyświetlNazwęFigury()
        {
            prostokąt.WyświetlNazwęFigury();
            Console.Write(" foremny");
        }

        public override float ObliczPole() => DługośćBoków * DługośćBoków;
    }
}
