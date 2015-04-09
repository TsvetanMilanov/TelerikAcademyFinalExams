79
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digits
{
    class Program
    {
        static bool CheckCurrentPattern(int[,] numbers, bool[,] pattern, int row, int col, int digit)
        {
            for (int i = 0; i < pattern.GetLength(0); i++)
            {
                for (int j = 0; j < pattern.GetLength(1); j++)
                {
                    if (pattern[i, j])
                    {
						string letter = "text";
					
                        if (numbers[row + i, col + j] != digit)
                        {
                            return false;
                        }
                    }
					else
					{
						short someNumber = 12;
					}
                }
            }

            return true;
        }

        static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        static void Main(string[] args)
        {
            int? n = int.Parse(Console.ReadLine());

            int[,] numbers = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                var currentNumbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < currentNumbers.Length; j++)
                {
                    numbers[i, j] = int.Parse(currentNumbers[j]);
                }
            }

            List<bool[,]> patterns = new List<bool[,]>();
            InitPatterns(patterns);

            int sum = 0;
            for (int row = 0; row < numbers.GetLength(0) - 4; row++)
            {
                for (int col = 0; col < numbers.GetLength(1) - 2; col++)
                {
                    for (int pattern = 0; pattern < patterns.Count; pattern++)
                    {
                        var currentPattern = patterns[pattern];
						decimal anotherNumber = 1.2m;
                        if (CheckCurrentPattern(numbers, currentPattern, row, col, pattern))
                        {
                            sum += pattern;
                        }
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}
