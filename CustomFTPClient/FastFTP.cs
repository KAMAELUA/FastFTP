using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CustomFTPClient
{
    public class FastFTP
    {
        public String host;
        public String user;
        public String pass;

        public MemoryStream consoleLog = new MemoryStream();
        private StreamWriter logWriter;

        public bool isAnonymous = false;


        private Socket controller; //Управляющее соединение
        private Socket transfer; //Соединение передачи данных

        private String CD = "/"; //Current directory
        private String[] MLD; //Machine list directory

        public String currentDirectory
        {
            set { CD = value;}
            get { return CD;}
        }

        public FastFTP(String _host, String _user, String _pass)
        {
            host = _host;
            user = _user;
            pass = _pass;

            logWriter =  new StreamWriter(consoleLog);
        }

        public FastFTP()
        {

            logWriter = new StreamWriter(consoleLog);   

        }

        public void Init(String _host, int port = 21)
        {
            host = _host;
            isAnonymous = true;

            user = "anonymous";
            pass = "";
        }

        public void Connect()
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(host);
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 21);

            controller = new Socket(remoteEP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            controller.Connect(remoteEP);

            this.ReciveResponse(controller, true); //Получаем "Welcome message"

            this.Authenticate(); //Проходим аутентификацию

            this.EnterPassiveMode(); //Переход в пассивный режим

            //Устанавливаем соединение пересылки данных
            int transferPort = this.ParsePort(this.ReciveResponse(controller));
            this.EstablishTransfer(transferPort);

            //Получение текущей дерриктории и списка файлов/папок
            this.MachineListDirectory();
        }

        private void Authenticate()
        {   
            String str = String.Format("USER {0}\r\n", user);


            byte[] data = System.Text.Encoding.UTF8.GetBytes(str);
            controller.Send(data, SocketFlags.None);

            this.ReciveResponse(controller, true);

            str = String.Format("PASS {0}\r\n", pass);

            data = System.Text.Encoding.UTF8.GetBytes(str);
            controller.Send(data, SocketFlags.None);

            this.ReciveResponse(controller, true);
        }

        private byte[] ReciveResponse(Socket connection, bool log = false, bool debug = false)
        {
            byte[] buffer = new byte[1024];
            int byteCount;
            byteCount = connection.Receive(buffer, SocketFlags.None);

            if (byteCount > 0 && debug)
            {
                Debug.WriteLine(Encoding.UTF8.GetString(buffer, 0, byteCount));
                Console.WriteLine(Encoding.UTF8.GetString(buffer, 0, byteCount));
            }
            if (byteCount > 0 && log)
            {
                consoleLog.Position = consoleLog.Length;
                this.logWriter.WriteLine(Encoding.UTF8.GetString(buffer, 0, byteCount));
                this.logWriter.Flush();
                consoleLog.Position = 0;
            }

            return buffer;
        }

        public String logLine
        {
            get
            {
                String tmp;                
                StreamReader streamReader = new StreamReader(consoleLog);

                tmp = streamReader.ReadLine();

                if (tmp == null) return String.Empty;

                int countBytes = Encoding.UTF8.GetBytes(tmp).Count();
                byte[] streamData = consoleLog.ToArray().Skip(countBytes+2).ToArray();

                String byteData = Encoding.UTF8.GetString(streamData);

                consoleLog = new MemoryStream();

                logWriter = new StreamWriter(consoleLog);

                logWriter.Write(byteData);
                logWriter.Flush();
                consoleLog.Position = 0;
                


                return tmp;
            }
        }

        private void EnterPassiveMode()
        {
            if (this.controller.AddressFamily == AddressFamily.InterNetwork)
            {
                String str = "PASV\r\n";
                byte[] data = System.Text.Encoding.UTF8.GetBytes(str);
                controller.Send(data, SocketFlags.None);
            }
            else if (this.controller.AddressFamily == AddressFamily.InterNetworkV6)
            {
                String str = "EPSV\r\n";
                byte[] data = System.Text.Encoding.UTF8.GetBytes(str);
                controller.Send(data, SocketFlags.None);
            }
        }

        private int ParsePort(byte[] response)
        {
            if (this.controller.AddressFamily == AddressFamily.InterNetwork)
            {
                String str = System.Text.Encoding.UTF8.GetString(response);
                String pattern = @"227[\w\s]*\(\d{0,3},\d{0,3},\d{0,3},\d{0,3},(\d{0,3}),(\d{0,3})\)";
                Match m = Regex.Match(str, pattern);

                return int.Parse(m.Groups[1].Value) * 256 + int.Parse(m.Groups[2].Value);
            }
            else if (this.controller.AddressFamily == AddressFamily.InterNetworkV6)
            {
                String str = System.Text.Encoding.UTF8.GetString(response);
                String pattern = @"229[\w\s]*[\|\(]{4}([\d]{0,5})[\|\)]{2}";
                Match m = Regex.Match(str, pattern);
                return int.Parse(m.Groups[1].Value);
            }

            return 0;
        }

        private void EstablishTransfer(int port)
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(host);
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

            this.transfer = new Socket(remoteEP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            transfer.Connect(remoteEP);
        }

        private void MachineListDirectory(String dir = "")
        {
            String str = String.Format("MLSD{0}\r\n", " "+dir);
            byte[] data = System.Text.Encoding.UTF8.GetBytes(str);
            controller.Send(data, SocketFlags.None);
            
            this.ReciveResponse(controller, true);
            byte[] response = this.ReciveResponse(transfer);
            String tmp = System.Text.Encoding.UTF8.GetString(response);
            
            String[] tmp_mld = Regex.Split(tmp, "\r\n");


            object B = tmp_mld.Take(tmp_mld.Count()-1);

            MLD = ((IEnumerable)B).Cast<object>()
                                 .Select(x => x.ToString())
                                 .ToArray();


            this.ReciveResponse(controller);
        }
        
        public void ChangeDirectoryTo(String dir = null)
        {
            if (dir == null) dir = CD;
            String str = String.Format("CWD {0}\r\n", dir);
            controller.Send(System.Text.Encoding.UTF8.GetBytes(str));
            ReciveResponse(controller, true);

            if(dir.ElementAt(0) == '/')
            {
                this.CD = dir;
            }
            else
            {
                CD += '/' + dir;
            }

            this.EnterPassiveMode(); //Переход в пассивный режим

            //Устанавливаем соединение пересылки данных
            int transferPort = this.ParsePort(this.ReciveResponse(controller));
            this.EstablishTransfer(transferPort);
            
            MachineListDirectory();
        }

        public void ListDirectoryContents()
        {
            List<Element> Info = new List<Element>();
            foreach(String str in MLD)
            {
                String[] tmp = Regex.Split(str, ";");
                if(tmp[0] == "type=dir")
                {
                    Element E = new Element();
                    E.type = tmp[0].Substring(5);
                    E.modify = tmp[1].Substring(7);
                    E.size = String.Empty;
                    E.name = tmp[2].Substring(1);
                    Info.Add(E);
                }
                else
                {
                    Element E = new Element();
                    E.type = tmp[0].Substring(5);
                    E.modify = tmp[1].Substring(7);
                    E.size = tmp[2].Substring(5);
                    E.name = tmp[3].Substring(1);
                    Info.Add(E);
                }
                
            }
            foreach(Element E in Info)
            {
                String tmp = String.Format("{0}\t{1}\t{2}\t{3}", E.type, E.modify, E.size, E.name);
                Console.WriteLine(tmp);
            }
        }

        public void UploadFile(String path)
        {
            FileInfo fileInfo = new FileInfo(path);
            String query;
            query = String.Format("CWD {0}\r\n", CD);
            controller.Send(Encoding.UTF8.GetBytes(query));
            ReciveResponse(controller, true);
            
            query = "TYPE i\r\n";
            controller.Send(Encoding.UTF8.GetBytes(query));
            ReciveResponse(controller, true);

            EnterPassiveMode();
            int port = ParsePort(ReciveResponse(controller));
            EstablishTransfer(port);

            query = String.Format("STOR {0}\r\n", fileInfo.Name);
            controller.Send(Encoding.UTF8.GetBytes(query));
            ReciveResponse(controller, true);

            transfer.SendFile(fileInfo.FullName);
            transfer.Close();
            ReciveResponse(controller, true);

            EnterPassiveMode();
            port = ParsePort(ReciveResponse(controller));
            EstablishTransfer(port);

            MachineListDirectory(CD);
        }

        public void DownloadFile(String file, String localDirectory)
        {
            String query;
            query = String.Format("CWD {0}\r\n", CD);
            controller.Send(Encoding.UTF8.GetBytes(query));
            ReciveResponse(controller, true);

            query = "TYPE i\r\n";
            controller.Send(Encoding.UTF8.GetBytes(query));
            ReciveResponse(controller, true);

            EnterPassiveMode();
            int port = ParsePort(ReciveResponse(controller));
            EstablishTransfer(port);

            query = String.Format("RETR {0}\r\n", file);
            controller.Send(Encoding.UTF8.GetBytes(query));
            ReciveResponse(controller, true);
            byte[] buffer = new byte[1024];
            int bytesRead;
            String filePath = localDirectory + '\\' + file;
            using (var output = File.Create(filePath))
            {
                while ((bytesRead = transfer.Receive(buffer, buffer.Length, SocketFlags.None)) > 0)
                {
                    output.Write(buffer, 0, bytesRead);
                }
            }

            ReciveResponse(controller, true);

        }

        public void DeleteFile(String file)
        {
            String query;
            query = String.Format("DELE {0}\r\n", file);

            controller.Send(Encoding.UTF8.GetBytes(query));
            ReciveResponse(controller, true);

            EnterPassiveMode();
            int port = ParsePort(ReciveResponse(controller));
            EstablishTransfer(port);
            MachineListDirectory(CD);

        }

        public String[] listDirectoryContents
        {
            get
            {
                return MLD;
            }
        }

        protected class Element
        {
            public String type;
            public String modify;
            public String size;
            public String name;
        }

    }
}
