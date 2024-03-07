namespace RandomGame
{
    class Stato
    {
        public StatoType Type { get; set; }
        public double Value { get; set; }
        public Stato(StatoType mensasatoType)
        {
            Type = mensasatoType;
            Value = new Random(Logic.save.seed).NextDouble();
        }
    }
    enum StatoType
    {
        Depressed,
        Exhilarated,
        // Mensastatoj
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
}
