using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGame
{
    static class Logic
    {

        public static void NewSave()
        {
            Program.save=new Save();
        }
        public static void LoadSave(string fileName)
        {
            Program.save = new Save();
        }
        public static void EstajhoLoop()
        {
            List<object> list = Program.save.GetList("estajho");
            foreach (object item in list)
            {
                ((Estajho)item).eventApplier.LoopOn();
            }
        }
    }
}
