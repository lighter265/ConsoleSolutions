using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSolution
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Wideuse.GetInputByList();

            if(input.Count() < 2)
            {
                Console.WriteLine("0");
                return;
            }

            var list = input.ConvertAll(x => int.Parse(x));

            int upper = list.Count();
            int lower = 0;

            bool flag = true;
            while(flag)
            {
                flag = false;
                var temp = list.GetRange(lower, upper-lower);
                if (temp.Max() == list[upper-1]) { upper--; flag = true; }
                if (temp.Min() == list[lower])   { lower++; flag = true; }
                if (lower == upper) break;
            }

            if(lower == upper) Console.WriteLine("0");
            else Console.WriteLine("{0}..{1}",lower+1,upper);
        }

    }
}

