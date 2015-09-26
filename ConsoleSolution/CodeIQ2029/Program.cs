using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace CodeIQ2029
{
    class Program
    {
        enum ChkMode
        {
            Even,
            Odd
        }

        static void Main(string[] args)
        {
            var input = GetInputAsList().ConvertAll(x => ulong.Parse(x));

            Stopwatch sw = new Stopwatch();
            sw.Start();
            foreach (var item in input)
            {
                Console.WriteLine(Fn(item));
                Debug.WriteLine(sw.Elapsed);
            }
            Console.ReadKey();
        }

        /// <summary>
        /// 連続した自然数の最初の値をx、個数をnとすると
        /// nx①+n(n-1)/2②がvalueと等しくなる。
        /// →n(2x+n-1)=2*valueであるnとxの組を求める。
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        static public ulong Fn(ulong value)
        {
            ulong ret = 0;

            ulong n_max = (ulong)Math.Sqrt(value * 2); //連続する数字の最大値はvalue*2の平方根未満

            var n_kouho = Fn_yaku(value*2, n_max);
            
            Console.Write("n > ");
            string str = "";
            foreach (var item in n_kouho)
            {
                str += item + ", ";
            }
            Console.WriteLine(str.TrimEnd(',',' '));

            foreach (var n in n_kouho)
            {
                if (value % 2 == 0) //valueが偶数の時、nと(2x+n-1)は偶奇or奇偶
                {
                    if(n%2 == 0) //nが偶数なら(2x+n-1)は奇数
                    {
                        ulong tmp = isRet(value, n, ChkMode.Odd);
                        if(tmp != 0)
                        {
                            Console.WriteLine("value={0}, n={1}, x={2}", value, n, tmp);
                            ret += tmp;
                        }
                    }
                    else
                    {
                        ulong tmp = isRet(value, n, ChkMode.Even);
                        if (tmp != 0)
                        {
                            Console.WriteLine("value={0}, n={1}, x={2}", value, n, tmp);
                            ret += tmp;
                        }
                    }
                }
                else //valueが奇数の時、nと(2x+n-1)は偶偶or奇奇
                {
                    if (n % 2 == 0) //nが偶数なら(2x+n-1)は偶数
                    {
                        ulong tmp = isRet(value, n, ChkMode.Even);
                        if (tmp != 0)
                        {
                            Console.WriteLine("value={0}, n={1}, x={2}", value, n, tmp);
                            ret += tmp;
                        }
                    }
                    else
                    {
                        ulong tmp = isRet(value, n, ChkMode.Odd);
                        if (tmp != 0)
                        {
                            Console.WriteLine("value={0}, n={1}, x={2}", value, n, tmp);
                            ret += tmp;
                        }
                    }
                }
            }

            return ret;
        }

        static ulong isRet(ulong v, ulong n, ChkMode m)
        {
            double tmp = v / n - (n - 1) / 2.0;

            if(tmp.ToString().Contains(".5"))
            {
                if (m == ChkMode.Even) return 0;
                else return (ulong)(tmp+0.5);
            }
            else
            {
                if (m == ChkMode.Even) return (ulong)tmp;
                else return 0;
            }
        }

        //nの候補集合
        static public List<ulong> Fn_yaku(ulong value, ulong upper)
        {
            var ret = new List<ulong>();

            for(ulong i = 2; i< upper;i++)
            {
                if (value % i == 0) ret.Add(i);
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
