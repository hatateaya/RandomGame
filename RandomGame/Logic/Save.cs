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
        string playerId;
        string actorId;
        public Time time;

        public Save()
        {
            pairs.Add(".list", new List<string>());
            playerId = New("estajho", new Estajho(EstajhoNewMode.RandomNormal));
            actorId = New("estajho", new Estajho(EstajhoNewMode.RandomYINANS));
            time = new Time();
        }
        public string New(string title, object thing)
        {
            if (!pairs.ContainsKey(title + ".list"))
            {
                ((List<string>)pairs[".list"]).Add(title);
                pairs.Add(title + ".list", new List<string>());
                pairs.Add(title + ".count", 0);
            }
            string Id = title + ((int)pairs[title + ".count"]).ToString();
            ((List<string>)pairs[title + ".list"]).Add(Id);
            pairs.Add(Id, thing);
            pairs[title + ".count"] = (int)pairs[title + ".count"] + 1;
            return Id;
        }
        public void Set(string Id, object thing)
        {
            if (!pairs.ContainsKey(Id))
            {
                New(Id.Split('.')[0], thing);
            }
            else
            {
                pairs.Add(Id, thing);
            }
        }
        public object Get(string Id)
        {
                return pairs[Id];
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
