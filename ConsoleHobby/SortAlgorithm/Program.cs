using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SortAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 500;
            int[] list = new int[size];
            Random r = new Random(DateTime.Now.Millisecond);
            for(int i = 0; i < size; i++)
            {
                list[i] = (r.Next() % (size*2));
            }

            foreach(var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("");

            Stopwatch sw = new Stopwatch();
            sw.Start();

            var asced = Sort.Bucket(list, Sort.OrderType.Asc);
            Console.WriteLine("Asced.");
            foreach (var item in asced)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("");

            Console.WriteLine(sw.Elapsed);

            var desced = Sort.Bucket(list, Sort.OrderType.Desc);
            Console.WriteLine("Desced.");
            foreach (var item in desced)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("");

            Console.WriteLine(sw.Elapsed);

            sw.Stop();

            Console.ReadKey();
        }
    }

    public class Sort
    {
        public  enum OrderType { Asc, Desc };

        /// <summary>
        /// バブルソート
        /// </summary>
        /// <typeparam name="Type"></typeparam>
        /// <param name="list"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Type[] Bubble<Type>(Type[] list, OrderType type)
            where Type : IComparable
        {
            //int sposi = 0;
            bool contflag = true;

            while(contflag)
            {
                contflag = false;
                for (int i = 0; i < list.Length - 1; i++)
                {
                    //i番目とi+1番目を比較し、入れ替えの必要があれば入れ替える
                    if(Compare(list[i], list[i+1], type))
                    {
                        Swap(ref list[i], ref list[i + 1]);
                        contflag = true;
                    }
                }
            }

            return list;
        }


        /// <summary>
        /// 選択ソート
        /// </summary>
        /// <typeparam name="Type"></typeparam>
        /// <param name="list"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Type[] Selection<Type>(Type[] list, OrderType type)
            where Type : IComparable
        {
            for(int i = 0; i < list.Length-1; i++)
            {
                int tposi = i;
                for(int j=i+1;j<list.Length;j++)
                {
                    int judge = list[i].CompareTo(list[j]);
                    judge *= (type == OrderType.Asc) ? 1 : -1;
                    if (judge > 0) tposi = j;
                }
                if (i != tposi) Swap(ref list[i], ref list[tposi]);
            }

            return list;
        }

        /// <summary>
        /// バケットソート
        /// </summary>
        /// <param name="list"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static int[] Bucket(int[] list, OrderType  type)
        {
            int max = list.Max()+1;
            int[] tmp = new int[max];

            //tmp配列を０で初期化
            for (int i = 0; i < tmp.Length; i++) tmp[i] = 0;

            //list配列の数値を
            for (int i = 0; i < list.Length; i++) tmp[list[i]]++;

            var ret = new List<int>();
            for (int i = 0; i < tmp.Length; i++)
            {
                for(int j = 0; j < tmp[i]; j++)
                {
                    ret.Add(i+1);
                }
            }

            var fin = ret.ToArray<int>();

            if (type == OrderType.Desc) Array.Reverse(fin);

            return fin;

        }


        /// <summary>
        /// 2つの比較可能オブジェクトを比較する。
        /// </summary>
        /// <typeparam name="Type"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="t"></param>
        /// <returns>OrderType.Asc->a Desc->b</returns>
        public static Type CompareByOrder<Type>(Type a, Type b, OrderType t)
            where Type : IComparable
        {
            if (a.Equals(b)) return a;
            else
            {
                if (t == OrderType.Asc) return (a.CompareTo(b) > 0 ? a : b);
                else return (a.CompareTo(b) < 0 ? a : b);
            }
        }


        /// <summary>
        /// 2つの比較可能オブジェクトを比較する。
        /// </summary>
        /// <typeparam name="Type"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>(a=b):0 (a>b):1 (a<b):-1</returns>
        public static bool Compare<Type> (Type a, Type b, OrderType t)
            where Type : IComparable
        {
            if (a.Equals(b)) return false;
            else
            {
                if (t == OrderType.Asc) return (a.CompareTo(b) > 0 ? true : false);
                                   else return (a.CompareTo(b) < 0 ? true : false);
            }
        }

        /// <summary>
        /// 2つの値を交換します
        /// </summary>
        /// <typeparam name="Type"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void Swap<Type>(ref Type a, ref Type b)
        {
            var tmp = a;
            a = b;
            b = tmp;
        }
    }

}