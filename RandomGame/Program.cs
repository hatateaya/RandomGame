
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace RandomGame
{
    class Program
    {
        public static Save save;

        static void Main(string[] args)
        {
            UnitTests.Perform();
            Logic.Initialize();
            Gui.Begin();
            
            Application.Shutdown();
        }
    }
}
