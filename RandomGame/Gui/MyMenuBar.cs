﻿using Terminal.Gui;

namespace RandomGame
{
    class MyMenuBar : MenuBar
    {
        public MyMenuBar()
        {
            var TestMBI = new MenuBarItem("_Test", new MenuItem[] { });

            var aboutMI = new MenuItem("_About", "", ShowAbout);
            var helpMBI = new MenuBarItem("_Help", new MenuItem[] { aboutMI });

            var newMI = new MenuItem("_New", "", ShowAbout);
            var loadMI = new MenuItem("_Load", "", ShowAbout);
            var saveMI = new MenuItem("_Save", "", ShowAbout);
            var exitMI = new MenuItem("_Exit", "", () => Environment.Exit(0));
            var gameMBI = new MenuBarItem("_Game", new MenuItem[] { newMI, loadMI, saveMI, exitMI });

            Menus = [gameMBI, helpMBI, TestMBI];
        }
        void ShowAbout()
        {
            MessageBox.Query("About", "A Random Game", "_OK");
        }
    }
}
