using System;
using System.Collections.Generic;
using System.Linq;

namespace paiza94
{
    class Program
    {
        public static void Main()
        {
            var input = GetInputAsList();
            Console.WriteLine(input.Where(x => (x == "no")).Count());
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
