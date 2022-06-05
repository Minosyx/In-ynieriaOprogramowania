using Observable;

Podmiot podmiot = new();
Dzielenie dzielenie = new(3);
Modulo modulo = new(3);

IDisposable unsubscriberDzielenie = podmiot.Subscribe(dzielenie);
IDisposable unsubscriberModulo = podmiot.Subscribe(modulo);

podmiot.ZmieńWartość(9);
Console.WriteLine();
podmiot.ZmieńWartość(10);
Console.WriteLine();

unsubscriberModulo.Dispose();

podmiot.ZmieńWartość(2);