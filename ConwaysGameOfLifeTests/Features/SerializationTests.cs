using ConwaysGameOfLife.Abstractions;
using ConwaysGameOfLife.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLifeTests.Features
{
    [TestFixture]
    public class SerializationTests
    {
        [Test]
        public void TestSerializationAndDeserialization()
        {
            // Create a game with an initial pattern
            bool[,] initialBoard =
            {
            { false, false, false },
            { false, true , false},
            { false, false, false }
        };
            GameOfLifeBase game1 = new GameOfLifeBuilder()
                .SetAsClassicGameOfLife()
                .SetWidth(3)
                .SetHeight(3)
                .SetInitialGeneration(initialBoard)
                .Build();

            // Serialize the game state
            string serializedState = game1.Serialize();

            // Create a new game and deserialize the state
            GameOfLifeBase game2 = new GameOfLifeBuilder()
                .SetAsClassicGameOfLife()
                .SetFromSerialized(serializedState)
                .Build();

            // Verify that the two games have the same properties
            Assert.That(game2.Width, Is.EqualTo(game1.Width));
            Assert.That(game2.Height, Is.EqualTo(game1.Height));
            for (int i = 0; i < game1.Width; i++)
            {
                for (int j = 0; j < game1.Height; j++)
                {
                    Assert.That(game2.GetCell(i, j), Is.EqualTo(game1.GetCell(i, j)));
                }
            }
        }
    }

}
