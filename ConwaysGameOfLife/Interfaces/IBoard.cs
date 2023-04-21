namespace ConwaysGameOfLife.Interfaces
{

    public interface IBoard
    {
        int Width { get; set; }
        int Height { get; set; }
        bool[,] Board { get; set; }
        IGameRules GameRules { get; set; }
        void SetWidth(int Width);
        void SetHeight(int Height);
        int GetWidth();
        int GetHeight();
        void SetCell(int x, int y, bool value);
        bool GetCell(int x, int y);
        void NextGeneration();
        void SetInitialGeneration(bool[,] Board);
        bool[,] GetCurrentBoard();
        void SetRules(IGameRules Rules);
        IGameRules GetRules();
        void Init();
    }
}
