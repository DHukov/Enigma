using System;
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
        /// <param name="results">Two dimentional array that stores bool value of button state</param>
        /// <param name="gameEnded">Bool value of game state</param>
        /// <param name="buttonIndex">Two dimentonal array for button objects</param>
        /// <param name="random">Object used to generate random numbers</param>

        private bool[,] results;
        private bool gameEnded;
        private Button[,] buttonIndex;
        Random random = new Random();

        /// <summary>
        /// gives index number to every button object
        /// and resets it states
        /// then preforms random "shuffle" on the board
        /// in order to prepare it for player
        /// </summary>

        /// <param name="buttoni">Column</param>
        /// <param name="buttonj">row</param>

        private void NewGame()
        {
            results = new bool[5,5];
            buttonIndex = new Button[5, 5];
            int buttoni = 0;
            int buttonj = 0;
            for (var i = 0; i < 5; i++)
            {
                for (var j = 0; j < 5; j++)
                {
                    results[i,j] = true;
                }
            }

            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                buttonIndex[buttoni, buttonj] = button;
                button.Background = Brushes.Yellow;
                if (buttoni == 4)
                {
                    buttoni = 0;
                    buttonj++;
                }
                else
                {
                    buttoni++;
                }
            });

            //changing number can impact difficulty
            //Let it stay on 100, it provides
            //decent randomness and very high
            //chalange, while still performing fast
            for (var a = 0; a < 100; a++)
            {
                int i = random.Next(0, 5);
                int j = random.Next(0, 5);
                //Clicked Button
                results[i, j] ^= true;
                ChangeColor(i, j);
                //Left Button
                if (i != 0)
                {
                    results[i - 1, j] ^= true;
                    ChangeColor(i - 1, j);
                }
                //right button
                if (i != 4)
                {
                    results[i + 1, j] ^= true;
                    ChangeColor(i + 1, j);
                }
                //Up button
                if (j != 0)
                {
                    results[i, j - 1] ^= true;
                    ChangeColor(i, j - 1);
                }
                //Down button
                if (j != 4)
                {
                    results[i, j + 1] ^= true;
                    ChangeColor(i, j + 1);
                }

            }

            gameEnded = false;
        }
        /// <summary>
        ///  After button is pressed it checks if game was finished before
        ///  if yes, it starts a new game, if not, it changes
        ///  states of and colors of buttons and then
        ///  checks if game is won
        /// </summary>
        /// <param name="sender">The clicked button</param>
        /// <param name="e">data about the event</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (gameEnded)
            {
                NewGame();
                return;
            }

            var button = (Button)sender;
            int column = Grid.GetColumn(button);
            int row = Grid.GetRow(button);
            int i = column;
            int j = row;

            //Clicked Button
            results[i, j] ^= true;
            ChangeColor(i,j);
            //Left Button
            if (i != 0)
            {
                results[i - 1, j] ^= true;
                ChangeColor(i - 1, j);
            }
            //right button
            if(i != 4)
            {
                results[i + 1, j] ^= true;
                ChangeColor(i + 1, j);
            }
            //Up button
            if (j != 0)
            {
                results[i, j - 1] ^= true;
                ChangeColor(i, j - 1);
            }
            //Down button
            if (j != 4)
            {
                results[i, j + 1] ^= true;
                ChangeColor(i, j + 1);
            }
            WinCheck();           
        }

        /// <summary>
        ///  Changes color of button, to other color
        /// </summary>
        /// <param name="ar">Kolumna przycisku</param>
        /// <param name="b">Wiersz przycisku</param>
        void ChangeColor(int a, int b)
        {
            if (results[a, b])
            {
                buttonIndex[a, b].Background = Brushes.Yellow;
            }
            else
            {
                buttonIndex[a, b].Background = Brushes.Black;
            }
        }

        /// <summary>
        ///  Method that checks if game is won
        ///  if it is it changes color of all buttons to lime green
        ///  and changes state of the game, by changing bool to true
        /// </summary>
        private void WinCheck()
        {
            foreach (bool light in results)
            {
                if (!light)
                {
                    return;
                }
            }
            gameEnded = true;
            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Background = Brushes.LimeGreen;
            });
        }
    }
}
