using ConwaysGameOfLife.Utils;
namespace ConwaysGameOfLifeTests
{

    [TestFixture]
    public class GameOfLifeTests
    {
        [Test]
        public void TestSetAndGetCell()
        {
            // Create a 3 x 3 game
            GameOfLife game = new GameOfLife(3, 3);

            // Set the value of the cell x = 1, y = 1 is true
            game.SetCell(1, 1, true);

            // Assert
            Assert.IsTrue(game.GetCell(1, 1));
        }

        [Test]
        public void TestNextGeneration()
        {
            // Create a 3 x 3 game
            GameOfLife game = new GameOfLife(3, 3);

            // Set the value of the cell x = 1, y = 1 is true
            game.SetCell(1, 1, true);

            // Assert the setter of the cell
            Assert.IsTrue(game.GetCell(1, 1));

            // In theory the cell dies in next gen
            game.NextGeneration();

            // Assert
            Assert.IsFalse(game.GetCell(1, 1));
        }

        [Test]
        public void TestStableSquare()
        {
            // Creamos un juego de la vida con una configuración inicial
            GameOfLife game = new GameOfLife(4, 4);
            game.SetCell(1, 1, true);
            game.SetCell(1, 2, true);
            game.SetCell(2, 1, true);
            game.SetCell(2, 2, true);

            // Calculamos la siguiente generación
            game.NextGeneration();

            // Comprobamos que la configuración es la esperada
            Assert.IsTrue(game.GetCell(1, 1));
            Assert.IsTrue(game.GetCell(1, 2));
            Assert.IsTrue(game.GetCell(2, 1));
            Assert.IsTrue(game.GetCell(2, 2));
            Assert.IsFalse(game.GetCell(0, 0));
        }
    }

}