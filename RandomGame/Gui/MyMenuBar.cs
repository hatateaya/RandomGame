using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace RandomGame
{
    class MyMenuBar : MenuBar
    {
        public MyMenuBar()
        {
            Menus = new MenuBarItem[] { new MenuBarItem("_Help", new MenuItem[] { new MenuItem("_About", "", () => { MessageBox.Query("About", "A Random Game", "_OK"); }) }) };
        }
    }
}
