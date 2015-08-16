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
            //List<string> x = new List<string>();

            //List<double> y = x.ConvertAll(n => double.Parse)
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
