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

        /// <summary>
        /// 基数ソート。
        /// </summary>
        /// <param name="a">対象の配列</param>
        /// <param name="max">配列 a 中の最大値</param>
        public static void RadixSort(int[] a)
        {
            // バケツを用意
            List<int>[] bucket = new List<int>[256];

            for (int d = 0, logR = 0; d < 4; ++d, logR += 8)
            {
                // バケツに値を入れる
                for (int i = 0; i < a.Length; ++i)
                {
                    int key = (a[i] >> logR) & 255; // a[i] を256進 d 桁目だけを取り出す。
                    if (bucket[key] == null) bucket[key] = new List<int>();
                    bucket[key].Add(a[i]);
                }

                // バケツ中の値の結合
                for (int j = 0, i = 0; j < bucket.Length; ++j)
                    if (bucket[j] != null)
                        foreach (int val in bucket[j])
                            a[i++] = val;

                // バケツを一度空にする
                for (int j = 0; j < bucket.Length; ++j)
                    bucket[j] = null;
            }
        }
    }

}

