using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT
{

    public class TilesLogic
    {
        Random random = new Random();
        public bool[,] isTileActive;
        public int edgeSize;
        /// <summary>
        /// Methode create tiles in game area
        /// </summary>
        /// <param name="tilesPerEdge"></param>
        /// <param name="randomShufflePower"></param>
        public void NewGame(int tilesPerEdge, int randomShufflePower)
        {
            isTileActive = new bool[tilesPerEdge, tilesPerEdge];
            {
                for (int i = 0; i < tilesPerEdge; i++)
                {
                    for (int j = 0; j < tilesPerEdge; j++)
                    {
                        isTileActive[i, j] = true;
                    }
                }
            }
            edgeSize = tilesPerEdge;
            Shuffle(randomShufflePower);
        }
        /// <summary>
        /// Detected where was click, and change color if true
        /// </summary>
        /// <param name="column"></param>
        /// <param name="row"></param>
        public void ProcessInput(int column, int row)
        {
            isTileActive[column, row] ^= true;
            if (column > 0) isTileActive[column - 1, row] ^= true;
            if (column < edgeSize - 1) isTileActive[column + 1, row] ^= true;
            if (row > 0) isTileActive[column, row - 1] ^= true;
            if (row < edgeSize - 1) isTileActive[column, row + 1] ^= true;
        }
        /// <summary>
        /// Methode check all cels in game map on a yellow, if is true we won
        /// </summary>
        /// <returns></returns>
        public bool CheckForWin()
        {
            foreach (bool active in isTileActive)
            {
                if (!active) return false;
            }
            return true;
        }
        /// <summary>
        /// Methode generated random map for game
        /// </summary>
        /// <param name="power"></param>
        public void Shuffle(int power)
        {
            for (int i = 0; i < power; i++)
            {
                int column = random.Next(0, edgeSize);
                int row = random.Next(0, edgeSize);
                ProcessInput(column, row);
            }
            foreach (bool active in isTileActive)
            {
                if (!active) return;
            }
            Shuffle(power);
        }
    }
}
