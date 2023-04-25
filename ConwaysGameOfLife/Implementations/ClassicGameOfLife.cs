using ConwaysGameOfLife.Abstractions;

namespace ConwaysGameOfLife.Implementations
{
    public class ClassicGameOfLife : GameOfLifeBase
    {
        /* This is a constructor for the `ClassicGameOfLife` class that takes two integer parameters
        `x` and `y`. It sets the width and height of the game board using the `SetWidth` and
        `SetHeight` methods, respectively. It also sets the rules for the game using the
        `ClassicRules` class and initializes the game board with a 2D boolean array of size `x` by
        `y` using the `SetInitialGeneration` method. */
        public ClassicGameOfLife(int x, int y)
        {
            this.SetWidth(x);
            this.SetHeight(y);
            this.SetRules(new ClassicRules());
            this.SetInitialGeneration(new bool[x, y]);
        }

        /* This is a default constructor for the `ClassicGameOfLife` class that initializes the rules
        for the game using the `ClassicRules` class. It does not set the width, height, or initial
        state of the game board. */
        public ClassicGameOfLife()
        {
            this.SetRules(new ClassicRules());
        }

        /// <summary>
        /// This function generates the next generation of cells in a game of life simulation based on
        /// the current state and the rules applied to each cell.
        /// </summary>
        public override void NextGeneration()
        {
            bool[,] newCells = new bool[GetWidth(), GetHeight()];

            for (int x = 0; x < GetWidth(); x++)
            {
                for (int y = 0; y < GetHeight(); y++)
                {
                    bool cellState = GetCell(x, y);
                    int neighborsCount = CountWrapNeighbors(x, y);

                    newCells[x, y] = GetRules().ApplyRules(cellState, neighborsCount);
                }
            }

            UpdateBoard(newCells);
        }

        /// <summary>
        /// This function updates the game board with new cell values.
        /// </summary>
        /// <param name="newCells">A 2D boolean array representing the new state of the cells on the
        /// game board. The dimensions of the array should match the width and height of the game board.
        /// Each element in the array represents the state of a single cell on the game board, where
        /// true indicates that the cell is alive and</param>
        private void UpdateBoard(bool[,] newCells)
        {
            for (int x = 0; x < GetWidth(); x++)
            {
                for (int y = 0; y < GetHeight(); y++)
                {
                    SetCell(x, y, newCells[x, y]);
                }
            }
        }
    }
}
