namespace RandomGame
{
    class Stato
    {
        public string id { get; set; }
        public string name { get; set; }
        public StatoType type { get; set; }
        public string value { get; set; }
        public string owner { get; set; }
        public Stato(StatoType type, string name, string value, string owner)
        {
            id = owner + "." + name;
            Logic.save.Set(id, this);
            this.type = type;
            this.name = name;
            this.value = value;
            this.owner = owner;
            Logic.save.Get<Estajho>(owner).statos.Add(this.id);
            this.value = value;
        }
    }
    enum StatoType
    {
        Double,
        Bool,
        String,
    }
}

/*
HaveMentalillness B
Bipolar D
Depression D
ASD D
ADHD D

Gender S
Female Male Mtf Ftx
*/