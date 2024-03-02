using System.Diagnostics;
using Timer = System.Timers.Timer;

namespace RandomGame
{
    static class Logic
    {
        public static Save? save;
        public static Timer? timer;
        public static void NewSave()
        {
            new Save();
            Initialize();
        }
        public static void LoadSave(string fileName)
        {
            new Save();
            Initialize();
        }
        public static void Initialize()
        {
            LoadEvents();
            timer = new Timer(1000);
            timer.Elapsed += Step;
            timer.Start();
        }
        private static void Step(object? sender, System.Timers.ElapsedEventArgs e)
        {
            save.time.PassHour();
        }
        private static void LoadEvents()
        {
            DirectoryInfo directoryInfo = new("Resources/Events/");
            foreach (var file in directoryInfo.GetFiles())
            {
                Event.FromJsonFile(file.FullName);
            }
            RefreshEventAppliers();
        }
        public static void RefreshEventAppliers()
        {
            foreach (var estajho in save.GetList<Estajho>("estajho"))
            {
                estajho.eventApplier.RefreshEvents();
            }
        }
    }
}
