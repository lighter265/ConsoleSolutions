using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSolution
{
    class Wideuse
    {
        public static string[] getStrings(char d)
        {
            return Console.ReadLine().Split(d);
        }

        public static List<string> GetInputByList()
        {
            var input = new List<string>();
            string line;
            do
            {
                line = Console.ReadLine();
                if (line == null || line == "") break;
                input.Add(line);
            } while (true);

            return input;
        }

        public static string[] GetInputByArray()
        {
            var input = new List<string>();
            string line;
            do
            {
                line = Console.ReadLine();
                if (line == null || line == "") break;
                input.Add(line);
            } while (true);

            return input.ToArray<string>();
        }
    }
}
