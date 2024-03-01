using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;
using Terminal.Gui.Trees;

namespace RandomGame
{
    class DisplayEstajho : Window
    {
        public string id;
        public DisplayEstajho(string id)
        {
            this.id = id;
            // as is
            Estajho estajho = (Estajho)Program.save.Get(id);
            Title = "View estajho";
            var nameLabel = new Label()
            {
                Text = "Name: " + estajho.name,
                X = Pos.Center() -12,
                Y=Gui.AutoCenterY(this),
            };
            var genderLabel = new Label()
            {
                Text = "Gender: " + estajho.gender.ToString(),  
                X=Pos.X(nameLabel),
                Y=Pos.Bottom(nameLabel)+1,
            };
            var relationsTree = new TreeView()
            {
                X = Pos.Center(),
                Y = Pos.Bottom(genderLabel) + 1,
                Width = Dim.Percent(50),
                Height=Dim.Percent(30),
            };
            relationsTree.AddObject(new EstajhoTreeNode(estajho));
            relationsTree.ObjectActivated  += (ObjectActivatedEventArgs<ITreeNode> args) =>
            {
                var estajho = ((EstajhoTreeNode)args.ActivatedObject).estajho;
                if (estajho.id != this.id)
                {
                    Gui.mainView.OpenView(this, new DisplayEstajho(estajho.id));
                }
            };
            var backButton = new Button()
            {
                Text = "_Back",
                X = Pos.X(genderLabel),
                Y = Pos.Bottom(relationsTree) + 1,
                IsDefault = true,
            };
            backButton.Clicked += () =>
            {
                Gui.mainView.Back();
            };
            Add(nameLabel, genderLabel, relationsTree,backButton);
        }
    }
}
