using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05Cats
{
    class Cats
    {
        static void Main(string[] args)
        {
            string[] cats = Console.ReadLine().Split(' ').ToArray();
            int numberOfCats = int.Parse(cats[0]);

            string[] songs = Console.ReadLine().Split(' ').ToArray();
            int numberOfSongs = int.Parse(songs[0]);

            int[,] dinamycTable = new int[numberOfSongs, numberOfCats];

            #region input
            string command = string.Empty;
            List<string> allCommands = new List<string>();

            while (true)
            {
                command = Console.ReadLine();
                if (command != "Mew!")
                {
                    allCommands.Add(command);
                }
                else
                {
                    break;
                }
            }
            //allCommands.TrimExcess();
            #endregion

            foreach (var currentCommand in allCommands)
            {
                string[] result = currentCommand.Split(' ');
                int cat = int.Parse(result[1]) - 1;
                int song = int.Parse(result[result.GetLength(0) - 1]) - 1;

                dinamycTable[song, cat] = 1;
            }

            bool[] catsSangSong = new bool[numberOfCats];

            for (int i = 0; i < numberOfCats; i++)
            {
                catsSangSong[i] = false;
            }

            int counter = 1;
            bool flag = true;//flag to skip the songs that are not needed to count.

            for (int i = 0; i < numberOfSongs; i++)
            {
                for (int j = 0; j < numberOfCats; j++)
                {
                    if (dinamycTable[i, j] == 1)
                    {
                        if (catsSangSong[j] == false)
                        {
                            catsSangSong[j] = true;
                            flag = true;
                        }

                    }
                    else
                    {
                        flag = false;
                    }
                }
                if (catsSangSong.Contains(false) && flag)
                {
                    counter++;
                }
                else
                {
                    Console.WriteLine(counter);
                    return;
                }
            }

            if (catsSangSong.Contains(false))
            {
                Console.WriteLine("No concert!");
            }
            else
            {
                Console.WriteLine(counter);
            }
        }
    }
}
