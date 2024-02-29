using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGame
{
    static class Tools
    {
        public static string RandomSelect(string[] strings)
        {
            // No seed
            return strings[new Random().Next(strings.Length)];
        }
    }
}
