using System;

class ThreenumbersProblem
{
    static void Main()
    {
        long a = long.Parse(Console.ReadLine());
        long b = long.Parse(Console.ReadLine());
        long c = long.Parse(Console.ReadLine());

        decimal arithmeticMean = 0m;

        arithmeticMean = (decimal)(a + b + c) / 3m;

        long biggestNumber = 0L;
        long smallestNumber = 0L;

        if (a >= b && a >= c)
        {
            biggestNumber = a;
        }
        if (b >= a && b >= c)
        {
            biggestNumber = b;
        }
        if (c >= b && c >= a)
        {
            biggestNumber = c;
        }

        if (a <= b && a <= c)
        {
            smallestNumber = a;
        }
        if (b <= a && b <= c)
        {
            smallestNumber = b;
        }
        if (c <= b && c <= a)
        {
            smallestNumber = c;
        }
        Console.WriteLine(biggestNumber);
        Console.WriteLine(smallestNumber);
        Console.WriteLine("{0:F2}", arithmeticMean);
    }
}