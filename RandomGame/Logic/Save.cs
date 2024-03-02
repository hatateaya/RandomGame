using System.Diagnostics;

namespace RandomGame
{
    class Save
    {
        public Dictionary<string, object> pairs = [];
        public string playerId;
        public string actorId;
        public Time time;
        public int seed;
        public Random random;
        public Save()
        {
            Logic.save = this;
            seed = new Random().Next(int.MaxValue);
            random = new Random(seed);
            pairs.Add(".list", new List<string>());
            playerId = new Estajho(EstajhoNewMode.Player).id;
            actorId = new Estajho(EstajhoNewMode.Actor).id;
            _ = new Relation(RelationType.Friend, playerId, actorId);
            time = new Time();
        }
        public string New<T>(string title,string subtitle,T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            if (!pairs.ContainsKey(title + ".list"))
            {
                ((List<string>)pairs[".list"]).Add(title);
                pairs.Add(title + ".list", new List<string>());
                if (!pairs.ContainsKey(title + ".count"))
                {
                    pairs.Add(title + ".count", 0);
                }
            }
            string Id = title + "." + subtitle;
            ((List<string>)pairs[title + ".list"]).Add(Id);
            pairs.Add(Id, item);
            pairs[title + ".count"] = (int)pairs[title + ".count"] + 1;
            Debug.WriteLine($"{Id} registed.");
            return Id;
        }
        public string New<T>(string title, T item)
        {
            if (!pairs.ContainsKey(title + ".count"))
            {
                pairs.Add(title + ".count", 0);
            }
            string subtitle = ((int)pairs[title + ".count"]).ToString();
            return New(title, subtitle, item); ;
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
