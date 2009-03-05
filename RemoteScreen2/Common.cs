using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
namespace RemoteScreen
{
    public static class Common
    {
        public const string FilePath = @"C:\sd.jpg";

        public static void SaveScreenImage()  //Saves Desktop Image to C:\sd.jpg
        {
            Bitmap bmp = CaptureScreen.GetDesktopImage();
            bmp.Save(FilePath, System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        public static byte[] GetLatestImage() //Gets the saved desktop image byte buffer from pre defined source C:\sd.jpg
        {
            byte[] buf = File.ReadAllBytes(FilePath);

            File.Delete(FilePath);

            return buf;
        }

    }
}
