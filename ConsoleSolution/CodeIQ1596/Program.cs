using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace CodeIQ1596
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = GetInputAsList().ConvertAll(x => int.Parse(x));

            Stopwatch sw = new Stopwatch();
            sw.Start();
            foreach (var item in input)
            {
                //Console.WriteLine(Fn(item));
                foreach(var item2 in Fn(item))
                {
                    Console.WriteLine(item2);
                }

                Debug.WriteLine(sw.Elapsed);
            }
            
            Console.ReadKey();
        }

        //1<=n<=mなnについて、1を含めた約数が4つ以上ある数を数える
        static public List<int> Fn(int m)
        {
            return Enumerable.Range(1, m).Select(delegate (int x)
            {
                int ret = 0;
                for (int i = 2; i < x ; i ++)
                {
                    if (x % i == 0)
                    {
                        ret++;
                        //Console.WriteLine(x + " >>> " + i);
                    }
                    if (ret >= 3) break;
                }
                //Console.WriteLine(x + " > " + ret);
                return (ret >= 3) ? x : 0;
            }).Where(x => (x != 0)).ToList(); ;
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
