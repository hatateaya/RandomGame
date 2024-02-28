﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace RandomGame
{
    class MainWindow : Window
    {
        public MainWindow() {
            Title = "Game";
            this.Border.BorderStyle = BorderStyle.Double;

            var timeLabel = new Label()
            {
                // How to autoUpdate?
                Text = "Time:"+Program.save.time.ToString(),
                X = Pos.Percent(20),
                Y = 4,
            };
            // Theres no layout displayer.
            // Poor english.
            var viewButton = new Button()
            {
                Text = "View",
                X = Pos.X(timeLabel),
                Y = Pos.Bottom(timeLabel)+1,
            };
            Add(timeLabel,viewButton);
        }
    }
}