using Obserwator;

Podmiot podmiot = new();
Dzielenie dzielenie = new(3);
Modulo modulo = new(3);

podmiot.PrzyłączObserwator(dzielenie);
podmiot.PrzyłączObserwator(modulo);

podmiot.ZmieńWartość(9);
Console.WriteLine();
podmiot.ZmieńWartość(10);
Console.WriteLine();

podmiot.OdłączObserwator(modulo);

podmiot.ZmieńWartość(2);