using ConwaysGameOfLife.Implementations;
using ConwaysGameOfLife.Interfaces;

namespace ConwaysGameOfLife.Tests
{
    [TestFixture]
    public class ClassicGameOfLifeTests
    {

        [Test]
        public void TestInitializerBoard()
        {
            ClassicGameOfLife game = new ClassicGameOfLife(3, 3);
            // Arrange
            bool[,] initialBoard =
            {
                { false, false, false },
                { false, true , false},
                { false, false, false }
            };

            // Act
            game.SetInitialGeneration(initialBoard);

            Assert.That(game.GetCurrentBoard(), Is.EqualTo(initialBoard));

            // Assert
            Assert.That(game.GetCell(1, 1), Is.EqualTo(true));

            game.NextGeneration();
            Assert.That(game.GetCell(1, 1), Is.EqualTo(false));
        }
    }
}
