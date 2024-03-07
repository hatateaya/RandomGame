namespace RandomGame
{
    class Estajho
    {
        public string id;
        public string name;
        public Gender gender;
        public EventApplier eventApplier;
        public Dictionary<StatoType, Stato> statos;
        public Relations relations;
        public Estajho(EstajhoNewMode estajhoNewMode)
        {
            id = Logic.save.New("estajho", this);
            gender = GenerateGender(estajhoNewMode);
            name = GenerateName(gender);
            statos = [];
            StatoInitialize(estajhoNewMode, gender);
            relations = new Relations();
            if (estajhoNewMode != EstajhoNewMode.Parent)
            {
                _ = new Relation(RelationType.Parent, new Estajho(EstajhoNewMode.Parent).id, id);
                _ = new Relation(RelationType.Parent, new Estajho(EstajhoNewMode.Parent).id, id);
            }
            eventApplier = new EventApplier(this);
        }
        Gender GenerateGender(EstajhoNewMode estajhoNewMode)
        {
            // Should be update with factors.
            var gender = estajhoNewMode switch
            {
                EstajhoNewMode.Actor => (Gender)Tools.RandomSelect(Gender.Mtf, Gender.Mtx, Gender.Female, Gender.Futa),
                EstajhoNewMode.MTF => (Gender)Tools.RandomSelect(Gender.Mtx, Gender.Mtx, Gender.Futa),
                EstajhoNewMode.Abby => (Gender)Tools.RandomSelect(Gender.Mtx, Gender.Ftx, Gender.Futa),
                EstajhoNewMode.Dilei => Gender.Female,
                EstajhoNewMode.Random or EstajhoNewMode.RandomYINANS => (Gender)Tools.RandomSelect(Gender.Male, Gender.Female, Gender.Mtf, Gender.Mtx, Gender.Ftm, Gender.Ftx, Gender.Futa),
                _ => (Gender)Tools.RandomSelect(Gender.Male, Gender.Female),
            };
            return gender;
        }
        string GenerateName(Gender gender)
        {
            string[] maleNames = [
            "Hiroto","Shota","Ren","Sora","Yuto","Yudo","Yuma","Eita","Sho" ];
            string[] femaleNames = [
            "Rin","Sakura","Yua","Hina","Miu","Yui","Miyu","Misaki","Aoi" ];
            return gender switch
            {
                Gender.Male or Gender.Ftm => (Tools.RandomSelect(maleNames)),
                Gender.Female or Gender.Mtf => (Tools.RandomSelect(femaleNames)),
                _ => (Tools.RandomSelect(femaleNames.Union<string>(maleNames).ToArray<string>())),
            };
        }
        void StatoInitialize(EstajhoNewMode estajhoNewMode, Gender gender)
        {
            Dictionary<StatoType, double> generateFactors = [];
            switch (estajhoNewMode)
            {
                case EstajhoNewMode.Player:
                    break;
                case EstajhoNewMode.Actor:
                    break;
                case EstajhoNewMode.MTF:
                    break;
                case EstajhoNewMode.Abby:
                    break;
                case EstajhoNewMode.Parent:
                    break;
                case EstajhoNewMode.Classmate:
                    break;
                case EstajhoNewMode.Dilei:
                    break;
                default:
                    break;
            };
            foreach (StatoType key in generateFactors.Keys)
            {
                if (Tools.Lucky(generateFactors[key]))
                {
                    statos[key] = new Stato(key);
                }
            }
        }
    }
    enum Gender
    {
        Male,
        Female,
        Mtf,
        Ftm,
        Mtx,
        Ftx,
        Futa,
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
