using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGame
{
    static class Tools
    {
        public static string RandomSelect(params string[] strings)
        {
            return strings[new Random(Program.save.seed).Next(strings.Length)];
        }
        public static Object RandomSelect(params Object[] objects)
        {
            return objects[new Random(Program.save.seed).Next(objects.Length)];
        }
    }
}
