using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGame
{
    class EventApplier
    {
        List<string> Ids;
        Estajho estajho;
        public void LoopOn()
        {
            Debug.WriteLine("LoopOn "+estajho.id);   
        }
        public void ReloadIds()
        {

        }
        public EventApplier(Estajho estajho)
        {
            Ids = new List<string>();
            this.estajho = estajho;
        }
    }
    static class EventHelper
    {
        public static void LoadEvents()
        {

        }
    }
}
