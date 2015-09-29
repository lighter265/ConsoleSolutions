using System;
using System.Collections.Generic;
using System.Linq;

namespace paiza69
{
    using CustomExtensions;
    
    class Program
    {
        static int N;
        static int K;
         
        static void Main(string[] args)
        {
            var input = LoadingExtension.GetInputAsList();
            var tmp = input[0].ConvertIntParse(' ');
            N = tmp[0];
            K = tmp[1];

            //変換元マップ
            List<int>[] MAP_in = new List<int>[N];
            for(int i=0;i< N; i++)
            {
                MAP_in[i] = new List<int>();
            }

            for(int i=1;i<N+1;i++)
            {
                var temp = input[i].ConvertIntParse(' ');
                MAP_in[i-1].AddRange(temp);
            }

            //変換先マップ
            List<int>[] MAPout = new List<int>[N/K];
            for (int i = 0; i < N/K; i++)
            {
                MAPout[i] = new List<int>();
            }
            for (int ky = 0; ky < N/K; ky ++)
            {
                for (int kx = 0; kx < N/K; kx ++)
                {
                    int ret = 0;
                    for(int k=0;k< K; k++)
                    {
                        ret += MAP_in[ky*K + k].GetRange(kx*K, K).Sum();
                    }
                    MAPout[ky].Add((int)(ret / (K*K)));
                }
            }

            //Print
            for(int ky=0;ky< N/K; ky++)
            {
                Console.WriteLine(string.Join(" ",MAPout[ky]));
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