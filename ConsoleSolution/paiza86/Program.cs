using System;
using System.Collections.Generic;

namespace paiza86
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = GetInputAsList().ToArray();
            int square = int.Parse(input[0]) * int.Parse(input[0]);
            int ans = square * 6;
            Console.WriteLine("{0}", ans);
        }

        public static List<string> GetInputAsList()
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
    }
}
