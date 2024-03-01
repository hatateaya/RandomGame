namespace RandomGame
{
    class Relations
    {
        public List<string> relationIds;
        public List<KeyValuePair<RelationType, Estajho>> GetAnothers(string from)
        {
            var anothers = new List<KeyValuePair<RelationType, Estajho>>();
            foreach (String id in relationIds)
            {
                var relation = ((Relation)Logic.save.Get(id));
                anothers.Add(new KeyValuePair<RelationType, Estajho>(relation.type, relation.GetAnother(from)));
            }
            return anothers;
        }
        public void Add(string id)
        {
            relationIds.Add(id);
        }
        public Relations()
        {
            relationIds = new List<string>();
        }
    }
    class Relation
    {
        public RelationType type;
        public string id;
        public string A { get; set; }
        public string B { get; set; }
        public Relation(RelationType type, string a, string b)
        {

            this.type = type;
            A = a;
            B = b;
            id = Logic.save.New("relation", this);
            ((Estajho)Logic.save.Get(A)).relations.Add(id);
            ((Estajho)Logic.save.Get(B)).relations.Add(id);
        }
        public Estajho GetAnother(string from)
        {
            if (A == from)
            {
                return (Estajho)Logic.save.Get(B);
            }
            else
            {
                return (Estajho)Logic.save.Get(A);
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
