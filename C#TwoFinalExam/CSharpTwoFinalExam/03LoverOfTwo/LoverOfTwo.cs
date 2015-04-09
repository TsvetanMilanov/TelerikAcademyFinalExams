using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _03LoverOfTwo
{
    class LoverOfTwo
    {
        static void Main(string[] args)
        {
            int r = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int n = int.Parse(Console.ReadLine());

            int coef = Math.Max(r, c);

            int[] directionsAndMoves = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            BigInteger[,] matrix = new BigInteger[r, c];

            bool[,] visitedCells = new bool[r, c];

            matrix = MakeMatrix(matrix, r, c);

            int[][] cells = FindCellsCoordinates(directionsAndMoves, coef);

            BigInteger sum = FindSum(matrix, visitedCells, c, r, cells);
            Console.WriteLine(sum);
        }

        private static BigInteger FindSum(BigInteger[,] matrix, bool[,] visitedCells, int c, int r, int[][] cells)
        {
            BigInteger sum = 0;

            int[] currentPosition = { r - 1, 0 };

            for (int i = 0; i < cells.GetLength(0); i++)
            {
                int[] targetCell = cells[i];

                int[] direction = { targetCell[0] - currentPosition[0], targetCell[1] - currentPosition[1] };

                if (direction[0] < 0)
                {
                    int temp = direction[0];
                    //Move up.
                    while (temp != 1)
                    {
                        if (visitedCells[currentPosition[0], currentPosition[1]] == false)
                        {
                            sum += matrix[currentPosition[0], currentPosition[1]];
                            visitedCells[currentPosition[0], currentPosition[1]] = true;
                        }
                        temp++;
                        currentPosition[0] -= 1;
                    }
                    currentPosition[0] += 1;
                }
                if (direction[0] > 0)
                {
                    int temp = direction[0];
                    //Move down.
                    while (temp != -1)
                    {
                        if (visitedCells[currentPosition[0], currentPosition[1]] == false)
                        {
                            sum += matrix[currentPosition[0], currentPosition[1]];
                            visitedCells[currentPosition[0], currentPosition[1]] = true;
                        }
                        temp--;
                        currentPosition[0] += 1;
                    }
                    currentPosition[0] -= 1;
                }
                if (direction[1] < 0)
                {
                    //Move left.
                    int temp = direction[1];
                    while (temp != 1)
                    {
                        if (visitedCells[currentPosition[0], currentPosition[1]] == false)
                        {
                            sum += matrix[currentPosition[0], currentPosition[1]];
                            visitedCells[currentPosition[0], currentPosition[1]] = true;
                        }
                        temp++;
                        currentPosition[1] -= 1;
                    }
                    currentPosition[1] += 1;
                }
                if (direction[1] > 0)
                {
                    //Move right.
                    int temp = direction[1];
                    while (temp != -1)
                    {
                        if (visitedCells[currentPosition[0], currentPosition[1]] == false)
                        {
                            sum += matrix[currentPosition[0], currentPosition[1]];
                            visitedCells[currentPosition[0], currentPosition[1]] = true;
                        }
                        temp--;
                        currentPosition[1] += 1;
                    }
                    currentPosition[1] -= 1;
                }

                //if (visitedCells[currentPosition[0], currentPosition[1]] == false)
                //{
                //    sum += matrix[currentPosition[0], currentPosition[1]];
                //    visitedCells[currentPosition[0], currentPosition[1]] = true;
                //}
            }

            return sum;
        }

        private static int[][] FindCellsCoordinates(int[] directionsAndMoves, int coef)
        {
            int[][] result = new int[directionsAndMoves.GetLength(0)][];

            for (int i = 0; i < directionsAndMoves.GetLength(0); i++)
            {
                result[i] = new int[2];
                result[i][0] = directionsAndMoves[i] / coef;
                result[i][1] = directionsAndMoves[i] % coef;
            }

            return result;
        }

        private static BigInteger[,] MakeMatrix(BigInteger[,] matrix, int r, int c)
        {
            BigInteger[,] result = new BigInteger[r, c];

            int currentRowPower = 0;

            int currentPower = currentRowPower;
            BigInteger currentNumber = Power(2, currentRowPower);

            int leftIndex = 0;

            do
            {
                for (int i = r - 1; i >= 0; i--)
                {

                    result[i, leftIndex] = currentNumber;
                    currentPower++;
                    currentNumber = Power(2, currentPower);
                }
                leftIndex++;
                currentRowPower++;
                currentPower = currentRowPower;
                currentNumber = Power(2, currentPower);
            } while (leftIndex < c);

            return result;
        }

        private static BigInteger Power(int systemBase, int currentPow)
        {
            BigInteger result = 1;

            for (int i = 0; i < currentPow; i++)
            {
                result *= systemBase;
            }

            return result;
        }

        static void PrintMatrix(BigInteger[,] matrixA)
        {
            for (int i = 0; i < matrixA.GetLength(0); i++)
            {
                for (int j = 0; j < matrixA.GetLength(1); j++)
                {
                    Console.Write("{0,3} ", matrixA[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
