using System;
using System.Collections.Generic;
using System.Linq;

namespace paiza60
{
    using CustomExtensions;
    public class CardSet
    {
        int a { get; set; }
        int b { get; set; }

        public CardSet(int A, int B)
        {
            a = A;
            b = B;
        }
        public CardSet()
        {
            a = 0;
            b = 0;
        }

        public bool Judge(CardSet tmp)
        {
            if (a > tmp.a) return true;
            else if (a < tmp.a) return false;
            else if (b < tmp.b) return true;
            else return false;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var input = GetInputAsList();
            var _p = input[0].ConvertIntParse(' ');
            CardSet parent = new CardSet(_p[0], _p[1]);

            int n = int.Parse(input[1]);

            for (int i = 2; i < n + 2; i++)
            {
                var tmp = input[i].ConvertIntParse(' ');

                string j;
                if (parent.Judge(new CardSet(tmp[0], tmp[1]))) j = "High";
                else j = "Low";

                Console.WriteLine(j);
            }
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

namespace CustomExtensions
{
    public static class StringExtension
    {
        public static int[] ConvertIntParse(this String str, char d)
        {
            return str.Split(d).ToList().ConvertAll(x => int.Parse(x)).ToArray();
        }
    }
}