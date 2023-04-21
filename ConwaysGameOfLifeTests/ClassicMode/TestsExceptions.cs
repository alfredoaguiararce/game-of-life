using ConwaysGameOfLife.Abstractions;
using ConwaysGameOfLife.Implementations;

namespace ConwaysGameOfLifeTests.ClassicMode
{

    [TestFixture]
    public class TestsExceptions
    {
        [Test]
        public void TestGettersAndSettersWithoutBoard()
        {
            GameOfLifeBase BaseBoard = new ClassicGameOfLife();

            Assert.Catch<ArgumentNullException>(() => BaseBoard.SetCell(1, 1, true));
            // Assert
            Assert.Catch<ArgumentNullException>(() => BaseBoard.GetCell(1, 1));
        }

        [Test]
        public void TestOutOfBoardCells()
        {
            GameOfLifeBase BaseBoard = new ClassicGameOfLife(3, 3);

            Assert.Catch<InvalidOperationException>(() => BaseBoard.SetCell(4, 4, true));
        }

        [Test]
        public void TestInitializer()
        {
            GameOfLifeBase BaseBoard = new ClassicGameOfLife();

            Assert.Catch<ArgumentNullException>(() => BaseBoard.Init());

            BaseBoard.SetWidth(1);
            Assert.That(BaseBoard.GetWidth(), Is.EqualTo(1));
            Assert.Catch<ArgumentNullException>(() => BaseBoard.Init());
            BaseBoard.SetHeight(1);
            Assert.That(BaseBoard.GetWidth(), Is.EqualTo(1));
            Assert.That(BaseBoard.GetHeight(), Is.EqualTo(1));
            Assert.DoesNotThrow(() => BaseBoard.Init());
        }


        [Test]
        public void TestInitializerBoardWithDiferentDimentions()
        {
            ClassicGameOfLife game = new ClassicGameOfLife(4, 4);
            // Arrange
            bool[,] initialBoard =
            {
                { false, false, false }, 
                { false, true , false},
                { false, false, false }
            };

            // Act
            Assert.Throws<ArgumentException>(() => game.SetInitialState(initialBoard));
        }
    }
}
