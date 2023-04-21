namespace ConwaysGameOfLife.Abstractions
{
    public abstract class GameOfLifeBase : IGameOfLife
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public bool[,] Board { get; set; }

        public GameOfLifeBase(int width, int height)
        {
            Width = width;
            Height = height;
            Board = new bool[width, height];
        }

        public void SetCell(int x, int y, bool value)
        {
            Board[x, y] = value;
        }

        public bool GetCell(int x, int y)
        {
            return Board[x, y];
        }

        public abstract void NextGeneration();

        protected int CountNeighbors(int x, int y)
        {
            // Lógica para contar vecinos
        }
    }

    public interface IGameOfLife
    {
        int Width { get; set; }
        int Height { get; set; }
        bool[,] Board { get; set; }
        void SetCell(int x, int y, bool value);
        bool GetCell(int x, int y);
        void NextGeneration();
    }
}
