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
            Width = Dim.Fill();
            Height = Dim.Fill();
            var timeLabel = new Label()
            {
                // How to auto update?
                Text = Program.save.time.ToString(),
                X = Pos.Center(),
                Y = Gui.AutoCenterY(this),
            };
            var viewButton = new Button()
            {
                Text = "View",
                X = Pos.Center(),
                Y = Pos.Bottom(timeLabel) +2,
            };
            viewButton.Clicked += () =>
            {
                Gui.mainView.OpenView(new ViewWindow());
            };
            Add(timeLabel,  viewButton);
        }
    }
}
