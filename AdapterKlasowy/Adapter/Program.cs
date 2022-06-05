namespace Adapter
{
    using UMK.WzorceStrukturalne;

    class Program
    {
        static void Main(string[] args)
        {
            Punkt środekTrójkąta = new Punkt(10.0f, 10.0f);
            TrójkątForemny trójkątForemny = new TrójkątForemny(środekTrójkąta, 5.0f);
            Klient.WyświetlInformacjeOFigurze(trójkątForemny);

            Punkt środekKwadratu = new Punkt(10.0f, 20.0f);
            ProstokątForemny kwadrat = new ProstokątForemny(środekKwadratu, 5.0f);
            Klient.WyświetlInformacjeOFigurze(kwadrat);
        }
    }
}
