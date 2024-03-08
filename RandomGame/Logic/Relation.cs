namespace RandomGame
{
    class Relation
    {
        public RelationType type { get; set; }
        public string id { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public Relation(RelationType type, string a, string b)
        {

            this.type = type;
            A = a;
            B = b;
            id = Logic.save.New("relation", this);
            Logic.save.Get<Estajho>(A).relations.Add(id);
            Logic.save.Get<Estajho>(B).relations.Add(id);
        }
        public Estajho GetAnother(string from)
        {
            if (A == from)
            {
                return Logic.save.Get<Estajho>(B);
            }
            else
            {
                return Logic.save.Get<Estajho>(A);
            }
        }
    }
    enum RelationType
    {
        Parent,
        // A is B's parent
        Couple,
        Classmate,
        Friend,
    }
}
