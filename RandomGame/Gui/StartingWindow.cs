using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace RandomGame
{
    class StartingWindow : Window
    {
        public StartingWindow()
        {
            this.Border.BorderStyle = BorderStyle.None;

            var logoLabel = new Label()
            {
                Text = @"
  ___              _           ___                
 | _ \__ _ _ _  __| |___ _ __ / __|__ _ _ __  ___ 
 |   / _` | ' \/ _` / _ \ '  \ (_ / _` | '  \/ -_)
 |_|_\__,_|_||_\__,_\___/_|_|_\___\__,_|_|_|_\___|
",
                X = Pos.Center(),
                Y = Gui.AutoCenterY(this),
            };

            var newGameButton = new Button()
            {
                Text = "Start New Game",
                X = Pos.X(logoLabel) + 1,
                Y = Pos.Bottom(logoLabel) + 3,
            };
            newGameButton.Clicked += () =>
            {
                Logic.NewSave();
                IntoMain();
            };
            var loadGameButton = new Button()
            {
                Text = "Load Game",
                X = Pos.X(newGameButton),
                Y = Pos.Bottom(newGameButton) + 1,
            };
            loadGameButton.Clicked += () =>
            {
                var dialog = new OpenDialog("Open", "Choose the save.", new List<string> { ".json" });
                Application.Run(dialog);
                if (dialog.Canceled)
                    return;
                var currentFile = dialog.FilePath;
                Logic.LoadSave((string)currentFile);
                IntoMain();
            };
            var exitButton = new Button()
            {
                Text = "Exit",
                X = Pos.X(loadGameButton),
                Y = Pos.Bottom(loadGameButton) + 1,
            };
            exitButton.Clicked += () =>
            {
                Environment.Exit(0);
            };

            var smallLogoLabel = new Label()
            {
                Text = @"
  ,_  __ 
_/ (_(_/_
     _/_                   
  (__/                     
",
                Y = Pos.Bottom(exitButton) - 5,
                X = Pos.Right(logoLabel) - 9,
            };

            this.Add(logoLabel, newGameButton, loadGameButton, exitButton, smallLogoLabel);
        }
        void IntoMain()
        {
            Gui.mainView = new MainView(new MainWindow());
            Application.Current.RemoveAll();
            Application.Current.Add(Gui.mainView);
        }
    }
}
