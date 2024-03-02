using Terminal.Gui;

namespace RandomGame
{
    class MainView : View
    {
        public View leftPane;
        public View? rightPane;
        public MyMenuBar menuBar;
        public Stack<View> viewStack;
        public MainView(View left, View? right = null)
        {
            viewStack = new Stack<View>();
            Width = Dim.Fill();
            Height = Dim.Fill();
            menuBar = new MyMenuBar();
            leftPane = left;
            leftPane.Width = Dim.Percent(20);
            leftPane.Y = 1;
            if (right != null)
            {
                ChangeRightPane(right);
            }
            Add(menuBar, leftPane, rightPane);
        }
        public void ChangeRightPane(View right)
        {
            Remove(rightPane);
            rightPane = right;
            rightPane.Y = 1;
            rightPane.X = Pos.Right(leftPane) + 1;
            Add(rightPane);
        }
        public void OpenView(View view)
        {
            if (rightPane != null)
            {
                viewStack.Push(rightPane);
            }
            ChangeRightPane(view);
        }
        public void Back()
        {
            if (viewStack.Count != 0)
            {
                ChangeRightPane(viewStack.Pop());
            }
            else
            {
                Remove(rightPane);
            }
        }
    }
}
