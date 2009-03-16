using System;
using System.IO;
using System.Net;

namespace Animaonline.Globals
{
    /// <summary>
    /// Handles the downloading
    /// </summary>
    public class Downloader
    {
        private static WebClient DownloadClient = new WebClient();

        /// <summary>
        /// Releases all resources used by the DownloadClient
        /// </summary>
        /// <exception cref="Exception">DisposeException</exception>
        public static void Dispose()
        {
            try
            {
                DownloadClient.Dispose();
            }
            catch (Exception DisposeException)
            {
                throw DisposeException;
            }
        }

        /// <summary>
        /// Downloads the requested resource as a System.String. The resource to download is specified as a System.String containing the URI.
        /// </summary>
        /// <param name="address">A System.String containing the URI to download.</param>
        /// <returns>A System.String containing the requested resource.</returns>
        public static string DownloadString(string address)
        {
            return DownloadString(new Uri(address));
        }

        /// <summary>
        /// Downloads the requested resource as a System.String. The resource to download is specified as a System.String containing the URI.
        /// </summary>
        /// <param name="address">A System.Uri containing the URI to download.</param>
        /// <returns>A System.String containing the requested resource.</returns>
        public static string DownloadString(Uri address)
        {
            try
            {
                using (DownloadClient = new WebClient())
                {
                    return DownloadClient.DownloadString(address);
                }
            }
            catch (Exception DownloadStringException)
            {
                throw DownloadStringException;
            }
        }


        /// <summary>
        /// Downloads the requested resources to the disk
        /// </summary>
        /// <param name="address">A System.String containing the URI to download</param>
        /// <param name="fileName">Target's filename</param>
        public static void DownloadToDisk(string address, string fileName)
        {
            DownloadToDisk(new Uri(address), fileName);
        }

        /// <summary>
        /// Downloads the requested resource to the disk
        /// </summary>
        /// <param name="address">A System.Uri containing the URI to download</param>
        /// <param name="fileName">Target's filename</param>
        public static void DownloadToDisk(Uri address, string fileName)
        {
            try
            {
                DownloadClient.DownloadDataAsync(address, fileName);
            }
            catch (Exception DownloadToDiskException)
            {
                throw DownloadToDiskException;
            }
        }
    }

    public class WindowsMobileDownloader
    {
        public static string DownloadString(string url)
        {
            HttpWebRequest REQ;
            HttpWebResponse RES;
            REQ = (HttpWebRequest)WebRequest.Create(url);
            RES = (HttpWebResponse)REQ.GetResponse();
            RES.Close();
            StreamReader SR = new StreamReader(RES.GetResponseStream());
            return SR.ReadToEnd();
        }
    }
}
