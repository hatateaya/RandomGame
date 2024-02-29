using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace RandomGame
{
    class ViewWindow:Window
    {
        public ViewWindow() {
            Title = "View";

            var btn = new Button()
            {
                Text = "View",
            };
            btn.Clicked += () =>
            {
                Gui.mainView.ChangeRightPane(new DisplayEstajho("estajho.0"));
            };
            
            Add(btn);
        }
    }
}
