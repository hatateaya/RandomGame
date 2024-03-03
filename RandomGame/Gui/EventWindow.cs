using Terminal.Gui;

namespace RandomGame
{
    class EventWindow : Window
    {
        public EventWindow(Event theEvent,EventApplier applier)
        {
            Title = "Event";
            var nameLabel = new Label()
            {
                Text = theEvent.Name,
                X = Pos.Center(),
                Y = Gui.AutoCenterY(this),
            };
            var descriptionLabel = new Label()
            {
                Text = theEvent.Description,
                X = Pos.Center(),
                Y = Pos.Bottom(nameLabel) + 1,
            };
            Add(nameLabel, descriptionLabel);
            View prevView = descriptionLabel;
            foreach (Selection selection in theEvent.Selections)
            {
                var selectionButton = new Button()
                {
                    Text = selection.Text,
                    X = Pos.Center(),
                    Y = Pos.Bottom(prevView) + 1,
                };
                selectionButton.Clicked += () => { selection.Perform(applier); Gui.mainView.Back(); };
                prevView = selectionButton;
                Add(selectionButton);
            }
        }
    }
}
