using Terminal.Gui;

namespace RandomGame
{
    class MainWindow : Window
    {
        public MainWindow()
        {
            Width = Dim.Fill();
            Height = Dim.Fill();
            var timeLabel = new Label()
            {
                // How to auto update?
                Text = Logic.save.time.ToString(),
                X = Pos.Center(),
                Y = Gui.AutoCenterY(this),
            };
            var timerButton = new Button()
            {
                X = Pos.Center(),
                Y = Pos.Bottom(timeLabel) + 2,
            };
            if (Logic.timer.Enabled)
            {
                timerButton.Text = "Pause";
                timerButton.Clicked += () =>
                {
                    Logic.timer.Stop();
                };
            }
            else
            {
                timerButton.Text = "Continue";
                timerButton.Clicked += () =>
                {
                    Logic.timer.Start();
                };
            }
            var viewButton = new Button()
            {
                Text = "View",
                X = Pos.Center(),
                Y = Pos.Bottom(timerButton) + 1,
                IsDefault = true,
            };
            viewButton.Clicked += () =>
            {
                Gui.mainView.OpenView(new ViewWindow());
            };
            Add(timeLabel, viewButton);
        }
    }
}
