namespace ConwaysGameOfLife.Interfaces
{
    public interface IGameRules
    {
        bool ApplyRules(bool cellState, int neighborsCount);
    }
}
