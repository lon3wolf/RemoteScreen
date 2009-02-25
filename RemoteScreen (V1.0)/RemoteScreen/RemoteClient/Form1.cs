using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;

///*Confession*
///Code is messy, and some bugs are there, but both client and server have full usability
///If you want to remove them, please do it
///
/// As Usual, I'm feeling Lazy (Leave it, for later) [:(]
/// Do Post back changes and code
/// Thanks!!
/// - Sanil
/// 
namespace RemoteClient
{
    public partial class Form1 : Form
    {
        HttpWebRequest HWR;

        //To split Comma Separated values
        public string [] CSVSplit = { "," };
        //To split NewLine Separated values
        public string[] NLSplit = { "\n" };

        public Form1()
        {
            InitializeComponent();
        }

        private void GetImage_Click(object sender, EventArgs e)
        {
            SetControlState(false);
            MemoryStream ms = Connect();
            try
            {
                Image I = Image.FromStream(ms);
                RcvdImg.Image = I;
                Ticker.Enabled = true;
            }
            catch
            {
                Ticker.Enabled = false;
            }

        }
        public void SetControlState(bool State)
        {
            IP.Enabled = State;
            ServerPort.Enabled = State;
            GetImage.Enabled = State;
        }
        public MemoryStream Connect()
        {
            try
            {

                Int32 port = Int32.Parse(this.ServerPort.Text);
                TcpClient client = new TcpClient(this.IP.Text, port);


                Byte[] data = System.Text.Encoding.ASCII.GetBytes("Send");


                NetworkStream stream = client.GetStream();

                // Send the message to the connected TcpServer. 
                stream.Write(data, 0, data.Length);


                // Receive the TcpServer.response.

                // Buffer to store the response bytes.
                data = new Byte[4096];


                // Read the first batch of the TcpServer response bytes.

                FileStream fs = File.Open(@"C:\sdf.jpg", FileMode.Create);
                Int32 bytes = 1;
                while (bytes != 0)
                {
                    bytes = 0;

                    bytes = stream.Read(data, 0, data.Length);
                    Console.Write("Bytes: {0}\n", bytes);
                    if (bytes != 0)
                    {
                        fs.Write(data, 0, bytes);
                        Console.Write("Wrote: {0}\n", bytes);
                    }
                }
                fs.Close();
                stream.Close();
                client.Close();
                MemoryStream ms = new MemoryStream(File.ReadAllBytes(@"C:\sdf.jpg"));
                return ms;
            }

            catch (ArgumentNullException e)
            {
                MessageBox.Show("ArgumentNullException: " + e.ToString());
                Ticker.Enabled = false;
            }
            catch (SocketException e)
            {
                MessageBox.Show("SocketException: " + e.ToString());
                Ticker.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.ToString());
                Ticker.Enabled = false;
            }
            return null;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            RcvdImg.Width = this.Width - IP.Right - 10;
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            File.Delete(@"C:\sdf.jpg");
            RcvdImg.Image = null;
        }

        private void FrameRate_ValueChanged(object sender, EventArgs e)
        {
            Ticker.Interval = (int)1000 / (int)FrameRate.Value;
        }

        private void Ticker_Tick(object sender, EventArgs e)
        {
            MemoryStream ms = Connect();
            Image I = Image.FromStream(ms);
            RcvdImg.Image = I;
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            Ticker.Enabled = false;
            SetControlState(true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            ///Comment this function, if you don't want the initial hang up of Client (But you will not be able to Fetch Server IPs from my Site)
            ReloadIPs();
        }

        private void IPList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = (string)IPList.Items[IPList.SelectedIndex];
            IP.Text = selected.Split(',')[1];
        }

        private void RefreshIPs_Click(object sender, EventArgs e)
        {
            IPList.Items.Clear();
            ReloadIPs();
        }

        /// <summary>
        ///Requests IP List that has Server running on them, parses them, and binds them to drop down list 
        ///Disable intial calls to it, to prevent hang up
        ///
        /// *Note*
        /// You can also replace this method with a Asynchronous one, so you won't get Start up hang ups
        /// I won't do it, as I'm Lazy and if you already know the IP, why you will need this feature!!
        /// </summary>
        private void ReloadIPs()
        {
            string Response=" ";
            byte[] Buf = new byte[4096];

            //If ID = TELL in Request(Tell is treated as a Command), Site returns IPs List
            HWR = (HttpWebRequest)HttpWebRequest.Create(new Uri("http://projects-sanil.co.cc/Services/IPLog.aspx?ID=TELL", UriKind.Absolute));
            HWR.Method = "GET";
            HttpWebResponse HWRE = (HttpWebResponse)HWR.GetResponse();
            Stream S = HWRE.GetResponseStream();
            int i;
            i=S.Read(Buf,0,Buf.Length);
            while(i>0)
            {
                string text = Encoding.ASCII.GetString(Buf,0,i);
                Response += text;
                i = S.Read(Buf, 0, Buf.Length);
            }
            File.WriteAllText("s.txt", Response);

            string[] IPCollection = Response.Split(NLSplit,StringSplitOptions.RemoveEmptyEntries);
            foreach (string IPEntry in IPCollection)
            {
                string[] Entry = IPEntry.Split(CSVSplit, StringSplitOptions.RemoveEmptyEntries);
                IPList.Items.Add(Entry[2] + "," + Entry[1]);
            }
        }
    }
}
