using System;
using System.Collections.Generic;
using System.Diagnostics;
using ConsoleSolution;



namespace CodeIQ1632
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = InputValues.getInput();

            foreach (var item in input)
            {
                Debug.WriteLine(item);
                Stopwatch sw = new Stopwatch();
                sw.Start();
                Console.WriteLine(retNum(uint.Parse(item)));
                Debug.Write("time: "); Debug.WriteLine(sw.Elapsed);
                sw.Stop();
                sw.Reset();
            }

            Console.ReadKey();
        }

        static public uint retNum(uint num)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            if (num <= 5) return (num + 4);
            uint temp = 5;

            //何桁の数字か判定(len)
            uint len = 2;
            while (temp < num)
            {
                uint t = 18 * (uint)Math.Pow(10, len - 1);
                if (temp + t >= num) { num -= temp; break; }
                temp += t;
            }
            Debug.Write(": "); Debug.WriteLine(sw.Elapsed);


            //len桁の何番目か
            string str = ((uint)Math.Pow(10, len - 1) + (((num - 1) / len))).ToString();

            //len桁の何文字目か
            int posi = (int)((num - 1) % len);
            sw.Stop();
            //len桁の数値strのposi桁目
            return uint.Parse(String.Format("{0}", str[posi]));
        }
    }

    public class InputValues
    {
        public static List<string> getInput()
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