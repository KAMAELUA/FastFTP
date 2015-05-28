using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CustomFTPClient
{
    class Program
    {
        private static FastFTP client;
        private static String command = String.Empty;
        static void Main(string[] args)
        {
            client = new FastFTP("localhost");
            /*String pattern = @"227[\w\s]*\(\d{0,3},\d{0,3},\d{0,3},\d{0,3},(\d{0,3}),(\d{0,3})\)";
            String str = "227 Entering Passive Mode (127,0,0,1,234,241)";
            Match m = Regex.Match(str, pattern);

            Console.WriteLine(m.Groups[1]);*/

            do
            {
                command = Console.ReadLine();
            }
            while (true);
        }
    }
}
