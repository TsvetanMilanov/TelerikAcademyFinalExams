using System;
using System.Numerics;

class ConsoleApplication1
{
    static void Main()
    {
        int n = 0;
        string[] numbersArray = new string[10100];

        do
        {
            numbersArray[n] = Console.ReadLine();
            n++;
        } while (numbersArray[n - 1] != "END");

        long[] numbers = new long[n - 1];

        for (int i = 0; i < n - 1; i++)
        {
            numbers[i] = Convert.ToInt64(numbersArray[i]);
        }

        int numbersCount = numbers.Length;

        BigInteger numberProduct = 1;
        BigInteger allNumbersProduct = 1;
        BigInteger currentNumber = 0;

        if (numbersCount <= 10)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i % 2 != 0)
                {
                    if (numbers[i] == 0)
                    {
                        numberProduct = 1L;
                    }
                    else
                    {
                        currentNumber = numbers[i];

                        while (currentNumber != 0)
                        {
                            if (currentNumber % 10 == 0)
                            {
                                currentNumber /= 10;
                                continue;
                            }
                            else
                            {
                                numberProduct *= (currentNumber % 10);
                            }
                            currentNumber /= 10;
                        }
                    }
                }
                allNumbersProduct *= numberProduct;
                numberProduct = 1L;
            }
            Console.WriteLine(allNumbersProduct);
        }

        if (numbersCount > 10)
        {
            for (int i = 0; i <= 9; i++)
            {
                if (i % 2 != 0)
                {
                    if (numbers[i] == 0)
                    {
                        numberProduct = 1L;
                    }
                    else
                    {
                        currentNumber = numbers[i];

                        while (currentNumber != 0)
                        {
                            if (currentNumber % 10 == 0)
                            {
                                currentNumber /= 10;
                                continue;
                            }
                            else
                            {
                                numberProduct *= (currentNumber % 10);
                            }
                            currentNumber /= 10;
                        }
                    }
                }
                allNumbersProduct *= numberProduct;
                numberProduct = 1L;
            }
            Console.WriteLine(allNumbersProduct);
            allNumbersProduct = 1;

            if (numbersCount - 10 <= 0)
            {
                for (int i = 10; i < numbers.Length; i++)
                {
                    if (numbers[i] == 0)
                    {
                        numberProduct = 1L;
                    }
                    else
                    {
                        currentNumber = numbers[i];

                        while (currentNumber != 0)
                        {
                            if (currentNumber % 10 == 0)
                            {
                                currentNumber /= 10;
                                continue;
                            }
                            else
                            {
                                numberProduct *= (currentNumber % 10);
                            }
                            currentNumber /= 10;
                        }
                    }

                    allNumbersProduct *= numberProduct;
                    numberProduct = 1L;

                }
            }
            else
            {
                for (int j = 10; j <= numbers.Length; j++)
                {
                    if (j % 2 != 0)
                    {
                        if (numbers[j] == 0)
                        {
                            numberProduct = 1L;
                        }
                        else
                        {
                            currentNumber = numbers[j];

                            while (currentNumber != 0)
                            {
                                if (currentNumber % 10 == 0)
                                {
                                    currentNumber /= 10;
                                    continue;
                                }
                                else
                                {
                                    numberProduct *= (currentNumber % 10);
                                }
                                currentNumber /= 10;
                            }
                        }
                    }
                    allNumbersProduct *= numberProduct;
                    numberProduct = 1L;
                }
            }
            Console.WriteLine(allNumbersProduct);
        }
    }
}
