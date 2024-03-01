using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;
using Terminal.Gui.Trees;

namespace RandomGame
{
    class ViewWindow:Window
    {
        public ViewWindow() {
            Title = "Estajhos";

            var tree = new TreeView()
            {
                X = 4,
                Y = 2,
                Width=Dim.Fill(4),
                Height = Dim.Fill(2),
            };

            tree.AddObject((Estajho)Program.save.Get(Program.save.actorId));
            tree.ObjectActivated += (ObjectActivatedEventArgs<ITreeNode> args) =>
            {
                Gui.mainView.OpenView(this, new DisplayEstajho(((Estajho)args.ActivatedObject).id));
            };

            Add(tree);
        }
    }
}
