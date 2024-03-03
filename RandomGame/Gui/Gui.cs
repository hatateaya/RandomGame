using Terminal.Gui;

namespace RandomGame
{
    static class Gui
    {
        public static MainView? mainView;
        public static void Begin()
        {
            Console.SetWindowSize(80, 24);

            Application.Init();

            Colors.Base.Normal = Application.Driver.MakeAttribute(Color.White, Color.Black);
            Colors.Base.Focus = Application.Driver.MakeAttribute(Color.Black, Color.White);
            Colors.Base.HotFocus = Application.Driver.MakeAttribute(Color.Black, Color.Gray);
            Colors.Base.HotNormal = Application.Driver.MakeAttribute(Color.DarkGray, Color.Black);

            var window = new StartingWindow();
            var menuBar = new MyMenuBar();

            Application.Top.Add(menuBar, window);
            Application.Run();

            Application.Shutdown();
        }
        public static void OpenEventWindow(Event thisEvent, EventApplier applier)
        {
            mainView.OpenView(new EventWindow(thisEvent, applier));
        }
        public static void DisplayMessage(string message)
        {
            MessageBox.Query("Message", message, "OK");
        }
        public static Pos AutoCenterY(View viewOuter)
        {
            // Im amazed by this library,,,
            // Debugged alot for Window
            return Pos.Function(() =>
            {
                int top = int.MaxValue;
                int bottom = int.MinValue;
                IList<View> subviews;
                if (viewOuter is Window)
                {
                    subviews = viewOuter.Subviews[0].Subviews;
                }
                else
                {
                    subviews = viewOuter.Subviews;
                }
                foreach (View view in subviews)
                {
                    if (view.Frame.Y <= top)
                    {
                        top = view.Frame.Y;
                    }
                    if (view.Frame.Bottom >= bottom)
                    {
                        bottom = view.Frame.Bottom;
                    }
                }
                int applicationHeight;
                if (viewOuter is Window)
                {
                    viewOuter.Subviews[0].GetCurrentHeight(out applicationHeight);
                }
                else
                {
                    viewOuter.GetCurrentHeight(out applicationHeight);
                }
                return (applicationHeight - (bottom - top)) / 2;
            });
        }
    }
}
