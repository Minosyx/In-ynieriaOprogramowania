namespace Adapter
{
    using UMK.WzorceStrukturalne;

    class Program
    {
        static void Main(string[] args)
        {
            Punkt środekTrójkąta = new Punkt(10.0f, 10.0f);
            IWielokątForemny trójkątForemny = new TrójkątForemny(środekTrójkąta, 5.0f);
            //Klient.WyświetlInformacjeOFigurze(trójkątForemny);

            Punkt środekKwadratu = new Punkt(10.0f, 20.0f);
            Prostokąt prostokąt = new Prostokąt(środekTrójkąta, new Punkt(50, 50));
            IWielokątForemny kwadrat = new ProstokątForemny(prostokąt);
            //Klient.WyświetlInformacjeOFigurze(kwadrat);

            IWielokątForemny[] wielokątyForemne = new IWielokątForemny[2] { trójkątForemny, kwadrat };
            foreach (IWielokątForemny wielokątForemny in wielokątyForemne)
                Klient.WyświetlInformacjeOFigurze(wielokątForemny);
        }
    }
}
