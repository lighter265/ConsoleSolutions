using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace CodeIQ1597
{
    static class Program
    {
        static void Main(string[] args)
        {
            var input = new List<string>();
            string line;
            do
            {
                line = Console.ReadLine();
                if (line == null || line == "") break;
                input.Add(line);
            } while (true);

            var answer = Enumerable.Range(1, input[0].Split(',').Length+1).ToList();

            input.Reverse();
            foreach(var item in input)
            {
                var list = item.Split(',').ToList();
                var left = list.IndexOf("1");
                answer.Swap(left, left + 1);
            }

            string A = "";
            foreach(var item in answer)
            {
                A = A + item.ToString() + ",";
            }
            A = A.Trim(',');
            Console.WriteLine(A);
        }

        public static IList<T> Swap<T>(this IList<T> list, int A, int B)
        {
            T temp = list[A];
            list[A] = list[B];
            list[B] = temp;
            return list;
        }
    }
}
