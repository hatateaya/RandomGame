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
                Y = Pos.Bottom(timeLabel) + 2,
            };
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
            UpdateTime();
            Add(timeLabel, timerButton, viewButton);
        }
        public void UpdateTime() {
            timeLabel.Text = Logic.save.time.ToString();
            if (Logic.timer.Enabled)
            {
                timerButton.Text = "Pause";
                timerButton.Clicked -= Logic.timer.Start;
                timerButton.Clicked += Logic.timer.Stop;
                timerButton.Clicked -= UpdateTime;
                timerButton.Clicked += UpdateTime;
            }
            else
            {
                timerButton.Text = "Continue";
                timerButton.Clicked -= Logic.timer.Stop;
                timerButton.Clicked += Logic.timer.Start;
                timerButton.Clicked -= UpdateTime;
                timerButton.Clicked += UpdateTime;
            }
        }
    }
}
