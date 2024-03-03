using Terminal.Gui;

namespace RandomGame
{
    class MainWindow : Window
    {
        Label timeLabel;
        Button timerButton;
        public MainWindow()
        {
            Width = Dim.Fill();
            Height = Dim.Fill();
            timeLabel = new Label()
            {
                X = Pos.Center(),
                Y = Gui.AutoCenterY(this),
            };
            timerButton = new Button()
            {
                X = Pos.Center(),
                Y = Pos.Bottom(timeLabel) + 1,
            };
            var viewButton = new Button()
            {
                Text = "View",
                X = Pos.Center(),
                Y = Pos.Bottom(timerButton) + 2,
                IsDefault = true,
            };
            viewButton.Clicked += () =>
            {
                Gui.mainView.OpenView(new ViewWindow());
            };
            if (Logic.timer.Enabled)
            {
                timerButton.Text = "Pause";
                timerButton.Clicked += PauseClicked;
            }
            else
            {
                timerButton.Text = "Continue";
                timerButton.Clicked += ContinueClicked;
            }
            UpdateTime();
            Add(timeLabel, timerButton, viewButton);
        }
        void ContinueClicked()
        {
            timerButton.Text = "Pause";
            timerButton.Clicked -= ContinueClicked;
            timerButton.Clicked += PauseClicked;
            Logic.timer.Start();
            Application.Refresh();
        }
        void PauseClicked()
        {
            timerButton.Text = "Continue";
            timerButton.Clicked -= PauseClicked;
            timerButton.Clicked += ContinueClicked;
            Logic.timer.Stop();
            Application.Refresh();
        }
        public void UpdateTime()
        {
            timeLabel.Text = Logic.save.time.ToString();
            Application.Refresh();
        }
    }
}
