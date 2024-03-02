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
            new Relation(RelationType.Friend, playerId, actorId);
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
            string Id = title + "." + ((int)pairs[title + ".count"]).ToString();
            ((List<string>)pairs[title + ".list"]).Add(Id);
            pairs.Add(Id, thing);
            pairs[title + ".count"] = (int)pairs[title + ".count"] + 1;
            Debug.WriteLine($"{Id} registed.");
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
