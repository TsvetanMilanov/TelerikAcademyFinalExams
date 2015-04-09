using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04CatAclysm
{
    class CatAclysm
    {
        static List<string> loops = new List<string>();
        static List<string> methods = new List<string>();
        static List<string> ifs = new List<string>();

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] program = new string[n];

            string[] separators = { "int", "float", "double", "short", " bool", " char", "long", "BigInteger", "byte", "sbyte", "ulong", "ushort", "uint", "ufloat", "udouble" };

            for (int i = 0; i < n; i++)
            {
                program[i] = Console.ReadLine();
            }

            string joinedProgram = string.Join("", program);



            for (int i = 0; i < joinedProgram.Length; i++)
            {
                char currentChar = joinedProgram[i];

                CheckChar(joinedProgram, currentChar, i);
            }

            Console.WriteLine(string.Join("\n", methods));
        }

        private static void CheckChar(string joinedProgram, char currentChar, int index)
        {
            int tabsCount = 0;
            int tabIndex = 0;

            switch (currentChar)
            {
                case 's':
                    if (joinedProgram[index + 1] == 't' && joinedProgram[index + 2] == 'a' && joinedProgram[index + 3] == 't' && joinedProgram[index + 4] == 'i' && joinedProgram[index + 5] == 'c')
                    {
                        tabIndex = index;
                        tabsCount = 0;
                        while (joinedProgram[tabIndex] != '{')
                        {
                            if (joinedProgram[tabIndex] == ' ')
                            {
                                tabsCount++;
                            }
                            tabIndex++;
                        }
                        StringBuilder result = new StringBuilder();

                        string endBracket = string.Empty;
                        while (joinedProgram[index] != '\n' && (endBracket = joinedProgram.Substring(index + 1, tabsCount + 1)) == (new string('\t', tabsCount) + '{'))
                        {
                            result.Append(joinedProgram[index]);
                            index++;
                        }
                        methods.Add(result.ToString());
                    }
                    break;
            }
        }
    }
}
