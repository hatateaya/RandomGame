using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGame
{
    class Relations
    {
        public List<string> relationIds;
        public List<KeyValuePair<RelationType,Estajho>> GetAnothers(string from)
        {
            var anothers = new List<KeyValuePair<RelationType, Estajho>>();
            foreach(String id in relationIds)
            {
                var relation = ((Relation)Program.save.Get(id));
                anothers.Add(new KeyValuePair<RelationType, Estajho>(relation.type,relation.GetAnother(from)));
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
        public Relation(RelationType type,string a,string b) {

            this.type = type;
            A = a;
            B = b;
            id = Program.save.New("relation", this);
            ((Estajho)Program.save.Get(A)).relations.Add(id);
            ((Estajho)Program.save.Get(B)).relations.Add(id);
        }
        public Estajho GetAnother(string from)
        {
            if (A == from)
            {
                return (Estajho)Program.save.Get(B);
            }
            else
            {
                return (Estajho)Program.save.Get(A);
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
