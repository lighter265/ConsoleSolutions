using System;
using System.Collections.Generic;

namespace piaza92
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = GetInputAsList();
            foreach(var item in input)
            {
                Console.WriteLine(String.Format("{0:D3}", int.Parse(item)));
            }
            Console.ReadKey();
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
