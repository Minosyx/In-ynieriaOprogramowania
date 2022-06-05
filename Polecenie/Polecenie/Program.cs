using Polecenie;

try
{
    Konto konto1 = new(1, 100);
    Konto konto2 = new(2, 150);

    konto1.WyświetlSaldo();
    konto2.WyświetlSaldo();

    IPolecenie polecenieA = new PoleceniePrzelewu(konto1, konto2, 50);
    IPolecenie polecenieB = new PoleceniePrzelewu(konto2, konto1, 100);

    if (polecenieA.CzyMożnaWykonać()) polecenieA.Wykonaj();
    else throw new Exception("Polecenie nie może być zrealizowane!");

    konto1.WyświetlSaldo();
    konto2.WyświetlSaldo();

    if (polecenieB.CzyMożnaWykonać()) polecenieB.Wykonaj();
    else throw new Exception("Polecenie nie może być zrealizowane!");

    konto1.WyświetlSaldo();
    konto2.WyświetlSaldo();
}
catch (Exception e)
{
    Console.Error.WriteLine($"Błąd: {e.Message}");
}