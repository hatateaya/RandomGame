namespace RandomGame
{
    class Stato<T>
    {
        public string id { get; set; }
        public T value { get; set; }
        public string owner { get; set; }
        public Stato(T value,string owner)
        {
            id = Logic.save.New("stato", this);
            this.value = value;
            this.owner = owner;
        }
    }
}
