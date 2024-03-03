namespace RandomGame
{
    class Statos
    {
        public List<Stato> list;
        public Statos(EstajhoNewMode newMode, Gender gender, Realitys realitys)
        {
            list = new List<Stato>();

            Dictionary<StatoType, double> generateFactors = [];

            switch (newMode)
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
                var random = new Random(Logic.save.seed);
                if (random.NextDouble() <= generateFactors[key])
                {
                    list.Add(new Stato(key));
                }
            }
        }
        public bool IsHave(StatoType type)
        {
            foreach (Stato item in list)
            {
                if (item.Type == type)
                {
                    return true;
                }
            }
            return false;
        }
        public void Add(StatoType type)
        {
            if (!IsHave(type))
            {
                list.Add(new Stato(type));
            }
        }
        public void Remove(StatoType type)
        {
            foreach (Stato mensastato in list)
            {
                if (mensastato.Type == type)
                {
                    list.Remove(mensastato);
                    return;
                }
            }
        }
    }
    class Stato
    {
        public StatoType Type { get; set; }
        double Value { get; set; }
        public Stato(StatoType mensasatoType)
        {
            Type = mensasatoType;
            Value = new Random(Logic.save.seed).NextDouble();
        }
    }
    enum StatoType
    {
        Overdose,
        NSSI,
        GD,
        Abby,
        Trans,
        ASD,
        ADHD,
        Anorexia,
        Bipolar,
        BPD,
        Delirium,
        Depression,
        Depersonalization,
        Amnesia,
        Hypochondriasis,
        DID,
        Insomnia,
        OCD,
        PTSD,
        S,
        M,
        CD,
    }
    // maybe ICD-11?
}
