using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Drawing.Imaging;
using System.IO;

namespace RemoteClient
{
    public partial class Client : Form
    {
        public int FrameCount = 0;

        public Client()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings()
        {
            ServerPort.Text = global::RemoteClient.Properties.Settings.Default.ServicePort.ToString();
            HostName.Text = global::RemoteClient.Properties.Settings.Default.HostName;
        }

        private void Client_Paint(object sender, PaintEventArgs e)
        {
            RcvdImg.Height = this.Height - RcvdImg.Margin.Top;
            RcvdImg.Width = this.Width - ControlGroup.Width - ControlGroup.Margin.Horizontal;
        }

        public void Connect()
        {
            RcvdImg.Image = null;
            try
            {
                //Get the port
                Int32 port = Int32.Parse(this.ServerPort.Text);
                
                TcpClient client = new TcpClient(this.HostName.Text, port);
                
                Byte[] data = System.Text.Encoding.ASCII.GetBytes("Send");
                NetworkStream stream = client.GetStream();
                // Send the message to the connected TcpServer. 
                stream.Write(data, 0, data.Length);


                // Receive the TcpServer.response.
                // Buffer to store the response bytes.
                data = new Byte[65536];

                
                // Read response
                int bytes = 0;
                MemoryStream memStream = new MemoryStream();
                do
                {
                    bytes = 0;
                    bytes = stream.Read(data, 0, data.Length);
                    if (bytes != 0)
                    {
                        memStream.Write(data, 0, bytes);
                    }
                } while (bytes != 0);
                stream.Close();
                client.Close();
                RcvdImg.Image = Image.FromStream(memStream);
                FrameCount++;
            }
            catch (SocketException e)
            {
                StopClient();
                MessageBox.Show("Unable to connect to Remote Host\nReason: "+e.Message);
            }
            catch (Exception ex)
            {
                StopClient();
                MessageBox.Show("Error: " + ex.ToString());
            }
        }

        private void SaveSettings_Click(object sender, EventArgs e)
        {
            SaveServerSettings();
        }

        private void SaveServerSettings()
        {
            try
            {
                global::RemoteClient.Properties.Settings.Default.HostName = HostName.Text;
                global::RemoteClient.Properties.Settings.Default.ServicePort = int.Parse(ServerPort.Text);
                global::RemoteClient.Properties.Settings.Default.Save();
            }
            catch
            {
                MessageBox.Show("These settings doesn't seem correct");
                ServerPort.Text = "55667";
                HostName.Text = "127.0.0.1";
            }
        }

        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveServerSettings();
            Application.Exit();
        }

        private void RequestRate_ValueChanged(object sender, EventArgs e)
        {
            Ticker.Interval = 1000 / RequestRate.Value;
            CurrentRate.Text = RequestRate.Value.ToString() + " Requests/second";
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            RcvdImg.Image = null;
        }

        private void SaveImage_Click(object sender, EventArgs e)
        {
            StopClient();
            if (RcvdImg.Image != null)
            {
                SaveFileDialog SFD = new SaveFileDialog();
                SFD.Filter = "Joint Photographic Experts Group (*.jpg)|*.jpg";
                SFD.FileName = string.Empty;
                SFD.ShowDialog();
                if (SFD.FileName != string.Empty)
                {
                    RcvdImg.Image.Save(SFD.FileName, ImageFormat.Jpeg);
                }
            }
            else
            {
                MessageBox.Show("There is no image to be saved");
            }
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            StopClient();
        }

        private void GetImage_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void Ticker_Tick(object sender, EventArgs e)
        {
            Connect();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Ticker.Interval = 1000 / RequestRate.Value;
            Ticker.Enabled = true;
            FrameTimer.Enabled = true;
        }

        private void FrameTimer_Tick(object sender, EventArgs e)
        {
            FrameRate.Text = "Frames/sec: " + FrameCount * 1000 / FrameTimer.Interval;
            FrameCount = 0;
        }

        private void HostName_Enter(object sender, EventArgs e)
        {
            StopClient();
        }

        private void ServerPort_Enter(object sender, EventArgs e)
        {
            StopClient();
        }
        public void StopClient()
        {
            Ticker.Interval = 1000;
            Ticker.Enabled = false;
            FrameTimer.Enabled = false;
        }
    }
}
