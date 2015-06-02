using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomFTPClient;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;

namespace FTPClient_WForms
{
    public partial class Form1 : Form
    {
        private FastFTP ftpConnection;
        private BackgroundWorker logReader;

        private String localDirectory = Directory.GetCurrentDirectory();

        public Form1()
        {
            InitializeComponent();
            showLocalFolder();

        }


        private void connect_button_Click(object sender, EventArgs e)
        {
            if (host_box.Text == String.Empty)
                MessageBox.Show("Укажи хост");
            else if (user_box.Text == String.Empty)
            {
                ftpConnection = new FastFTP();
                ftpConnection.Init(host_box.Text);

                logReader = new BackgroundWorker();
                logReader.DoWork += logReader_DoWork;
                logReader.RunWorkerAsync();
                ftpConnection.Connect();

                showRemoteFolder();
            }

        }

        void showRemoteFolder()
        {
            remoteFolder.Rows.Clear();
            remoteFolder.Rows.Add();
            remoteFolder.Rows[0].Cells[0].Value = "..";
            if (ftpConnection.currentDirectory == "/")
            {
                remoteFolder.Rows[0].Visible = false;
            }
            List<Element> Info = new List<Element>();

            foreach (String str in ftpConnection.listDirectoryContents)
            {
                String[] tmp = Regex.Split(str, ";");
                if (tmp[0] == "type=dir")
                {
                    Element E = new Element();
                    E.type = tmp[0].Substring(5);
                    E.modify = tmp[1].Substring(7);
                    E.size = String.Empty;
                    E.name = "[ " + tmp[2].Substring(1) + " ]";
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


            Info.Sort(delegate(Element x, Element y)
            {
                if (x.type == null && y.type == null) return 0;
                else if (x.type == null) return -1;
                else if (y.type == null) return 1;
                else return x.type.CompareTo(y.type);
            });


            int i = 1;
            foreach (Element E in Info)
            {
                remoteFolder.Rows.Add();
                remoteFolder.Rows[i].Cells[0].Value = E.name;
                remoteFolder.Rows[i].Cells[1].Value = E.size;
                remoteFolder.Rows[i].Cells[2].Value = E.type;
                i++;
            }
        }

        public void showLocalFolder()
        {
            DirectoryInfo DInfo = new DirectoryInfo(localDirectory);
            String[] dirList = Directory.GetDirectories(localDirectory);
            String[] fileList = Directory.GetFiles(localDirectory);

            localFolders.Rows.Clear();
            localFolders.Rows.Add();
            localFolders.Rows[0].Cells[0].Value = "..";
            List<Element> Info = new List<Element>();
            int iter = 0;
            foreach (String dir in dirList)
            {
                DirectoryInfo info = new DirectoryInfo(dir);
                localFolders.Rows.Add();
                localFolders.Rows[++iter].Cells[0].Value = "[ " + info.Name + " ]";
                localFolders.Rows[iter].Cells[2].Value = "dir";
            }

            foreach (String file in fileList)
            {
                FileInfo info = new FileInfo(file);
                localFolders.Rows.Add();
                localFolders.Rows[++iter].Cells[0].Value = info.Name;
                localFolders.Rows[iter].Cells[1].Value = info.Length;
                localFolders.Rows[iter].Cells[2].Value = "file";

            }
        }

        void logReader_DoWork(object sender, DoWorkEventArgs e)
        {
            StreamReader streamReader = new StreamReader(ftpConnection.consoleLog);
            while (true)
            {

                String tmp = ftpConnection.logLine;
                if (tmp != null && tmp != String.Empty)
                {
                    Invoke(new AddMessageDelegate(updateLog), tmp + "\r\n");
                }
                else Thread.Sleep(100);

            }
        }

        public delegate void AddMessageDelegate(string message);


        void updateLog(String str)
        {
            consoleLog.AppendText(str);
            consoleLog.SelectionStart = consoleLog.Text.Length;
            consoleLog.ScrollToCaret();
        }

        protected class Element
        {
            public String type;
            public String modify;
            public String size;
            public String name;
        }

        private void localFolders_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView DGV = (DataGridView)sender;
            int rowIndex = DGV.HitTest(e.X, e.Y).RowIndex;
            if (rowIndex != 0 && localFolders.Rows[rowIndex].Cells[2].Value.ToString() == "dir")
            {
                localDirectory += String.Concat('\\', localFolders.Rows[rowIndex].Cells[0].Value.ToString().Substring(2, localFolders.Rows[rowIndex].Cells[0].Value.ToString().Length - 4));
                showLocalFolder();
            }
            else if (rowIndex == 0)
            {
                DirectoryInfo Dinfo = new DirectoryInfo(localDirectory);
                localDirectory = Dinfo.Parent.FullName;
                showLocalFolder();
            }
        }


        private void remoteFolder_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView DGV = (DataGridView)sender;
            int rowIndex = DGV.HitTest(e.X, e.Y).RowIndex;
            if (rowIndex > 0 && remoteFolder.Rows[rowIndex].Cells[2].Value.ToString() == "dir")
            {
                String dir = remoteFolder.Rows[rowIndex].Cells[0].Value.ToString();
                dir = dir.Substring(2, dir.Length - 4);
                ftpConnection.currentDirectory += String.Concat(dir, "/");
                ftpConnection.ChangeDirectoryTo();
                showRemoteFolder();
            }
            else if (rowIndex == 0)
            {
                String dir = ftpConnection.currentDirectory;
                String[] tmp = dir.Split('/');
                dir = String.Empty;
                for (int i = 0; i < tmp.Count() - 2; i++)
                {
                    dir += tmp[i] + '/';
                }
                ftpConnection.ChangeDirectoryTo(dir);
                showRemoteFolder();

            }
        }
    }
}
