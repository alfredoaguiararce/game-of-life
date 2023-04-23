# Conway's Game of Life Library

This is a C# .NET 6 library that implements Conway's Game of Life. It allows users to create a game instance, set initial states of cells, and iterate through generations.

**Installation**

Clone the repository or download the source code and add it to your project as a reference.


**Usage**

First, create a GameOfLifeBuilder instance to set up the game parameters, such as width, height, and game mode. Then, use the builder to create a new instance of the game.


```csharp
bool[,] initialBoard =
{
    { false, false, false },
    { false, true , false},
    { false, false, false }
};

GameOfLifeBase game = new GameOfLifeBuilder()
                      .SetAsClassicGameOfLife()
                      .SetWidth(3)
                      .SetHeight(3)
                      .SetInitialGeneration(initialBoard)
                      .Build()
```

To iterate through generations, call the NextGeneration() method.


```csharp
game.NextGeneration();

```

To get the current state of the board, call the GetCurrentBoard() method. To get the state of a specific cell, call the GetCell(int x, int y) method.


```csharp
bool[,] currentBoard = game.GetCurrentBoard();
bool isCellAlive = game.GetCell(1, 1);
```

To set the state of a specific cell, call the SetCell(int x, int y, bool isAlive) method.


```csharp
game.SetCell(1, 1, true);

```

**Testing**

The library comes with a set of unit tests to ensure the correctness of its implementation. Tests can be found in the ConwaysGameOfLifeTests directory.


**Contributing**

Contributions to this library are welcome. Please submit a pull request with your changes.


**License**

This library is licensed under the MIT License. See the LICENSE file for more information.