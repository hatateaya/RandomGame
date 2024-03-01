using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace RandomGame
{
    class DisplayEstajho : Window
    {
        public DisplayEstajho(string id)
        { 
            Estajho estajho = (Estajho)Program.save.Get(id);
            Title = "View estajho";
            var nameLabel = new Label()
            {
                Text = "Name: " + estajho.name,
                X = Pos.Center() -12,
                Y=Gui.AutoCenterY(this),
            };
            var genderLabel = new Label()
            {
                Text = "Gender: " + estajho.gender.ToString(),  
                X=Pos.X(nameLabel),
                Y=Pos.Bottom(nameLabel)+1,
            };
            var backButton = new Button()
            {
                Text = "Back",
                X = Pos.X(genderLabel),
                Y = Pos.Bottom(genderLabel) + 1,
                IsDefault = true,
            };
            backButton.Clicked += () =>
            {
                Gui.mainView.ChangeRightPane(Gui.viewBack);
                Gui.viewBack = null;
            };
            Add(nameLabel, genderLabel, backButton);
        }
    }
}
