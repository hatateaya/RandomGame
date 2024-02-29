using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace RandomGame
{
    static class Gui
    {
        public static MainView mainView;
        public static void Begin()
        {
            Console.SetWindowSize(80, 24);

            Application.Init();
            Colors.Base.Normal = Application.Driver.MakeAttribute(Color.White, Color.Black); // Magic

            var window = new StartingWindow();
            var menuBar = new MyMenuBar();

            // Application.Resized += (Application.ResizedEventArgs args) => { Tools.SetTimeout(1000, () => { Application.Current.SetWidth(80, out _); Application.Current.SetHeight(24, out _); }); };

            Application.Top.Add(menuBar, window);
            Application.Run();
        }
        public static Pos AutoCenterY(View viewOuter)
        {
            // Im amazed by this library,,,
            // Debugged alot for Window
            return Pos.Function(() => {
                int top = int.MaxValue;
                int bottom = int.MinValue;
                IList<View> subviews;
                if(viewOuter is Window)
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
                        // Pos cannot convert to int, using frame hack
                        top = view.Frame.Y;
                    }
                    if (view.Frame.Bottom >= bottom)
                    {
                        bottom = view.Frame.Bottom;
                    }
                }
                int applicationHeight;
                if(viewOuter is Window)
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
