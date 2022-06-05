using ObserwatorZdarzenia;

Podmiot podmiot = new();
Dzielenie dzielenie = new(3);
Modulo modulo = new(3);

podmiot.WartośćZmieniona += dzielenie.Aktualizuj;
podmiot.WartośćZmieniona += modulo.Aktualizuj;

podmiot.ZmieńWartość(9);
Console.WriteLine();
podmiot.ZmieńWartość(10);
Console.WriteLine();

podmiot.WartośćZmieniona -= modulo.Aktualizuj;

podmiot.ZmieńWartość(2);