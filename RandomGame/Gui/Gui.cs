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
        public static void Begin()
        {
            Console.SetWindowSize(80,24);

            Application.Init();
            Colors.Base.Normal = Application.Driver.MakeAttribute(Color.White, Color.Black); // Magic

            var menuBar = new MenuBar(new MenuBarItem[] { new MenuBarItem("_Help", new MenuItem[] { new MenuItem("_About", "", () => { MessageBox.Query("About", "A Random Game", "_OK"); }) }) });
            StartingWindow window = new StartingWindow();

            // Application.Resized += (Application.ResizedEventArgs args) => { Tools.SetTimeout(1000, () => { Application.Current.SetWidth(80, out _); Application.Current.SetHeight(24, out _); }); };
            
            Application.Top.Add(menuBar, window);
            Application.Run();
        }
        public static Pos AutoCenter(View viewOuter)
        {
            // Im amazed by this library,,,
            // Non-auto Center
            return Pos.Function(() => {
                int top = int.MaxValue;
                int bottom = int.MinValue;
                foreach (View view in viewOuter.Subviews)
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
                // Inline variable declarion
                viewOuter.GetCurrentHeight(out int applicationHeight);
                // Pos cannot convert to int, using frame hack
                return (applicationHeight - (bottom-top)) / 2;
            });
        }
    }
}
