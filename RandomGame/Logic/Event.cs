using System.Diagnostics;

namespace RandomGame
{
    class EventApplier(Estajho estajho)
    {
        List<string> Ids = [];
        public void LoopOn()
        {
            Debug.WriteLine("LoopOn " + estajho.id);
        }
        public void ReloadIds()
        {

        }
    }
    static class EventHelper
    {
        public static void LoadEvents()
        {

        }
    }
}
