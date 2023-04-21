namespace ConwaysGameOfLife.Utils
{
    public class GameOfLife
    {
        // Propiedades
        public int Width { get; set; } // Ancho del tablero
        public int Height { get; set; } // Altura del tablero
        public bool[,] Board { get; set; } // Tablero de células

        // Constructor
        public GameOfLife(int width, int height)
        {
            Width = width;
            Height = height;
            Board = new bool[width, height];
        }

        // Métodos
        public void SetCell(int x, int y, bool value)
        {
            // Asigna un valor a una célula específica
            Board[x, y] = value;
        }

        public bool GetCell(int x, int y)
        {
            // Devuelve el valor de una célula específica
            return Board[x, y];
        }

        public void NextGeneration()
        {
            // Calcula la siguiente generación del tablero
            bool[,] nextBoard = new bool[Width, Height];

            // Recorremos todas las células del tablero
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    int neighbors = CountNeighbors(x, y);

                    // Aplicamos las reglas del juego de la vida
                    if (Board[x, y])
                    {
                        if (neighbors == 2 || neighbors == 3)
                        {
                            nextBoard[x, y] = true;
                        }
                    }
                    else
                    {
                        if (neighbors == 3)
                        {
                            nextBoard[x, y] = true;
                        }
                    }
                }
            }

            // Actualizamos el tablero actual con el siguiente
            Board = nextBoard;
        }

        private int CountNeighbors(int x, int y)
        {
            // Cuenta el número de vecinos vivos de una célula específica
            int count = 0;

            // Recorremos las células vecinas
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    // Si la célula está dentro del tablero
                    if (x + i >= 0 && x + i < Width && y + j >= 0 && y + j < Height)
                    {
                        // Y no es la célula actual
                        if (i != 0 || j != 0)
                        {
                            // Contamos la célula si está viva
                            if (Board[x + i, y + j])
                            {
                                count++;
                            }
                        }
                    }
                }
            }

            return count;
        }
    }

}