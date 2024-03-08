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
        MTF,
        Abby,
        Parent,
        Classmate,
        Dilei,
        MD,
        RandomNormal,
        RandomYINANS,
        Random,
    }
}
