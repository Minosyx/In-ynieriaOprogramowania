using Pyłek;

string dokuemnt = "JABADABADUUU!";
char[] literyWDokumencie = dokuemnt.ToCharArray();

ConsoleColor[] kolory = new ConsoleColor[literyWDokumencie.Length];

for (int i = 0; i < literyWDokumencie.Length; ++i) kolory[i] = ConsoleColor.White;
kolory[3] = ConsoleColor.Red;
kolory[4] = ConsoleColor.Yellow;
kolory[6] = ConsoleColor.Green;

FabrykaZnaków fabrykaZnaków = new FabrykaZnaków();
for (int i = 0; i < literyWDokumencie.Length; ++i)
{
    Znak znak = fabrykaZnaków.PobierzZnak(literyWDokumencie[i]);
    znak.Wyświetl(kolory[i]);
}