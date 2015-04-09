using System;

class PersianRugsProblem
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int d = int.Parse(Console.ReadLine());

        int height = (2 * n) + 1;
        int width = (2 * n) + 1;

        if (d > ((width - 4) / 2))
        {

            int middleSpaces = width - 2;
            int bottomDiEs = width / 2 - 1;

            for (int i = 0; i < n; i++)
            {
                Console.Write(new string('#', i));
                Console.Write("\\");
                Console.Write(new string(' ', middleSpaces));
                Console.Write("/");
                Console.Write(new string('#', i));


                Console.WriteLine();


                if (middleSpaces <= 1)
                {
                    continue;
                }
                middleSpaces = middleSpaces - 2;
            }

            Console.Write(new string('#', n));
            Console.Write("X");
            Console.Write(new string('#', n));

            Console.WriteLine();

            for (int i = 0; i < n; i++)
            {
                Console.Write(new string('#', bottomDiEs));
                Console.Write("/");
                Console.Write(new string(' ', middleSpaces));
                Console.Write("\\");
                Console.Write(new string('#', bottomDiEs));


                Console.WriteLine();

                bottomDiEs--;

                middleSpaces = middleSpaces + 2;
            }
        }
        else
        {

            int middleSpaces = 0;
            int bottomDiEs = width / 2 - 1;
            int counterSpaces = width - 2;

            int smallDots = width - 4 - 2 * d;
            int smallDash = 1;
            int spacesD = d;
            int flag = 0;

            for (int i = 0; i < n; i++)
            {
                if (smallDots < 0)
                {
                    smallDots = 1;
                }
                if (flag == 1)
                {
                    if (middleSpaces > 0)
                    {

                        middleSpaces -= 2;
                    }
                }
                Console.Write(new string('#', i));
                Console.Write("\\");
                Console.Write(new string(' ', middleSpaces + d));

                if (smallDash == 0)
                {
                    Console.Write(new string(' ', 1));
                }
                Console.Write(new string('\\', smallDash));
                Console.Write(new string('.', smallDots));
                Console.Write(new string('/', smallDash));
                Console.Write(new string(' ', middleSpaces + d));
                Console.Write("/");
                Console.Write(new string('#', i));


                Console.WriteLine();
                if (smallDots >= 1)
                {
                    smallDots -= 2;
                }

                if (smallDots <= 0)
                {
                    smallDash = 0;
                    smallDots = 0;
                    if (flag == 1)
                    {
                        continue;
                    }
                    middleSpaces = d;
                    flag = 1;
                }

                //if (middleSpaces <= 0)
                //{
                //    continue;
                //}
                //middleSpaces -= 2;
            }

            Console.Write(new string('#', n));
            Console.Write("X");
            Console.Write(new string('#', n));

            Console.WriteLine();

            for (int i = 0; i < n; i++)
            {
                Console.Write(new string('#', bottomDiEs));
                Console.Write("/");
                Console.Write(new string(' ', middleSpaces));
                Console.Write("\\");
                Console.Write(new string('#', bottomDiEs));


                Console.WriteLine();

                bottomDiEs--;

                middleSpaces = middleSpaces + 2;
            }
        }
    }
}
