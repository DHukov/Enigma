using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT
{
    class TilesLogic
    {
        Random random = new Random();
        public bool[,] isTileActive;
        public int edgeSize;
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
            for (int i = 0; i < randomShufflePower; i++)
            {
                int column = random.Next(0, tilesPerEdge);
                int row = random.Next(0, tilesPerEdge);
                ProcessInput(column, row);
            }
        }
        public void ProcessInput(int column, int row)
        {
            isTileActive[column, row] ^= true;
            if (column > 0) isTileActive[column - 1, row] ^= true;
            if (column < edgeSize - 1) isTileActive[column + 1, row] ^= true;
            if (row > 0) isTileActive[column, row - 1] ^= true;
            if (row < edgeSize - 1) isTileActive[column, row + 1] ^= true;
        }
        public bool CheckForWin()
        {
            foreach (bool active in isTileActive)
            {
                if (!active) return false;
            }
            return true;
        }
    }
}
