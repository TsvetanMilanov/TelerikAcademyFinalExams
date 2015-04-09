using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _011EnigmaSecondTry
{
    class EnigmaSecondTry
    {
        static string allLetters = "abcdefghijklmnopqrstuvwxyz";

        static void Main(string[] args)
        {
            string inputNumber = Console.ReadLine();

            string[] allNumbers = inputNumber.Split(' ');

            List<string> result = new List<string>();

            foreach (var number in allNumbers)
            {
                result.Add(ConvertNumber(number));
            }

            Console.WriteLine(string.Join(" ", result));
        }

        private static string ConvertNumber(string number)
        {
            StringBuilder result = new StringBuilder();

            int pow = number.Length - 1;

            BigInteger resultNumber = 0;

            foreach (var letter in number)
            {
                resultNumber = resultNumber + ((BigInteger)(letter - 'a') * Power(17, pow));
                pow--;
            }


            while (resultNumber > 0)
            {
                result.Insert(0, allLetters[(int)(resultNumber % 26)]);
                resultNumber /= 26;
            }
            return result.ToString();
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
    }
}
