using ConwaysGameOfLife.Abstractions;
using ConwaysGameOfLife.Builders;

namespace ConwaysGameOfLifeTests.ClassicMode
{
    [TestFixture]
    public class BuilderTets
    {
        [Test]
        public void TestBuilderWithInitialGeneration()
        {
            // Arrange
            bool[,] initialBoard =
            {
                { false, false, false },
                { false, true , false},
                { false, false, false }
            };

            GameOfLifeBase Game = new GameOfLifeBuilder()
                                  .SetAsClassicGameOfLife()
                                  .SetWidth(3)
                                  .SetHeight(3)
                                  .SetInitialGeneration(initialBoard)
                                  .Build();

            Assert.That(Game.GetCurrentBoard(), Is.EqualTo(initialBoard));
            // Assert
            Assert.IsTrue(Game.GetCell(1, 1));
        }

        [Test]
        public void TestSetAndGetCell()
        {

            GameOfLifeBase Game = new GameOfLifeBuilder()
                                  .SetAsClassicGameOfLife()
                                  .SetWidth(3)
                                  .SetHeight(3)
                                  .Build();

            // TODO -> Set cell could be a method of the builder
            Game.SetCell(1, 1, true);
            // Assert
            Assert.IsTrue(Game.GetCell(1, 1));

            Game.NextGeneration();
            // Assert
            Assert.IsFalse(Game.GetCell(1, 1));
        }
    }
}
