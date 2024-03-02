using Terminal.Gui;
using Terminal.Gui.Trees;

namespace RandomGame
{
    class ViewWindow : Window
    {
        public ViewWindow()
        {
            Title = "Estajhos";

            var tree = new TreeView()
            {
                X = 4,
                Y = 2,
                Width = Dim.Fill(4),
                Height = Dim.Fill(2),
            };

            tree.AddObject(new EstajhoTreeNode((Estajho)Logic.save.Get(Logic.save.playerId)));
            tree.ObjectActivated += (ObjectActivatedEventArgs<ITreeNode> args) =>
            {
                Gui.mainView.OpenView(new DisplayEstajho(((EstajhoTreeNode)args.ActivatedObject).estajho.id));
            };

            Add(tree);
        }
    }
}
