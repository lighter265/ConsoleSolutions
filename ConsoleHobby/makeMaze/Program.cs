using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

/// <summary>
/// 未完成。する予定もなし。
/// </summary>

namespace makeMaze
{
    class Program
    {
        static void Main(string[] args)
        {
            var map = new MakeMaze();

            map.setStart(2, 2);
            map.Create(15, 19);
            map.Fill(MakeMaze.WallTypeWall);

            map.Make();

            map.Dump();

            Console.ReadKey();
        }
    }

    public class Vector2D
    {
        public int x { get; set; }
        public int y { get; set; }

        public Vector2D(int X, int Y)
        {
            this.x = X;
            this.y = Y;
        }
    }

    public class MakeMaze
    {
        //定数------------------------------------------
        private const int _OutOfRange = -1;
        public const int WallTypeNone = 0;
        public const int WallTypeWall = 1;

        public const int numTypeEven = 0;
        public const int numTypeOdd = 1;


        //メンバー---------------------------------------
        private int _width;
        private int _height;
        private int[] _map = null;

        private int startx;
        private int starty;


        //アクセサー---------------------------------------
        public int width
        {
            get;
            protected set;
        }

        public int height
        {
            get;
            protected set;
        }
        //コンストラクタ------------------------------------
        public MakeMaze()
        {
            //nop
        }

        //公開メソッド---------------------------------------
        public void setStart(int x, int y)
        {
            startx = x;
            starty = y;
        }

        public void Create(int w, int h)
        {
            width = w;
            height = h;
            _map = new int[width * height];
        }
        
        public void Dump()
        {
            Console.WriteLine("[Maze Size] (w,h)=({0},{1})", width, height);

            for (int y = 0; y < height; y++)
            {
                string str = "";
                for (int x = 0; x < width; x++)
                {
                    str += (getValue(x, y) == WallTypeNone ? "□" : "■");
                }
                Console.WriteLine(str);
            }
        }

        public void Fill(int v)
        {
            for (int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    Set(x, y, v);
                }
            }
        }

        public void Make()
        {
            if(!isNumberType(startx, starty, numTypeEven))
            {
                Console.WriteLine("Error, setStartでは偶数を指定して下さい。");
                return;
            }
            if (!isNumberType(width, height, numTypeOdd))
            {
                Console.WriteLine("Error, Createでは奇数を指定して下さい。");
                return;
            }

            Dig(startx, starty);
        }
        //非公開メソッド---------------------------------------

        protected int toIndex(int x, int y)
        {
            return (y * width) + x;
        }

        protected bool isOutOfRange(int x, int y)
        {
            if (x < 0 || x >= width) return true;
            if (y < 0 || y >= height) return true;
            return false;
        }

        protected int getValue(int x, int y)
        {
            if (isOutOfRange(x, y)) return _OutOfRange;
            return _map[y * width + x];
        }

        protected void Set(int x, int y, int v)
        {
            if (isOutOfRange(x, y)) return;
            _map[y * width + x] = v;
        }

        protected bool isNumberType(int x, int y, int t)
        {
            if ((x % 2 == t) && (y % 2 == t)) return true;
            return false;
        }

        protected void Dig(int x, int y)
        {
            Set(x, y, WallTypeNone);

            Vector2D[] dlist =
            {
                new Vector2D(-1, 0),
                new Vector2D(0, -1),
                new Vector2D(1, 0),
                new Vector2D(0, 1)
            };
            

            for(int i = 0; i < dlist.Length; i++)
            {
                Random rd = new Random(DateTime.Now.Millisecond);
                var tmp = dlist[i];
                var idx = rd.Next(0, dlist.Length - 1);
                dlist[i] = dlist[idx];
                dlist[idx] = tmp;
            }

            foreach (var dir in dlist)
            {
                int dx = dir.x;
                int dy = dir.y;

                if (getValue(x + dx*2, y + dy+2) == WallTypeWall)
                {
                    Set(x + dx, y + dy, WallTypeNone);
                    Dig(x + dx * 2, y + dy + 2);
                }
            }
        }
    }
}
