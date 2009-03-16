using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.ComponentModel;
using System.Xml;
using System.Diagnostics;

namespace Animaonline.Globals
{
    [DebuggerNonUserCode]
    public class IO
    {
        #region Constructors
        public IO()
        {

        }
        #endregion

        #region Destructors
        ~IO()
        {

        }
        #endregion

        #region File System
        public static class FileSystem
        {
            #region Static Methods
            public static Stream OpenFile(string path, FileMode mode)
            {
                return File.Open(path, mode);
            }
            #endregion
        }
        #endregion

        #region Network
        public class Network
        {
            #region Constant Variables
            const string BYTEORDERMARK = "ï»¿";
            #endregion

            #region Constructors
            /// <summary>
            /// Initializes a new instance of the <see cref="Network"/> class.
            /// </summary>
            public Network()
            {
                NetworkClient.DownloadFileCompleted += new AsyncCompletedEventHandler(NetworkClient_DownloadFileCompleted);
                NetworkClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(NetworkClient_DownloadProgressChanged);
            }
            #endregion

            #region Event Triggers
            /// <summary>
            /// Handles the DownloadFileCompleted event of the NetworkClient control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="System.ComponentModel.AsyncCompletedEventArgs"/> instance containing the event data.</param>
            static void NetworkClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
            { if (DownloadFileCompleted != null)DownloadFileCompleted(sender, e); }

            /// <summary>
            /// Handles the DownloadProgressChanged event of the NetworkClient control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="System.Net.DownloadProgressChangedEventArgs"/> instance containing the event data.</param>
            static void NetworkClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
            { if (DownloadProgressChanged != null)DownloadProgressChanged(sender, e); }
            #endregion

            #region Members
            /// <summary>
            /// Provides common methods for sending data to and receiving data from a resource identified by a URI.
            /// </summary>
            private static WebClient NetworkClient;
            #endregion

            #region Events
            /// <summary>
            /// Occurs when an asynchronous file download operation completes.
            /// </summary>
            public static event AsyncCompletedEventHandler DownloadFileCompleted;

            /// <summary>
            /// Occurs when an asynchronous download operation successfully transfers some or all of the data.
            /// </summary>
            public static event DownloadProgressChangedEventHandler DownloadProgressChanged;
            #endregion

            #region Static Methods
            /// <summary>
            /// Downloads the file from FTP.
            /// </summary>
            /// <param name="address">The address.</param>
            /// <param name="credentials">The credentials.</param>
            /// <param name="fileName">Name of the file.</param>
            public static void DownloadFileFromFtp(Uri address, NetworkCredential credentials, string fileName)
            {
                FtpWebRequest ftpReq;
                try
                {
                    using (FileStream outputStream = new FileStream(fileName, FileMode.Create))
                    {
                        ftpReq = (FtpWebRequest)FtpWebRequest.Create(address);
                        ftpReq.Method = WebRequestMethods.Ftp.DownloadFile;
                        ftpReq.UseBinary = true;
                        ftpReq.Credentials = credentials;
                        FtpWebResponse response = (FtpWebResponse)ftpReq.GetResponse();
                        Stream ftpStream = response.GetResponseStream();
                        long cl = response.ContentLength;
                        int bufferSize = 2048;
                        int readCount;
                        byte[] buffer = new byte[bufferSize];

                        readCount = ftpStream.Read(buffer, 0, bufferSize);
                        while (readCount > 0)
                        {
                            outputStream.Write(buffer, 0, readCount);
                            readCount = ftpStream.Read(buffer, 0, bufferSize);
                        }

                        ftpStream.Close();
                        outputStream.Close();
                        response.Close();
                    }
                }
                catch (Exception DownloadFileException)
                {
                    throw DownloadFileException;
                }
            }

            /// <summary>
            /// Downloads the resource with the specified URI to a local file.
            /// </summary>
            /// <param name="address">The URI from which to download data.</param>
            /// <param name="fileName">The name of the local file that is to receive the data.</param>
            /// <exception cref="System.Net.WebException"></exception>
            /// <exception cref="System.NotSupportedException"></exception>
            public static void DownloadFile(Uri address, string fileName) { DownloadFile(address.ToString(), fileName, null); }

            /// <summary>
            /// Downloads the resource with the specified URI to a local file.
            /// </summary>
            /// <param name="address">The URI from which to download data.</param>
            /// <param name="fileName">The name of the local file that is to receive the data.</param>
            /// <exception cref="System.Net.WebException"></exception>
            /// <exception cref="System.NotSupportedException"></exception>
            public static void DownloadFile(string address, string fileName) { DownloadFile(address, fileName, null); }

