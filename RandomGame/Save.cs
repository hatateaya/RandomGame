using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGame
{
    class Save
    {
        public Dictionary<string, object> pairs = new Dictionary<string, object>();
        string playerid;
        string actorid;

        public Save()
        {
            pairs.Add(".list", new List<string>());
            playerid= SaveTool.New("estajho", new Estajho(EstajhoNewMode.RandomNormal));
            actorid = SaveTool.New("estajho", new Estajho(EstajhoNewMode.RandomYINANS));
        }
    }

    static class SaveTool
    {
       public static string New(string title,object thing)
        {
            if (!Program.save.pairs.ContainsKey(title + ".list"))
            {
                ((List<string>)Program.save.pairs[".list"]).Add(title);
                Program.save.pairs.Add(title + ".list", new List<string>());
                Program.save.pairs.Add(title + ".count", 0);
            }
            string id = title + ((int)Program.save.pairs[title + ".count"]).ToString();
            ((List<string>)Program.save.pairs[title + ".list"]).Add(id);
            Program.save.pairs.Add(id, thing);
            Program.save.pairs[title + ".count"]=(int)Program.save.pairs[title + ".count"]+1;
            return id;
        }
        public static List<object> GetList(string title)
        {
            List<object> list = new List<object>;
            foreach (string thingId in (List<string>)Program.save.pairs[title + ".list"])
            {
                list.Add(Program.save.pairs[thingId]);
            }
            return list;
        }
    }


}
