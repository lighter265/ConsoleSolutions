//C#によるプログラム
//for https://codeiq.jp/challenge/2006

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CodeIQ2006
{
    /// <summary>
    /// メイン実行系
    /// </summary>
    class Program
    {
        //移動リスト
        static string data = @"{
    98: 91,
    97: 93,
    96: 94,
    84: 73,
    75: 61,
    67: 56,
    53: 48,
    3: 8,
    13: 19,
    21: 32,
    33: 46,
    42: 58,
    51: 70,
    68: 89
}";

        //Main的な
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            const int max= 100001; //最大試行回数
            var result = new List<int>(); //結果格納リスト

            for (int cnt = 0; cnt < max; cnt++)
            {
                result.Add(Play()); //試行
            }

            result.Sort(); //ソートして

            Console.WriteLine(result[max / 2 + 1]);

            Debug.WriteLine(result[max / 2 + 1]);
            Debug.WriteLine(sw.Elapsed);
        }

        //1回の試行
        static public int Play()
        {
            Random rnd = new Random(); //乱数
            IQ2006 parser = new IQ2006(data); //移動リストシリアル化
            int posi = 1; //現在地

            int cnt = 0; //移動回数
            while (posi <= 100) //100を超えない間
            {
                cnt++;
                posi += rnd.Next(1, 7);
                if (parser.ContainsFrom(posi)) //posiが移動リストにあれば
                    posi = parser.GetTo(posi); //その先へ移動

            }

            return cnt;
        }
    }

    /// <summary>
    /// 移動リストクラス
    /// int:int限定
    /// </summary>
    public class Position
    {
        public int from;
        public int to;

        //コンストラクタ
        //空初期化は認めない方向で
        public Position(int f, int t)
        {
            from = f;
            to = t;
        }

        //文字列化
        public override string ToString()
        {
            return string.Format("{0}: {1}", from, to);
        }
    }

    /// <summary>
    /// CodeIQ/2006のためのクラス
    /// </summary>
    class IQ2006
    {
        //メンバ
        private List<Position> warplist;


        //コンストラクラ
        public IQ2006(string obj)
        {
            Add(obj);
        }

        //メソッド

        /// <summary>
        /// 与えられた文字列を{int:int}形式のJSONとして格納する
        /// </summary>
        /// <param name="obj"></param>
        public void Add(string obj)
        {
            var delim = new char[] { '{', '}' };
            var fromto = obj.Trim(delim).Split(',');

            if (warplist == null) warplist = new List<Position>();

            foreach(var item in fromto)
            {
                var ft = item.Split(':');
                
                warplist.Add( new Position(int.Parse(ft[0]), int.Parse(ft[1])) );
            }
        }

        /// <summary>
        /// Postsionクラスを追加
        /// </summary>
        /// <param name="posi"></param>
        public void Add(Position posi)
        {
            warplist.Add(posi);
        }

        /// <summary>
        /// (2006)JSON形式の文字列を返す
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string ret = "";

            foreach(var str in warplist)
            {
                ret += str.ToString() + ", ";
            }
            
            return "{ " + ret.TrimEnd(new Char[]{ ',' , ' '}) +  " }";
        }

        /// <summary>
        /// 与えられた値がfrom側にあればtrueを返す
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool ContainsFrom(int p)
        {
            foreach(var item in warplist)
            {
                if (item.from == p) return true;
            }
            return false;
        }

        /// <summary>
        /// 与えられた値がfrom側にあればto側を返す
        /// 無ければ-1
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        public int GetTo(int from)
        {
            foreach(var item in warplist)
            {
                if (item.from == from) return item.to;
            }
            return -1;
        }
    }
}
