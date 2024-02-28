using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGame
{
    class Time
    {
        public int hour = 0;
        public int day = 0;
        public void PassHour()
        {
            
        }
        public void PassDay()
        {
            for (int i = 0; i<24-hour; i++)
            {
                PassHour();

            }
        }
        public override string ToString()
        {
            return $"{day}-{hour}";
        }
    }
}
