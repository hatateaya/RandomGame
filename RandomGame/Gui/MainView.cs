﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace RandomGame
{
    class MainView : View
    {
        public View leftPane;
        public View rightPane;
        public MyMenuBar menuBar;
        public MainView(View left, View right =null)
        {
            Width = Dim.Fill();
            Height = Dim.Fill();
            menuBar= new MyMenuBar();
            leftPane = left;
            leftPane.Width = Dim.Percent(20);
            leftPane.Y = 1;
            if (right != null)
            {
                ChangeRightPane(right);
            }
            Add(menuBar,leftPane, rightPane);
        }
        public void ChangeRightPane(View right)
        { 
            Remove(rightPane);
            rightPane = right;
            rightPane.Y = 1;
            rightPane.X = Pos.Right(leftPane) + 1;
            Add(rightPane);
        }
    }
}
