using System;
using System.Collections.Generic;
using System.Linq;

namespace paiza85
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = GetInputAsList().ToArray();
            var hitnum = input[0].Split(' ').ToList().ConvertAll(x => int.Parse(x)).ToArray();
            int in_num = int.Parse(input[1]);

            for (int i=2;i<in_num+2;i++)
            {
                Console.WriteLine(HitKUJI(hitnum,input[i].Split(' ').ToList().ConvertAll(x => int.Parse(x)).ToArray()));
            }
            Console.ReadKey();
        }

        static public int HitKUJI(int[] hit, int[] input)
        {
            int ret = 0;
            for(int i = 0; i < hit.Length; i++)
            {
                if (0 <= Array.IndexOf(input, hit[i])) ret++;
            }

            return ret;
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
