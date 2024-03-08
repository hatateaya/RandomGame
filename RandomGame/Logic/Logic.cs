using Timer = System.Timers.Timer;
using RandomGame.Events;

namespace RandomGame
{
    static class Logic
    {
        public static Save? save;
        public static Timer? timer;
        public static List<Event>? events;
        public static void NewSave()
        {
            _ = new Save();
            Initialize();
        }
        public static void LoadSave(string fileName)
        {
            _ = new Save();
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
            save.time.Step();
        }
        public static void RefreshEventAppliers()
        {
            foreach (var estajho in save.GetList<Estajho>("estajho"))
            {
                estajho.eventApplier.RefreshEvents();
            }
        }
        private static void LoadEvents()
        {
            events = [];
        }
    }
}
