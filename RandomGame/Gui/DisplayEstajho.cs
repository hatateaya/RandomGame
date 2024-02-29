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
            Estajho estajho = (Estajho)Program.save.Get(Program.save.actorId);
            Title = "View estajho";
            var nameLabel = new Label()
            {
                Text = "Name: "+estajho.name,
                Y=1,
            };
            var genderLabel = new Label()
            {
                Text = "Gender: " + estajho.gender.ToString(),  
                Y=2,
            };
            Add(nameLabel, genderLabel);
        }
    }
}
