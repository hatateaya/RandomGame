namespace RandomGame
{
    class Mensastatos
    {
        public List<Mensastato> list;
        public Mensastatos(EstajhoNewMode newMode, Gender gender, Realitys realitys)
        {
            list = new List<Mensastato>();

            Dictionary<MensastatoType, double> generateFactors = [];

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

            foreach (MensastatoType key in generateFactors.Keys)
            {
                var random = new Random(Logic.save.seed);
                if (random.NextDouble() <= generateFactors[key])
                {
                    list.Add(new Mensastato(key));
                }
            }
        }
        public bool IsHave(MensastatoType type)
        {
            foreach(Mensastato item in list)
            {
                if (item.Type == type)
                {
                    return true;
                }
            }
            return false;
        }
        public void Add(MensastatoType type)
        {
            if (!IsHave(type))
            {
                list.Add(new Mensastato(type));
            }
        } 
        public void Remove(MensastatoType type)
        {
            foreach(Mensastato mensastato in list)
            {
                if (mensastato.Type == type)
                {
                    list.Remove(mensastato);
                    return;
                }
            }
        }
    }
    class Mensastato
    {
        public MensastatoType Type { get; set; }
        double Value { get; set; }
        public Mensastato(MensastatoType mensasatoType)
        {
            Type = mensasatoType;
            Value = new Random(Logic.save.seed).NextDouble();
        }
    }
    enum MensastatoType
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
