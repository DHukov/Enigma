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
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Metoda wywoluje inne metody tworząc kolejność zdarzeń w programie.
        /// </summary>
        public MainWindow()
        {
            
            InitializeComponent();
            NewGame();
        }
        /// <param name="results">Zmienna służy do tworzena siatki</param>
        /// <param name="gameEnded">Zmienna jest jednym z stanów gry</param>
        /// <param name="buttonIndex">Zmienna przydziela do każdej komórki swój index, przez co możemy wiedzić z którą komórką działamy</param>
        /// <param name="random">Tworzy losową liczbę</param>

        private bool[,] results;
        private bool gameEnded;
        private Button[,] buttonIndex;
        Random random = new Random();

        /// <summary>
        /// Metoda tworzy lokacje w grze, gdzie będą się mieściły komórki, ktorę są wynegerowanne losowo oraz ich zmiana od
        /// </summary>

        /// <param name="buttoni">Kolumna</param>
        /// <param name="buttonj">Wiersz</param>

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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
