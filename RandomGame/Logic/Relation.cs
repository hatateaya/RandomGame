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
        public List<Estajho> GetAnothers(string from)
        {
            var anothers = new List<Estajho>();
            foreach(String id in relationIds)
            {
                anothers.Add(((Relation)Program.save.Get(id)).GetAnother(from));
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
        public string id;
        public string A { get; set; }
        public string B { get; set; }
        public Relation(string a,string b) {
            
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
}
