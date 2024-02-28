using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace RandomGame
{
    class StartingWindow: Window
    {
        public StartingWindow() {
            Title = "Hey there!";

            var logoLabel = new Label()
            {
                Text = @"
  ___              _           ___                
 | _ \__ _ _ _  __| |___ _ __ / __|__ _ _ __  ___ 
 |   / _` | ' \/ _` / _ \ '  \ (_ / _` | '  \/ -_)
 |_|_\__,_|_||_\__,_\___/_|_|_\___\__,_|_|_|_\___|
",
                Y = 2,
                // Percent hard to archieve. 
                X = 8,
            };

            var newGameButton = new Button() {
                Text = "Start New Game",
                X = Pos.X(logoLabel)+1,
                Y = Pos.Bottom(logoLabel) + 3,
            };

            var loadGameButton = new Button()
            {
                Text = "Load Game",
                X = Pos.X(newGameButton),
                Y = Pos.Bottom(newGameButton) + 1,
            };

            var exitButton = new Button()
            {
                Text = "Exit",
                X = Pos.X(loadGameButton),
                Y = Pos.Bottom(loadGameButton) + 1,  
                
            };
            exitButton.Clicked += () =>
            {
                // how to exit the Application?
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
                Y = 13,
                X = 58,
            };

            this.Add(logoLabel, newGameButton,loadGameButton, exitButton, smallLogoLabel);
        }
    }
}
