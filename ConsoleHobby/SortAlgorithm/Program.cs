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
            int size = 10;
            int[] list = new int[size];
            Random r = new Random(DateTime.Now.Millisecond);
            for(int i = 0; i < size; i++)
            {
                list[i] = (r.Next() % size);
            }

            foreach(var item in list)
            {
                Debug.Write(item + " ");
            }
            Debug.WriteLine("");

            Stopwatch sw = new Stopwatch();
            sw.Start();

            var asced = Sort.Selection(list, Sort.OrderType.Asc);
            Debug.WriteLine("Asced.");
            foreach (var item in asced)
            {
                Debug.Write(item + " ");
            }
            Debug.WriteLine("");

            Debug.WriteLine(sw.Elapsed);

            var desced = Sort.Selection(list, Sort.OrderType.Desc);
            Debug.WriteLine("Desced.");
            foreach (var item in desced)
            {
                Debug.Write(item + " ");
            }
            Debug.WriteLine("");

            Debug.WriteLine(sw.Elapsed);

            sw.Stop();
        }
    }

    public class Sort
    {
        public  enum OrderType { Asc, Desc };

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

        public static Type[] Selection<Type>(Type[] list, OrderType type)
            where Type : IComparable
        {
            for(int i = 0; i < list.Length; i++)
            {
                Type temp = list[i];
                int tposi = i;
                for(int j = i+1; j < list.Length; j++)
                {
                    if (!Compare(temp, list[j], type)) tposi = j;
                }
                if (!temp.Equals(list[i])) Swap(ref list[i], ref list[tposi]);
            }

            return list;
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