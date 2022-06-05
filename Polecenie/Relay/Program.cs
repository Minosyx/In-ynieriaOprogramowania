using System;
using System.Windows.Input;
using Relay;

try
{
    Konto konto1 = new(1, 100);
    Konto konto2 = new(2, 150);

    konto1.WyświetlSaldo();
    konto2.WyświetlSaldo();

    DanePrzelewu daneA = new DanePrzelewu(konto1, konto2, 50);
    DanePrzelewu daneB = new DanePrzelewu(konto2, konto1, 100);
    ICommand poleceniePrzelewu = new RelayCommand(
        o =>
        {
            DanePrzelewu dane = (DanePrzelewu) o;
            if (dane.Wykonany) throw new Exception("Polecenie przelewu zostało już zrealizowane!");
            Konto.Przelew(dane.KontoPłatnika, dane.KontoOdbiorcy, dane.Kwota);
            dane.Wykonany = true;
        },
        o =>
        {
            DanePrzelewu dane = (DanePrzelewu) o;
            return !dane.Wykonany && dane.Kwota > 0;
        });


    if (poleceniePrzelewu.CanExecute(daneA)) poleceniePrzelewu.Execute(daneA);
    else throw new Exception("Polecenie nie może zostać zrealizowane");

    konto1.WyświetlSaldo();
    konto2.WyświetlSaldo();

    if (poleceniePrzelewu.CanExecute(daneB)) poleceniePrzelewu.Execute(daneB);
    else throw new Exception("Polecenie nie może zostać zrealizowane");

    konto1.WyświetlSaldo();
    konto2.WyświetlSaldo();

    poleceniePrzelewu.Execute(daneA);
}
catch (Exception e)
{
    Console.Error.WriteLine($"Błąd: {e.Message}");
}

public class DanePrzelewu
{
    public Konto KontoPłatnika, KontoOdbiorcy;
    public decimal Kwota;
    public bool Wykonany = false;

    public DanePrzelewu(Konto kontoPłatnika, Konto kontoOdbiorcy, decimal kwota)
    {
        KontoPłatnika = kontoPłatnika;
        KontoOdbiorcy = kontoOdbiorcy;
        Kwota = kwota;
    }
}


