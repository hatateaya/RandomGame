namespace RandomGame
{
    class Estajho
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<string> statos { get; set; }
        public List<string> relations { get; set; }
        
        public EventApplier eventApplier;
        public Estajho(EstajhoNewMode estajhoNewMode)
        {
            id = Logic.save.New("estajho", this);
            name = GenerateName();
            statos = [];
            relations = [];
            eventApplier = new EventApplier(this);
            switch (estajhoNewMode)
            {
                case EstajhoNewMode.Player:
                    _ = new Relation(RelationType.Friend, id, new Estajho(EstajhoNewMode.Actor).id);
                    _ = new Relation(RelationType.Parent, id, new Estajho(EstajhoNewMode.Parent).id);
                    _ = new Relation(RelationType.Parent, id, new Estajho(EstajhoNewMode.Parent).id);
                    break;
            }
        }
        string GenerateName()
        {
            string[] femaleNames = [
            "Rin","Sakura","Yua","Hina","Miu","Yui","Miyu","Misaki","Aoi" ];
            return Tools.RandomSelect(femaleNames);
        }
    }
    enum EstajhoNewMode
    {
        Player,
        Actor,
        Parent,
        Classmate,
        T,
        MDT,
        MD,
    }
}
