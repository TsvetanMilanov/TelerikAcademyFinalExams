using System;

class SearchInBits
{
    static void Main(string[] args)
    {
        long s = int.Parse(Console.ReadLine());
        long n = int.Parse(Console.ReadLine());
        int[] allNumbers = new int[n];
        string[] binaryNumbers = new string[n];
        long k = 0;
        long sum = 0;
        long mask = s & 15;
        int counter = 0;

        string currentNumber;
        string currentCombination = "";


        string maskString = Convert.ToString(mask, 2).PadLeft(4, '0');

        do
        {
            allNumbers[k] = int.Parse(Console.ReadLine());
            k++;
            n--;
        } while (n != 0);

        for (int i = 0; i < allNumbers.Length; i++)
        {
            binaryNumbers[i] = Convert.ToString(allNumbers[i], 2).PadLeft(30, '0');
        }

        for (int i = 0; i < binaryNumbers.Length; i++)
        {
            currentNumber = binaryNumbers[i];


            for (int j = currentNumber.Length - 1; j >= 3; j--)
            {

                currentCombination += currentNumber[j - 3];
                currentCombination += currentNumber[j - 2];
                currentCombination += currentNumber[j - 1];
                currentCombination += currentNumber[j];

                if (currentCombination.Equals(maskString))
                {
                    sum++;
                }

                currentCombination = "";
            }
        }
        //for (int i = 0; i < allNumbers.Length; i++)
        //{
        //    currentNumber = allNumbers[i];

        //    do
        //    {
        //        result = currentNumber & mask;
        //        if (mask == result)
        //        {
        //            sum++;
        //        }
        //        currentNumber >>= 1;
        //        counter++;
        //    } while (currentNumber != 0 || (counter == 30));
        //}
        Console.WriteLine(sum);
    }
}
