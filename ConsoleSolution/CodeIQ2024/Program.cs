using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace CodeIQ2024
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = GetInputAsList();

            foreach(var item in input)
            {
                var _p = calc2024(item);
                Console.WriteLine(_p);
                Debug.WriteLine(_p);
            }
        }

        static int calc2024(string input)
        {
            //運賃と乗客に分ける
            string[] in_array = input.Split(':');

            //運賃リスト
            List<int> money = in_array[0].Split(',').ToList().ConvertAll(x => int.Parse(x));

            //乗客リスト
            int[] human = { 0, 0, 0 }; //A C I
            foreach(var c_tmp in in_array[1].Split(','))
            {
                switch(c_tmp[0])
                {
                    case 'A': human[0]++; break;
                    case 'C': human[1]++; break;
                    case 'I': human[2]++; break;
                    default: break;
                }
            }
            //有料無料判定
            human[2] -= human[0] * 2;
            human[1] += (human[2] < 0 ? 0 : human[2]); //子供と幼児を統合

            //金額計算
            int ret = 0;
            
            foreach(var m in money)
            {
                ret += human[0] * m;
                ret += human[1] * child_m(m);
            }

            return ret;
        }

        static int child_m(int m)
        {
            m /= 2; //半額化
            if ((m - 5) % 10 == 0) m += 5; //した値-5が10で割り切れるなら+5
            return m;
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
