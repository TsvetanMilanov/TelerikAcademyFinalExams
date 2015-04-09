using Cosmetics.Engine;
using System;
using System.IO;
namespace Cosmetics
{
    public class CosmeticsProgram
    {
        public static void Main()
        {
            using (var sw = new StreamWriter("../../output.txt"))
            {
                Console.SetOut(sw);
                CosmeticsEngine.Instance.Start();
            }
        }
    }
}
