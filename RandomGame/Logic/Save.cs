using System.Diagnostics;

namespace RandomGame
{
    class Save
    {
        public Dictionary<string, object> pairs = [];
        public Time time;
        public int seed;
        public Random random;
        public Save()
        {
            Logic.save = this;
            seed = new Random().Next(int.MaxValue);
            random = new Random(seed);
            pairs.Add(".list", new List<string>());
            time = new Time();
            Set("global.time", time);
            Set("global.seed", seed);
            Set("global.player", new Estajho(EstajhoNewMode.Player).id);
        }
        private void CheckList(string title)
        {
            if (!pairs.ContainsKey(title + ".count"))
            {
                pairs.Add(title + ".count", 0);
            }
            if (!pairs.ContainsKey(title + ".list"))
            {
                ((List<string>)pairs[".list"]).Add(title);
                pairs.Add(title + ".list", new List<string>());
            }
        }
        public string New(string title, object item)
        {
            ArgumentNullException.ThrowIfNull(item);
            CheckList(title);
            string id = title + "." + ((int)pairs[title + ".count"]).ToString();
            ((List<string>)pairs[title + ".list"]).Add(id);
            pairs.Add(id, item);
            pairs[title + ".count"] = (int)pairs[title + ".count"] + 1;
            Debug.WriteLine($"{id} registed.");
            return id;
        }
        public void Set(string id, object item)
        {
            ArgumentNullException.ThrowIfNull(item);
            if (!pairs.ContainsKey(id))
            {
                string title = id.Split('.')[id.Split('.').Count()-1];
                CheckList(title);
                ((List<string>)pairs[title + ".list"]).Add(id);
                pairs.Add(id, item);
                Debug.WriteLine($"{id} registed.");
            }
            else
            {
                pairs.Add(id, item);
                Debug.WriteLine($"{id} setted.");
            }
        }
        public T Get<T>(string Id)
        {
            return (T)pairs[Id];
        }
        public List<T> GetList<T>(string title)
        {
            List<T> list = [];
            foreach (string thingId in (List<string>)pairs[title + ".list"])
            {
                list.Add((T)pairs[thingId]);
            }
            return list;
        }
    }
}
