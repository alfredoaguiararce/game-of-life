namespace ConwaysGameOfLife.Models
{
    public class GameOfLifeStateSerialized
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public string? Board { get; set; }
    }
}
