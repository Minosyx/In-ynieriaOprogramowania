using Kompozyt;

Kierownik rektor = new Kierownik("Andrzej", "Karbowski", "rektor");
rektor.DodajPodwładnego(new Pracownik("Anna", "Wardało", "prorektor ds. ekonomicznych"));
rektor.DodajPodwładnego(new Pracownik("Muhamed", "Murzynowski", "prorektor ds. równouprawnienia"));
Kierownik dziekanFizyki = new Kierownik("Jan", "Fizyczny", "dziekan WFiz");
rektor.DodajPodwładnego(dziekanFizyki);
Kierownik kierownikZakładu = new Kierownik("Michał", "Zieliński", "kierownik ZMK");
dziekanFizyki.DodajPodwładnego(kierownikZakładu);
kierownikZakładu.DodajPodwładnego(new Pracownik("Jacek", "Matulewski", "adiunkt"));
kierownikZakładu.DodajPodwładnego(new Pracownik("Waldemar", "Musiał", "profesor"));
kierownikZakładu.DodajPodwładnego(rektor);
kierownikZakładu.DodajPodwładnego(new Pracownik("Andrzej", "Nierektorski", "asystent"));

rektor.WyświetlInformacje();
rektor.WyświetlInformacje();