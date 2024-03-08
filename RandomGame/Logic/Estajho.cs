namespace RandomGame
{
    class Estajho
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<string> statos { get; set; }
        public List<string> relations { get; set; }
        
        public EventApplier eventApplier;
        public Estajho(EstajhoNewMode estajhoNewMode= EstajhoNewMode.None,List<EstajhoBasicTypes>? estajhoBasicTypes = null)
        {
            id = Logic.save.New("estajho", this);
            name = GenerateName();
            statos = [];
            relations = [];
            eventApplier = new EventApplier(this);
            List<EstajhoBasicTypes> basicTypes = new();
            if (estajhoNewMode == EstajhoNewMode.None&& estajhoBasicTypes != null)
            {
                basicTypes = estajhoBasicTypes;
            }else if (estajhoNewMode != EstajhoNewMode.None)
            {
                switch (estajhoNewMode)
                {
                    case EstajhoNewMode.Player:
                        _ = new Relation(RelationType.Friend, id, new Estajho(EstajhoNewMode.Actor).id);
                        basicTypes.Add(EstajhoBasicTypes.Normal);
                        basicTypes.Add(EstajhoBasicTypes.Cis);
                        break;
                    case EstajhoNewMode.Actor:
                        basicTypes.Add(EstajhoBasicTypes.Trans);
                        basicTypes.Add(EstajhoBasicTypes.MentalIllness);
                        break;
                    case EstajhoNewMode.Classmate:
                        if (Tools.Lucky(0.1))
                        {
                            basicTypes.Add(EstajhoBasicTypes.Trans);
                            if (Tools.Lucky(0.5))
                            {
                                basicTypes.Add(EstajhoBasicTypes.MentalIllness);
                            }
                        }
                        else if (Tools.Lucky(0.05))
                        {
                            basicTypes.Add(EstajhoBasicTypes.Cis);
                            basicTypes.Add(EstajhoBasicTypes.MentalIllness);
                        }
                        else
                        {
                            basicTypes.Add(EstajhoBasicTypes.Cis);
                            basicTypes.Add(EstajhoBasicTypes.Normal);
                        }
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            else
            {
                throw new ArgumentException();
            }
            if (estajhoNewMode != EstajhoNewMode.Parent)
            {
                _ = new Relation(RelationType.Parent, id, new Estajho(EstajhoNewMode.Parent).id);
                _ = new Relation(RelationType.Parent, id, new Estajho(EstajhoNewMode.Parent).id);
            }
            foreach(var type in basicTypes)
            {
                switch (type)
                {
                    case EstajhoBasicTypes.MentalIllness:
                        
                        break;
                    case EstajhoBasicTypes.Trans:

                        break;
                    case EstajhoBasicTypes.Cis:
                        
                    default:
                        break;
                }
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
        None,
    }
    enum EstajhoBasicTypes
    {
        MentalIllness,
        Normal,
        Trans,
        Cis,
    }
}
