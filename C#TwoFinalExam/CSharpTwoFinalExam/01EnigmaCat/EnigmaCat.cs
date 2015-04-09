using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _01EnigmaCat
{
    class EnigmaCat
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] inputNumbers = input.Split(' ');

            string[] allNumbersInDecimal = new string[inputNumbers.GetLength(0)];

            string allLetters = "abcdefghijklmnopqrstuvwxyz";

            for (int i = 0; i < inputNumbers.GetLength(0); i++)
            {
                allNumbersInDecimal[i] = ConvertToDecimal(inputNumbers, i, allLetters);
            }

            Console.WriteLine(string.Join(" ", allNumbersInDecimal));
        }

        public static string ConvertToDecimal(string[] inputNumbers, int index, string allLetters)
        {
            StringBuilder result = new StringBuilder();
            BigInteger number = 0;
            int pow = inputNumbers[index].Length - 1;

            for (int i = 0; i < inputNumbers[index].Length; i++)
            {
                string currentWord = inputNumbers[index].ToLower();

                number = number + ((BigInteger)(currentWord[i] - 'a') * (BigInteger)Math.Pow(17, pow));

                pow--;
            }

            while (number > 0)
            {
                result.Insert(0, allLetters[(int)number % 26]);
                number /= 26;
            }

            return result.ToString();
        }
    }
}
