using System;
using System.Collections.Generic;

namespace piasza91
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = GetInputAsList().ToArray();
            string output = ExecMini(input);
            Console.WriteLine(output);
        }

        static public string ExecMini(string[] input)
        {
            int[] variable = { 0, 0 };

            for (int i=1; i<=int.Parse(input[0]); i++)
            {
                var command = input[i].Split(' ');
                switch(command[0])
                {
                    case "SET": variable[int.Parse(command[1])-1] = int.Parse(command[2]); break;
                    case "ADD": variable[1] = variable[0] + int.Parse(command[1]); break;
                    case "SUB": variable[1] = variable[0] - int.Parse(command[1]); break;
                    default: break;
                }
            }

            return String.Format("{0} {1}", variable[0], variable[1]);
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
