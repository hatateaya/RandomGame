﻿using System;
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
            return strings[new Random(Program.save.seed).Next(strings.Length)];
        }
    }
}
