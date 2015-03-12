namespace Matrix
{
    using System;

    public class Matrix
    {
        public static void Main(string[] args)
        {
            int size = ReadMatrixSize();
            int[,] matrix = FillMatrix(size);
            PrintMatrix(size, matrix);
        }

        public static int[,] FillMatrix(int size)
        {
            int[,] matrix = new int[size, size];
            int value = 1;
            int row = 0;
            int col = 0;
            int directionX = 1;
            int directionY = 1;

            while (true)
            {
                matrix[row, col] = value;
                if (!CheckNextCell(matrix, row, col))
                {
                    break;
                }

                while (row + directionX >= size || row + directionX < 0 || col + directionY >= size || col + directionY < 0
                       || matrix[row + directionX, col + directionY] != 0)
                {
                    ChangeDirection(ref directionX, ref directionY);
                }

                row += directionX;
                col += directionY;
                value++;
            }

            value++;
            FindStartCell(matrix, out row, out col);
            if (row == 0 || col == 0)
            {
                return matrix;
            }

            directionX = 1;
            directionY = 1;

            while (true)
            {
                matrix[row, col] = value;
                if (!CheckNextCell(matrix, row, col))
                {
                    break;
                }

                if (row + directionX >= size || row + directionX < 0 || col + directionY >= size || col + directionY < 0
                    || matrix[row + directionX, col + directionY] != 0)
                {
                    while (row + directionX >= size || row + directionX < 0 || col + directionY >= size
                           || col + directionY < 0 || matrix[row + directionX, col + directionY] != 0)
                    {
                        ChangeDirection(ref directionX, ref directionY);
                    }
                }

                row += directionX;
                col += directionY;
                value++;
            }

            return matrix;
        }

        public static void PrintMatrix(int size, int[,] matrix)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write("{0,4}", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        public static int ReadMatrixSize()
        {
            Console.WriteLine("Enter a positive number ");
            string input = Console.ReadLine();
            int size;
            while (!int.TryParse(input, out size) || size < 0 || size > 100)
            {
                Console.WriteLine("You haven't entered a correct positive number");
                input = Console.ReadLine();
            }

            return size;
        }

        private static void ChangeDirection(ref int dX, ref int dY)
        {
            int[] directionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int cd = 0;
            for (int count = 0; count < 8; count++)
            {
                if (directionsX[count] == dX && directionsY[count] == dY)
                {
                    cd = count;
                    break;
                }
            }

            if (cd == 7)
            {
                dX = directionsX[0];
                dY = directionsY[0];
                return;
            }

            dX = directionsX[cd + 1];
            dY = directionsY[cd + 1];
        }

        private static bool CheckNextCell(int[,] arr, int x, int y)
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            for (int i = 0; i < 8; i++)
            {
                if (x + dirX[i] >= arr.GetLength(0) || x + dirX[i] < 0)
                {
                    dirX[i] = 0;
                }

                if (y + dirY[i] >= arr.GetLength(0) || y + dirY[i] < 0)
                {
                    dirY[i] = 0;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                if (arr[x + dirX[i], y + dirY[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private static void FindStartCell(int[,] arr, out int x, out int y)
        {
            x = 0;
            y = 0;
            for (int row = 0; row < arr.GetLength(0); row++)
            {
                for (int col = 0; col < arr.GetLength(0); col++)
                {
                    if (arr[row, col] == 0)
                    {
                        x = row;
                        y = col;
                        return;
                    }
                }
            }
        }
    }
}