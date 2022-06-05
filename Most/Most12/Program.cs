using System;

namespace Most12
{
    using InnaPrzestrzeńNazw;

    class Program
    {
        static void Main(string[] args)
        {
            IUrządzenieRTV tv = new Telewizor();
            Pilot pilot = new Pilot(tv);

            pilot.PrzełączKanał(10);
            pilot.CofnijKanał();
            pilot.PrzełączKanał(5);
            pilot.CofnijKanał();
            pilot.CofnijKanał();
            pilot.Wyłącz();
        }
    }
}
