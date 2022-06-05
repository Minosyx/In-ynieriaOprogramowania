using MVC.Model;
using MVC.Controler;

ConsoleSettings model = ConsoleSettingsHelper.CurrentSettings;
MenuTemplate mt = new MenuTemplate();
Menu controler = new Menu(model, mt.Data);
controler.Run();