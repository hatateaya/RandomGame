using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGame
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitTests.Perform();
            Initialize();
            Body();
        }
        static void Initialize()
        {
            save = new Save();
        }
        static void Body()
        {

        }
        public static Save save;
    }

    static class Command
    {
        public static void Trigger(string command)
        {
            command= command.ToLower();
            switch (command)
            {
                case "":
                    break;
                default:
                    break;
            }
        }
    }
}
