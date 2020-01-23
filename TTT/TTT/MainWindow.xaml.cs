﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TTT
{
    /// <summary>
    /// logic and interactions for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Main method and sequence of the program
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            NewGame();
        }
        TilesLogic logic;
        private Button[,] buttonIndex;
        int boardEdge = 4;


        private void NewGame()
        {
            logic = new TilesLogic();
            logic.NewGame(boardEdge,100);
            buttonIndex = new Button[boardEdge, boardEdge];
            AddButtonsToArray(boardEdge);
            ProcessColors(boardEdge);
        }
        public void AddButtonsToArray(int edge)
        {
            int i = 0;
            int j = 0;
            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                buttonIndex[i, j] = button;
                if (i == 3)
                {
                    i = 0;
                    j++;
                }
                else
                {
                    i++;
                }
            });
        }
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            if (logic.CheckForWin())
            {
                NewGame();
                return;
            } 
            var button = (Button)sender;
            int column = Grid.GetColumn(button);
            int row = Grid.GetRow(button);
            logic.ProcessInput(column, row);
            ProcessColors(boardEdge);
            if (logic.CheckForWin())
            {
                for (int i = 0; i < boardEdge; i++)
                {
                    for (int j = 0; j < boardEdge; j++)
                    {
                        buttonIndex[i, j].Background = Brushes.LimeGreen;
                    }
                }
            }
        }

        void ProcessColors(int edge)
        {
            for (int i = 0; i < edge; i++)
            {
                for (int j = 0; j < edge; j++)
                {
                    if (logic.isTileActive[i,j])
                    {
                        buttonIndex[i, j].Background = Brushes.Yellow;
                    }
                    else
                    {
                        buttonIndex[i, j].Background = Brushes.Black;
                    }
                }
            }
        }

    }
}
