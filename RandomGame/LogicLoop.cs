using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGame
{
    class LogicLoop
    {
        public void EstajhoLoop()
        {
            List<object> list = Program.save.GetList("estajho");
            foreach (object item in list)
            {
                ((Estajho)item).eventApplier.LoopOn();
            }
        }
    }
}
