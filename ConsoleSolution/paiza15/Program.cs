using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace paiza15
{
    using CustomExtensions;

    //必要分のみ
    class LogParse
    {
        public string ipaddr { get; set; }
        public string date { get; set; }
        public string path { get; set; }

        public LogParse()
        {
            ipaddr = "";
            date = "";
            path = "";
        }

        public string GetOutPut()
        {
            return String.Format("{0} {1} {2}", ipaddr, date, path);
        }

        public string ipREGIX(string reg)
        {
            if (ipmatch(ipaddr, reg)) return GetOutPut();
            else return "";
        }

        private bool ipmatch(string seg, string pat)
        {
            int[] seg4 = StringExtension.ConvertIntParse(seg, '.').ToArray();
            string[] pat4 = pat.Split('.');

            for (int i=0;i<4;i++)
            {
                //Console.WriteLine(pat4[i]);
                //[]パターン
                if (pat4[i].IndexOf('[') != -1)
                {
                    var se = pat4[i].Trim(new Char[] { '[', ']' }).Split('-');
                    int start = int.Parse(se[0]);
                    int end = int.Parse(se[1]);
                    
                    if (start <= seg4[i] & seg4[i] <= end) continue;
                    else
                    {
                        //Console.WriteLine(">non>[] s{0} e{1}", start, end);
                        return false;
                    }
                }

                //*パターン
                if(pat4[i].IndexOf('*') != -1)
                {
                    //Console.WriteLine(">*>");
                    continue;
                }

                //数字固定
                if (int.Parse(pat4[i]) == seg4[i]) continue;
                else
                {
                    //Console.WriteLine(">num> {0} <> {1}", pat4[i], seg4[i]);
                    return false;
                }
            }

            //falseで返さなければtrue
            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var input = LoadingExtension.GetInputAsList();
            string ipreg = input[0];
            input.RemoveRange(0, 2);

            List<LogParse> list = new List<LogParse>();
            foreach (var item in input)
            {
                var tmp = item.Split(new Char[] { ' ' }, 8);
                list.Add(new LogParse() { ipaddr=tmp[0], date = tmp[3].TrimStart('[') , path = tmp[6] });
            }

            foreach(var item in list)
            {
                string ret = item.ipREGIX(ipreg);
                if(ret != "") Console.WriteLine(ret);
            }

            Console.ReadKey();
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