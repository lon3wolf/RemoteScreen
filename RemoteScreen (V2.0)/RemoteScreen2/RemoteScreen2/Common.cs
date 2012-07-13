using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
namespace RemoteScreen
{
    public static class Common
    {
        //public static string filePath = Path.Combine(Path.GetTempPath(), "file.jpg");
        public static MemoryStream memStream;

        public static void SaveScreenImage()  //Saves Desktopubp Image to C:\sd.jpg
        {
            //Bitmap bmp = CaptureScreen.GetDesktopImage();
            memStream = new MemoryStream();
            Bitmap bmp = CaptureScreen.CaptureDesktopWithCursor();
            bmp.Save((Stream)memStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            
            //try
            //{
            //    bmp.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
            //}
            //catch(Exception ex)
            //{
            //    File.AppendAllText("Log.htm", "<b>SocketException: </b>" + ex.ToString());
            //}
        }

        public static byte[] GetLatestImage() //Gets the saved desktop image byte buffer from pre defined source C:\sd.jpg
        {
            //byte[] buf = File.ReadAllBytes(filePath);
            //File.Delete(filePath);
            byte[] buf = memStream.GetBuffer();
            memStream.Dispose();
            return buf;
        }

    }
}
