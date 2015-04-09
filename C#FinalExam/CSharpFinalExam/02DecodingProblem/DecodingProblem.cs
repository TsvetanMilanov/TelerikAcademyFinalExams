using System;

class DecodingProblem
{
    static void Main(string[] args)
    {
        int salt = int.Parse(Console.ReadLine());
        string encodedText = Console.ReadLine();

        int currentPosition = 0;

        decimal characterCode = 0m;

        while (encodedText[currentPosition] != '@')
        {
            bool isLetter = ((int)encodedText[currentPosition] >= 65 && (int)encodedText[currentPosition] <= 90) || ((int)encodedText[currentPosition] >= 97 && (int)encodedText[currentPosition] <= 122);
            bool isNumber = ((int)encodedText[currentPosition] >= 48 && (int)encodedText[currentPosition] <= 57);

            if (isLetter)
            {
                characterCode = encodedText[currentPosition];
                characterCode *= salt;
                characterCode += 1000;
            }
            else if (isNumber)
            {
                characterCode = encodedText[currentPosition];
                characterCode += salt;
                characterCode += 500;
            }
            else
            {
                characterCode = encodedText[currentPosition];
                characterCode -= salt;
            }

            if (currentPosition % 2 == 0)
            {
                characterCode /= 100;
            }
            else
            {
                characterCode *= 100;
            }

            if (characterCode >= 0 && characterCode <= 99.99m)
            {
                Console.WriteLine("{0:F2}", characterCode);
            }
            else if (characterCode >= 100 && characterCode <= 999.99m)
            {
                Console.WriteLine("{0:F1}", characterCode);
            }
            else if (characterCode >= 1000)
            {
                Console.WriteLine("{0}", (int)characterCode);
            }


            currentPosition++;
        }

    }
}