using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            timer = new Timer(1000);
            timer.Elapsed += Step;
            timer.Start();
        }
        private static void Step(object? sender, System.Timers.ElapsedEventArgs e)
        {
            save.time.PassHour();
        }
    }
}
