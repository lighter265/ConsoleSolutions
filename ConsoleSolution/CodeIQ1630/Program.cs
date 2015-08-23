using System;
using System.Collections.Generic;

//参考:http://blog.goo.ne.jp/r-de-r/e/beb3545bda0c65dd0072bf37a2caaa42
namespace CodeIQ1630
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = InputValues.getInput();

            foreach (var item in input)
            {
                Console.WriteLine(get7num(item));
            }

            Console.ReadKey();
        }

        /// <summary>
        /// 0-numまでの7の数を足したものを返す
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        static public ulong get7num(string input)
        {
            ulong ret = 0;

            ulong num = ulong.Parse(input);

            while (true)
            {
                //桁数を取得
                ulong keta = (ulong)num.ToString().Length;
                //1桁目の値
                ulong first = num / (ulong)Math.Pow(10, keta-1); 

                //10ループごとに"7"は必ず1度現れる
                ret += first * (keta-1) * (ulong)Math.Pow(10, keta-2);
                //1桁目が7なら、先頭の7を数える。
                if (first == 7) ret += num - 7 * (ulong)Math.Pow(10, keta-1) + 1;
                //1桁目が7より大なら、7****番台の1桁目の7を全て数える
                else if (first > 7) ret += (ulong)Math.Pow(10, keta-1);

                //1桁目を削除
                num = num % (ulong)Math.Pow(10, keta-1);
                if (num == 0) break;
            }

            return ret;
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
