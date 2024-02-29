using System;
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
            Border.BorderStyle = BorderStyle.Double;
            Width = Dim.Fill();
            Height = Dim.Fill();

            var timeLabel = new Label()
            {
                // How to auto update?
                Text = "Time:"+Program.save.time.ToString(),
                X = Pos.Percent(20),
                Y = 4,
            };
            // Theres no layout displayer.
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
