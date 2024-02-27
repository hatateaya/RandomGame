using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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
            playerid = New("estajho", new Estajho(EstajhoNewMode.RandomNormal));
            actorid = New("estajho", new Estajho(EstajhoNewMode.RandomYINANS));
        }
        public string New(string title, object thing)
        {
            if (!pairs.ContainsKey(title + ".list"))
            {
                ((List<string>)pairs[".list"]).Add(title);
                pairs.Add(title + ".list", new List<string>());
                pairs.Add(title + ".count", 0);
            }
            string id = title + ((int)pairs[title + ".count"]).ToString();
            ((List<string>)pairs[title + ".list"]).Add(id);
            pairs.Add(id, thing);
            pairs[title + ".count"] = (int)pairs[title + ".count"] + 1;
            return id;
        }
        public void Set(string id, object thing)
        {
            if (!pairs.ContainsKey(id))
            {
                New(id.Split('.')[0], thing);
            }
            else
            {
                pairs.Add(id, thing);
            }
        }
        public object Get(string id)
        {
                return pairs[id];
        }
        public List<object> GetList(string title)
        {
            List<object> list = new List<object>();
            foreach (string thingId in (List<string>)pairs[title + ".list"])
            {
                list.Add(pairs[thingId]);
            }
            return list;
        }
    }
}
