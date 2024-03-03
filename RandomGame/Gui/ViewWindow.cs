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
                Height = Dim.Fill(3),
            };

            tree.AddObject(new EstajhoTreeNode(Logic.save.Get<Estajho>(Logic.save.playerId)));
            tree.ObjectActivated += (ObjectActivatedEventArgs<ITreeNode> args) =>
            {
                Gui.mainView.OpenView(new DisplayEstajho(((EstajhoTreeNode)args.ActivatedObject).estajho.id));
            };

            var backButton = new Button()
            {
                Text = "_Back",
                X = Pos.Center(),
                Y = Pos.AnchorEnd(2),
            };
            backButton.Clicked += Gui.mainView.Back;

            Add(tree, backButton);
        }
    }
}
