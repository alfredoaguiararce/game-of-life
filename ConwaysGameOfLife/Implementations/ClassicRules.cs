using ConwaysGameOfLife.Interfaces;

namespace ConwaysGameOfLife.Implementations
{
    public class ClassicRules : IGameRules
    {
        /// <summary>
        /// This function applies the rules of Conway's Game of Life to determine the state of a cell
        /// based on its current state and the number of neighboring cells.
        /// </summary>
        /// <param name="cellState">a boolean value representing the current state of a cell (alive or
        /// dead)</param>
        /// <param name="neighborsCount">The number of neighboring cells that are currently alive (i.e.
        /// have a cellState of true).</param>
        /// <returns>
        /// The method returns a boolean value, which represents the new state of the cell after
        /// applying the rules of the Game of Life.
        /// </returns>
        public bool ApplyRules(bool cellState, int neighborsCount)
        {
            /* This line of code is checking if a cell is currently alive (cellState is true) and has
            less than 2 neighboring cells that are also alive (neighborsCount is less than 2). If
            this condition is true, it means that the cell is "underpopulated" and will die in the
            next generation, so the method returns false to represent the cell's new dead state. */
            if (cellState && neighborsCount < 2) return false; // underpopulation

            /* This line of code is checking if a cell is currently alive (cellState is true) and has
            either 2 or 3 neighboring cells that are also alive (neighborsCount is equal to 2 or 3).
            If this condition is true, it means that the cell has enough neighboring cells to
            survive in the next generation, so the method returns true to represent the cell's new
            alive state. */
            if (cellState && (neighborsCount == 2 || neighborsCount == 3)) return true; // survival

            /* This line of code is checking if a cell is currently alive (cellState is true) and has
            more than 3 neighboring cells that are also alive (neighborsCount is greater than 3). If
            this condition is true, it means that the cell is "overpopulated" and will die in the
            next generation, so the method returns false to represent the cell's new dead state. */
            if (cellState && neighborsCount > 3) return false; // overpopulation

            /* This line of code is checking if a cell is currently dead (cellState is false) and has
            exactly 3 neighboring cells that are alive (neighborsCount is equal to 3). If this
            condition is true, it means that the cell is surrounded by enough neighboring cells to
            be "born" in the next generation, so the method returns true to represent the cell's new
            alive state. This is known as the "reproduction" rule in Conway's Game of Life. */
            if (!cellState && neighborsCount == 3) return true; // reproduction

            /* `return cellState;` is the default case that is executed if none of the previous
            conditions are met. It simply returns the current state of the cell without changing it. */
            return cellState;
        }
    }
}
