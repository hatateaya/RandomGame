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
            var aboutMI = new MenuItem("_About", "", ShowAbout);
            var helpMBI = new MenuBarItem("_Help",new MenuItem[] {aboutMI});

            var newMI = new MenuItem("_New", "", ShowAbout);
            var loadMI = new MenuItem("_Load", "", ShowAbout);
            var saveMI = new MenuItem("_Save", "", ShowAbout);
            var gameMBI = new MenuBarItem("_Game", new MenuItem[] { newMI,loadMI,saveMI });

            Menus = new MenuBarItem[] { gameMBI,helpMBI };
        }
        void ShowAbout()
        {
            MessageBox.Query("About", "A Random Game", "_OK");
        }
    }
}
