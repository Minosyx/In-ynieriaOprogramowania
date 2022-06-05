using System;

namespace Most12
{
    using InnaPrzestrzeńNazw;

    class Program
    {
        static void Main(string[] args)
        {
            //Pilot pilot = new Pilot(new Radio(), new Radio(), new Telewizor());
            Pilot pilot = new Pilot();

            pilot.PrzełączKanał(10);
            pilot.CofnijKanał();
            pilot.PrzełączKanał(5);
            pilot.CofnijKanał();
            pilot.CofnijKanał();
            pilot.Wyłącz();
        }
    }
}
