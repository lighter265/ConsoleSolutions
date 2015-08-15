using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSolution
{
    public class InputValues
    {
        static void Main(string[] args)
        {
            
        }

        public InputValues()
        {

        }
        

        /// <summary>
        /// デリミタ区切りの入力は配列に分割して返す
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string[] getStrings(char d)
        {
            return Console.ReadLine().Split(d);
        }
    }

}
