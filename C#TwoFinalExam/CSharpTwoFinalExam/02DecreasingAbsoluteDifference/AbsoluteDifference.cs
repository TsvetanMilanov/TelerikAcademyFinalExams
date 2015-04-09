using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02DecreasingAbsoluteDifference
{
    class AbsoluteDifference
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());

            long[][] sequence = new long[t][];
            long[][] differences = new long[t][];

            for (int i = 0; i < t; i++)
            {
                sequence[i] = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            }

            differences = MakeDifferences(sequence);

            foreach (var difference in differences)
            {
                CheckSequence(difference);
            }
        }

        private static long[][] MakeDifferences(long[][] sequence)
        {
            long[][] result = new long[sequence.GetLength(0)][];

            long firstNumber = 0;
            long secondNumber = 0;
            long difference = 0;

            for (int i = 0; i < sequence.GetLength(0); i++)
            {
                result[i] = new long[sequence[i].GetLength(0) - 1];
                for (int j = 0; j < sequence[i].GetLength(0); j++)
                {

                    difference = 0;
                    if (j < sequence[i].GetLength(0) - 1)
                    {
                        firstNumber = Math.Max(sequence[i][j], sequence[i][j + 1]);
                        secondNumber = Math.Min(sequence[i][j], sequence[i][j + 1]);

                        difference = firstNumber - secondNumber;

                        result[i][j] = difference;
                    }
                }
            }

            return result;
        }

        private static void CheckSequence(long[] sequence)
        {
            long firstNumber = 0;
            long secondNumber = 0;
            long difference = 0;

            for (int i = 0; i < sequence.Length; i++)
            {
                difference = 0;

                if (i < sequence.Length - 1)
                {
                    firstNumber = sequence[i];
                    secondNumber = sequence[i + 1];
                    difference = firstNumber - secondNumber;

                    if (difference < 0 || difference >= 2)
                    {
                        Console.WriteLine("False");
                        return;
                    }
                }
            }

            Console.WriteLine("True");
        }
    }
}
