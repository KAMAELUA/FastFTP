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

            do
            {
                //client.ListDirectoryContents();
                command = Console.ReadLine();
                DoThis();
            }
            while (true);
        }

        public static void DoThis()
        {
            String[] cmd = command.Split(new char[]{' '});

            switch (cmd[0])
            {
                case "ls":
                    client.ListDirectoryContents();
                    break;
                case "cd":
                    client.ChangeDirectoryTo(cmd[1]);
                    break;
                default:
                    break;
            }
        }
    }
}
