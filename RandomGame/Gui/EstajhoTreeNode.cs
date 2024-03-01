using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Terminal.Gui.Trees;

namespace RandomGame
{
    class EstajhoTreeNode:TreeNode
    {
        public Estajho estajho;
        public RelationType? relationType;
        public EstajhoTreeNode(Estajho estajho)
        {
            this.estajho = estajho;
        }
        public EstajhoTreeNode(Estajho estajho,RelationType relationType)
        {
            this.estajho = estajho;
            this.relationType = relationType;
        }
        List<ITreeNode> GetChildren()
        {
            var anothers = estajho.relations.GetAnothers(estajho.id);
            List<ITreeNode> list = new List<ITreeNode>();
            foreach (var another in anothers)
            {
                list.Add(new EstajhoTreeNode(another.Value, another.Key));
            }
            return list;
        }
        string GetName()
        {
            if (relationType == null)
            {
                return estajho.name;
            }
            else
            {
                return relationType.ToString() + ": " + estajho.name;
            }
        }
        public override IList<ITreeNode> Children => GetChildren();
        public override string Text { get => GetName(); }
    }
}
