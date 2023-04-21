using ConwaysGameOfLife.Abstractions;
using ConwaysGameOfLife.Implementations;
using ConwaysGameOfLife.Interfaces;

namespace ConwaysGameOfLife.Builders
{
    public class GameOfLifeBuilder
    {
        private GameOfLifeBase Game;

        public GameOfLifeBuilder() { }

        public GameOfLifeBuilder SetWidth(int width)
        {
            this.Game.SetWidth(width);
            return this;
        }

        public GameOfLifeBuilder SetHeight(int height)
        {
            this.Game.SetHeight(height);
            return this;
        }

        public GameOfLifeBuilder SetInitialGeneration(bool[,] initialGeneration)
        {
            this.Game.SetInitialGeneration(initialGeneration);
            return this;
        }

        public GameOfLifeBuilder SetRules(IGameRules rules)
        {
            this.Game.SetRules(rules);
            return this;
        }

        public GameOfLifeBuilder SetAsClassicGameOfLife()
        {
            this.Game = new ClassicGameOfLife();
            return this;
        }

        public GameOfLifeBuilder SetAsClassicGameOfLife(int X, int Y)
        {
            this.Game = new ClassicGameOfLife(X, Y);
            return this;
        }

        public GameOfLifeBase Build()
        {
            this.Game.Init();
            return this.Game;
        }
    }
}