            /// <summary>
            /// Downloads the resource with the specified URI to a local file.
            /// </summary>
            /// <param name="address">The URI from which to download data.</param>
            /// <param name="fileName">The name of the local file that is to receive the data.</param>
            /// <exception cref="System.Net.WebException"></exception>
            /// <exception cref="System.NotSupportedException"></exception>
            public static void DownloadFile(string address, string fileName, string cookie)
            {
                using (NetworkClient = new WebClient())
                {
                    if (cookie != null)
                    {
                        NetworkClient.Headers[HttpRequestHeader.Cookie] = cookie;
                        NetworkClient.DownloadFile(address, fileName);
                    }
                    else
                    {
                        NetworkClient.DownloadFile(address, fileName);
                    }
                }
            }

            /// <summary>
            /// Downloads XML Data with the specified URI
            /// </summary>
            /// <param name="address">The URI from which to download XML data.</param>
            /// <exception cref="System.Net.WebException"></exception>
            /// <exception cref="System.NotSupportedException"></exception>
            /// <exception cref="System.Xml.XmlException"></exception>
            public static XmlDocument DownloadXmlDocument(string address) { return DownloadXmlDocument(address, null); }

            /// <summary>
            /// Downloads XML Data with the specified URI
            /// </summary>
            /// <param name="address">The URI from which to download XML data.</param>
            /// <exception cref="System.Net.WebException"></exception>
            /// <exception cref="System.NotSupportedException"></exception>
            /// <exception cref="System.Xml.XmlException"></exception>
            public static XmlDocument DownloadXmlDocument(string address, string cookie)
            {
                XmlDocument xDoc = new XmlDocument();
                using (NetworkClient = new WebClient())
                {
                    if (cookie != null)
                    {
                        NetworkClient.Headers[HttpRequestHeader.Cookie] = cookie;

                        string InnerXml = NetworkClient.DownloadString(address);

                        #region WebClient HACK - Fixes Byte Order Mark (BOM)
                        if (InnerXml.Contains(BYTEORDERMARK))
                        {
                            InnerXml = InnerXml.Replace(BYTEORDERMARK, string.Empty);
                        }
                        #endregion

                        xDoc.LoadXml(InnerXml);
                        return xDoc;
                    }
                    else
                    {
                        xDoc.LoadXml(NetworkClient.DownloadString(address));
                        return xDoc;
                    }
                }
            }

            /// <summary>
            /// Downloads, to a local file, the resource with the specified URI. This method does not block the calling thread.
            /// </summary>
            /// <param name="address">The URI of the resource to download.</param>
            /// <param name="fileName">The name of the file to be placed on the local computer.</param>
            /// <exception cref="System.Net.WebException"></exception>
            /// <exception cref="System.InvalidOperationException"></exception>
            public static void DownloadFileAsync(string address, string fileName) { DownloadFileAsync(new Uri(address), fileName, null); }

            /// <summary>
            /// Downloads, to a local file, the resource with the specified URI. This method does not block the calling thread.
            /// </summary>
            /// <param name="address">The URI of the resource to download.</param>
            /// <param name="fileName">The name of the file to be placed on the local computer.</param>
            /// <exception cref="System.Net.WebException"></exception>
            /// <exception cref="System.InvalidOperationException"></exception>
            public static void DownloadFileAsync(Uri address, string fileName) { DownloadFileAsync(address, fileName, null); }

            /// <summary>
            /// Downloads, to a local file, the resource with the specified URI. This method does not block the calling thread.
            /// </summary>
            /// <param name="address">The URI of the resource to download.</param>
            /// <param name="fileName">The name of the file to be placed on the local computer.</param>
            /// <exception cref="System.Net.WebException"></exception>
            /// <exception cref="System.InvalidOperationException"></exception>
            public static void DownloadFileAsync(Uri address, string fileName, string cookie)
            {
                using (NetworkClient = new WebClient())
                {
                    #region Event Subscription
                    NetworkClient.DownloadFileCompleted += NetworkClient_DownloadFileCompleted;
                    NetworkClient.DownloadProgressChanged += NetworkClient_DownloadProgressChanged;
                    #endregion
                    if (cookie != null)
                    {
                        NetworkClient.Headers[HttpRequestHeader.Cookie] = cookie;
                        NetworkClient.DownloadFileAsync(address, fileName);
                    }
                    else
                    {
                        NetworkClient.DownloadFileAsync(address, fileName);
                    }
                }
            }
            #endregion
        }
        #endregion
    }
}
