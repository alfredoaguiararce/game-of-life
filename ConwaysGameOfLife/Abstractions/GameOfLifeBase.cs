using ConwaysGameOfLife.Interfaces;

namespace ConwaysGameOfLife.Abstractions
{
    public abstract class GameOfLifeBase : IBoard
    {
        /* These are properties of the abstract class `GameOfLifeBase`. */
        public int Width { get; set; }
        public int Height { get; set; }
        public bool[,] Board { get; set; }
        public IGameRules GameRules { get; set; }

        /* `public GameOfLifeBase(){}` is a default constructor for the abstract class
        `GameOfLifeBase`. It does not take any parameters and does not have any implementation. It
        is used to create an instance of the class with default values for its properties. */
        public GameOfLifeBase(){}

        /// <summary>
        /// This function sets the initial state of a board with a given size and throws an exception if
        /// the size is not the same as the board size.
        /// </summary>
        /// <param name="Board">a two-dimensional boolean array representing the initial state of a
        /// board game.</param>
        public void SetInitialState(bool[,] Board)
        {
            if(Board.GetLength(0) != this.Width || Board.GetLength(1) != this.Height) throw new ArgumentException("The board size is not the same as the board size.");
            this.Board = Board;
        }

        /// <summary>
        /// This function sets the value of a cell in a board at a given position.
        /// </summary>
        /// <param name="x">The x-coordinate of the cell to be set in the board.</param>
        /// <param name="y">The y parameter represents the vertical position of the cell in the board.
        /// It is used to access the correct row in the two-dimensional array that represents the
        /// board.</param>
        /// <param name="value">A boolean value that represents the value to be set in the cell at
        /// position (x, y) on the board. If value is true, the cell will be marked as "alive", and if
        /// value is false, the cell will be marked as "dead".</param>
        public void SetCell(int x, int y, bool value)
        {
            CheckBoardExists();
            CheckCellInBoard(x, y);
            Board[x, y] = value;
        }

        /// <summary>
        /// This function returns the boolean value of a cell in a board at a given position.
        /// </summary>
        /// <param name="x">The x-coordinate of the cell in the board.</param>
        /// <param name="y">The y parameter represents the vertical position of the cell in the board.
        /// It is usually an integer value that ranges from 0 to the height of the board minus
        /// 1.</param>
        /// <returns>
        /// A boolean value representing the state of the cell at position (x, y) on the board.
        /// </returns>
        public bool GetCell(int x, int y)
        {
            CheckBoardExists();
            CheckCellInBoard(x, y);
            return Board[x, y];
        }

        /// <summary>
        /// This C# function returns the value of the "Width" property of an object.
        /// </summary>
        public int GetWidth() => this.Width;
        /// <summary>
        /// This C# function returns the value of the "Height" property of an object.
        /// </summary>
        public int GetHeight() => this.Height;
        /// <summary>
        /// This function returns the current state of the board as a boolean 2D array.
        /// </summary>
        public bool[,] GetCurrentBoard() => this.Board;

        /// <summary>
        /// This is an abstract method in C# that is used to generate the next generation.
        /// </summary>
        public abstract void NextGeneration();

        /// <summary>
        /// This function counts the number of live neighbors surrounding a given cell on a game board.
        /// </summary>
        /// <param name="X">The X-coordinate of the cell for which we want to count the number of live
        /// neighbors.</param>
        /// <param name="Y">The Y parameter represents the vertical position of a cell on the game
        /// board. It is used in the CountNeighbors method to calculate the number of live neighboring
        /// cells around a given cell at position (X, Y).</param>
        /// <returns>
        /// The method is returning an integer value which represents the count of live neighbors for a
        /// given cell on a board.
        /// </returns>
        protected int CountNeighbors(int X, int Y)
        {
            int liveNeighborCount = 0;

            // Check each neighboring cell
            for (int rowOffset = -1; rowOffset <= 1; rowOffset++)
            {
                for (int colOffset = -1; colOffset <= 1; colOffset++)
                {
                    int neighborX = X + rowOffset;
                    int neighborY = Y + colOffset;

                    // Check if neighbor is inside the board bounds
                    bool neighborInsideBoard = neighborX >= 0 && neighborX < Width && neighborY >= 0 && neighborY < Height;

                    // Exclude the current cell from neighbor count
                    bool neighborIsNotCurrentCell = rowOffset != 0 || colOffset != 0;

                    if (neighborInsideBoard && neighborIsNotCurrentCell && Board[neighborX, neighborY])
                    {
                        liveNeighborCount++;
                    }
                }
            }

            return liveNeighborCount;
        }

        /// <summary>
        /// The function sets the game rules for a game.
        /// </summary>
        /// <param name="IGameRules">IGameRules is an interface that defines the rules of a game. The
        /// SetRules method takes an object that implements this interface and sets it as the GameRules
        /// property of the current object. This allows the game to be played according to the specified
        /// rules.</param>
        public void SetRules(IGameRules Rules)
        {
            this.GameRules = Rules;
        }

        /// <summary>
        /// The function sets the width of an object.
        /// </summary>
        /// <param name="Width">an integer value representing the width of an object or element. The
        /// method "SetWidth" sets the value of the width property of an object to the specified integer
        /// value.</param>
        public void SetWidth(int Width)
        {
            this.Width = Width;
        }

        /// <summary>
        /// The function sets the height of an object.
        /// </summary>
        /// <param name="Height">The parameter "Height" is an integer value that represents the height
        /// of an object or entity. The method "SetHeight" sets the value of the object's height to the
        /// provided integer value. The "this" keyword refers to the current instance of the
        /// object.</param>
        public void SetHeight(int Height)
        {
            this.Height = Height;
        }

        /// <summary>
        /// The function returns the game rules.
        /// </summary>
        /// <returns>
        /// An object of type `IGameRules` is being returned. The specific object being returned is the
        /// `GameRules` property of the current instance of the class.
        /// </returns>
        public IGameRules GetRules() => this.GameRules;

        /// <summary>
        /// The function initializes the game board and checks for any errors.
        /// </summary>
        public void Init()
        {
            if (GetHeight() == 0) throw new ArgumentNullException("Height cannont be null or zero.");
            if (GetWidth() == 0) throw new ArgumentNullException("Width cannont be null or zero.");
            if (GetRules() == null) throw new ArgumentNullException("The rules of the board aren't initialize..");

            SetInitialState(new bool[Width, Height]);
            CheckBoardExists();
        }

        /// <summary>
        /// The function checks if the board is initialized and throws an exception if it is not.
        /// </summary>
        private void CheckBoardExists()
        {
            if (this.Board == null) throw new ArgumentNullException("The board isnt initialize now.");
        }

        /// <summary>
        /// The function checks if a given cell is within the boundaries of a board.
        /// </summary>
        /// <param name="x">The x-coordinate of the cell being checked in the board.</param>
        /// <param name="y">The y parameter represents the vertical position of a cell on a
        /// board.</param>
        private void CheckCellInBoard(int x, int y)
        {
            if (x > this.Width || y > this.Height) throw new InvalidOperationException("The cell is outside the board.");
        }
    }
}
