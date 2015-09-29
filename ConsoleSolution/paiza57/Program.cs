using System;
using System.Collections.Generic;
using System.Linq;

//失敗
namespace paiza57
{
    using CustomExtensions;

    class SevenSegDisp
    {
        static string[] num =  { "1111110", //0
                          "0110000",
                          "1101101",
                          "1111001",
                          "0110011",
                          "1011011",
                          "1011111",
                          "1110010",
                          "1111111",
                          "1111011" //9
                         };

        public enum Cond { Nomaly, Symmetric, Pivot, False };

        //判断メソッド。
        //もっと簡略化できそうではあるが、時間的に面倒。
        static public Cond GetStringCond(string sa, string sb)
        {
            int[] ret = { -1, -1 };

            //正常系
            for (int i = 0; i < num.Length; i++)
            {
                if (sa.Equals(num[i]))
                {
                    ret[0] = i;
                    for (int j = 0; j < num.Length; j++)
                    {
                        if (sb.Equals(num[j]))
                        {
                            ret[1] = j;
                        }
                    }
                }
            }
            if (Array.IndexOf(ret, -1) == -1)
            {
                return Cond.Nomaly;
            }

            //対称系(後ろから
            ret = new int[] { -1, -1 };
            for (int i = 0; i < num.Length; i++)
            {
                if (Symmetrification(sa).Equals(num[i]))
                {
                    ret[1] = i;
                    for (int j = 0; j < num.Length; j++)
                    {
                        if (Symmetrification(sb).Equals(num[j]))
                        {
                            ret[0] = j;
                        }
                    }
                }
            }
            if (Array.IndexOf(ret, -1) == -1)
            {
                return Cond.Symmetric;
            }

            //回転系(後ろから
            ret = new int[] { -1, -1 };
            for (int i = 0; i < num.Length; i++)
            {
                if (Pivotiification(sa).Equals(num[i]))
                {
                    ret[1] = i;
                    for (int j = 0; j < num.Length; j++)
                    {
                        if (Pivotiification(sb).Equals(num[j]))
                        {
                            ret[0] = j;
                        }
                    }
                }
            }
            if (Array.IndexOf(ret, -1) == -1)
            {
                return Cond.Pivot;
            }

            return Cond.False;
        }

        //対称形　反対(aを渡すとbを)返す
        static public string Symmetrification(string s)
        {
            char[] ret = new char[] { s[0], s[5], s[4], s[3], s[2], s[1], s[6] };
            return new string(ret);
        }

        //回転系　反対(aを渡すとbを)返す
        static public string Pivotiification(string s)
        {
            char[] ret = new char[] { s[3], s[4], s[5], s[0], s[1], s[2], s[6] };
            return new string(ret);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var input = LoadingExtension.GetInputAsList();
            string a = input[0].Replace(" ", "");
            string b = input[1].Replace(" ", "");

            string[] ret = { "No", "No", "No" };

            switch (SevenSegDisp.GetStringCond(a, b))
            {
                case SevenSegDisp.Cond.Nomaly: ret[0] = "Yes"; break;
                case SevenSegDisp.Cond.Symmetric: ret[1] = "Yes"; break;
                case SevenSegDisp.Cond.Pivot: ret[2] = "Yes"; break;
                case SevenSegDisp.Cond.False: break;
            }

            foreach (var item in ret)
            {
                Console.WriteLine(item);
            }
            //Console.ReadKey();
        }
    }
}

namespace CustomExtensions
{
    public static class StringExtension
    {
        //デリミタ分割後、int.ParseしたListを返す
        public static List<int> ConvertIntParse(this String str, char d)
        {
            return str.Split(d).ToList().ConvertAll(x => int.Parse(x));
        }
    }

    public static class LoadingExtension
    {
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