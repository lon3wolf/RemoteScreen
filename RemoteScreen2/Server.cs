using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace RemoteScreen
{
    class Server
    {
        #region Members
        TcpListener server = null;

        //Default service port for Remote Screen
        int DefaultPort = 55667;
        int port;

        //Controls:HTTP service 
        bool IsHTTPOn;

        //The interface on which server provides service
        IPAddress localAddr;

        //Code for future
        //Server Thread control
        //bool Running;

        public Socket Listener;
        #endregion

        #region Constructors
        public Server()
        {
            //Initialization
            server = null;
            localAddr = IPAddress.Any;
            port = DefaultPort;
            IsHTTPOn = true;
            //Code for future
            //Running = false;
        }

        public Server(string IP, int Port, string Options)
        {
            try
            {
                localAddr = IPAddress.Parse(IP);
            }
            catch
            {
                localAddr = IPAddress.Any;
            }
            if (0 < Port && Port < 65536)
            {
                port = Port;
            }
            else
            {
                port = DefaultPort;
            }

            //Code for Disabling HTTP, if third argument is NoHTTP
            if (string.Compare(Options, "NoHTTP") == 0)
            {
                IsHTTPOn = false;
            }
            else
            {
                IsHTTPOn = true;
            }
        }
        #endregion

        #region Server Control Code
        /*
        public bool Start()
        {
            Running = true;
            return Running;
        }

        public bool Stop()
        {
            Running = false;
            return Running;
        }
        */
        #endregion

        #region Server Code 
        //The server maintains connections for a single request, so multiple client(On different computer) can simultaneously connect to it.

        //Socket Listener, Connection;
        public void Serve2()
        {
            try
            {
                Listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Listener.Bind(new IPEndPoint(localAddr, port));
                Listener.Listen(100);  //To-Do: change to a const
                while (true)
                {
                    Socket Connection = Listener.Accept();
                    new Thread(new ParameterizedThreadStart(DoRequest)).Start(Connection);
                }
            }
            catch (SocketException e)
            {
                File.AppendAllText("Log.htm","<b>SocketException: </b>"+e.ToString());
            }
            catch (Exception ex)
            {
                File.AppendAllText("Log.htm", "<b>Exception: </b>" + ex.ToString());
            }
            finally
            {
                // Stop listening for new clients.
                Listener.Close();
            }
        }

        public void DoRequest(object socket)
        {
            Socket ConnectionSocket = (Socket)socket;

            int i = 0;
            byte[] RequestData = new byte[256];

            //try reading upto 256 bytes (Which will include GET OR SEND)
            i = ConnectionSocket.Receive(RequestData, RequestData.Length, SocketFlags.None);
                
            //We won't be processing empty requests
            if (i != 0)
            {
                string Request = Encoding.ASCII.GetString(RequestData).Trim();

                //Prepare image for sending
                RemoteScreen.Common.SaveScreenImage();
                byte[] msg = RemoteScreen.Common.GetLatestImage();

                //If request is a XRS client SEND request, then why worry about reading whole request
                if (Request.StartsWith("SEND", StringComparison.InvariantCultureIgnoreCase))
                {
                    //Is Remote client request
                    ConnectionSocket.Send(msg, msg.Length, SocketFlags.None);
                    ConnectionSocket.Close();
                }
                else
                {
                    //Procedure related to HTTP interfacing

                    //HTTP Header, to be followed by Screen Image Data
                    string HTTPHeader = "HTTP/1.1 200 OK \r\n"
                              + "Date: Thu, 26 Feb 2009 09:12:12 GMT \r\n"
                              + "Server: Apache/2.0.53 (Win32) PHP/5.2.0 \r\n"
                              + "Content-Length: " + msg.Length.ToString() + " \r\n"
                              + "ETag: \"77f2-2f9-e68a9eb8\"\r\n"
                              + "Accept-Ranges: bytes\r\n"
                              + "Connection: Close \r\n"
                              + "Content-Type: image/jpeg; \r\n\r\n";

                    do //Read rest of GET Request, as we may need the whole request in future
                    {
                        i = ConnectionSocket.Receive(RequestData, RequestData.Length, SocketFlags.None);
                        Request += Encoding.ASCII.GetString(RequestData).Trim();
                    } while (i == 0);


                    //Console.WriteLine("Received: {0}\n", Request);
                    //Is HTTP Request
                    if (Request.Contains("GET"))
                    {
                        //IS HTTP Requests allowed
                        if (IsHTTPOn)
                        {
                            byte[] HMsg = Encoding.ASCII.GetBytes(HTTPHeader);
                            ConnectionSocket.Send(HMsg, HMsg.Length, SocketFlags.None);
                            ConnectionSocket.Send(msg, msg.Length, SocketFlags.None); // Write Image Data
                            ConnectionSocket.Shutdown(SocketShutdown.Receive);
                        }
                    }
                }
            }
        }

        //Method Serve(): call it to start serving
        public void Serve()
        {
            try
            {
                server = new TcpListener(IPAddress.Any, port);

                // Start listening for client requests.
                server.Start();

                // Buffer for reading data
                Byte[] bytes = new Byte[256];

                #region Server Loop
                // Enter the listening loop.
                while (true)
                {                  
                    // Perform a blocking call to accept requests.
                    // You could also use server.AcceptSocket() here.
                    TcpClient client = server.AcceptTcpClient();

                    // Get a stream object for reading and writing
                    NetworkStream stream = client.GetStream();

                    int i;

                    i = stream.Read(bytes, 0, bytes.Length); //try reading upto 256 bytes (Which will include GET OR SEND)
                    //We won't be processing empty requests
                    if (i != 0)
                    {
                        string Request = Encoding.ASCII.GetString(bytes).Trim();
                        
                        //Prepare image for sending
                        RemoteScreen.Common.SaveScreenImage();
                        byte[] msg = RemoteScreen.Common.GetLatestImage();

                        //If request is a XRS client SEND request, then why worry about reading whole request
                        if (Request.StartsWith("SEND", StringComparison.InvariantCultureIgnoreCase))
                        {
                            //Is Remote client request

                            stream.Write(msg, 0, msg.Length);
                            client.Close();
                        }
                        else
                        {
                            //Procedure related to HTTP interfacing

                            //HTTP Header, to be followed by Screen Image Data
                            string HTTPHeader = "HTTP/1.1 200 OK \r\n"
                                      + "Date: Thu, 26 Feb 2009 09:12:12 GMT \r\n"
                                      + "Server: Apache/2.0.53 (Win32) PHP/5.2.0 \r\n"
                                      + "Content-Length: " + msg.Length.ToString() + " \r\n"
                                      + "ETag: \"77f2-2f9-e68a9eb8\"\r\n"
                                      + "Accept-Ranges: bytes\r\n"
                                      + "Connection: Close \r\n"
                                      + "Content-Type: image/jpeg; \r\n\r\n";

                            do //Read rest of GET Request, as we may need the whole request in future
                            {
                                i = stream.Read(bytes, 0, bytes.Length);
                                Request += Encoding.ASCII.GetString(bytes).Trim();
                            } while (i == 0);


                            //Console.WriteLine("Received: {0}\n", Request);
                            //Is HTTP Request
                            if (Request.Contains("GET"))
                            {
                                //IS HTTP Requests allowed
                                if (IsHTTPOn)
                                {
                                    byte[] HMsg = Encoding.ASCII.GetBytes(HTTPHeader);
                                    stream.Write(HMsg, 0, HMsg.Length); // Write Response header
                                    stream.Write(msg, 0, msg.Length); // Write Image Data
                                    //Assuming browser will call close(), thus sending FIN back
                                }
                            }
                        }
                    }
                }
                #endregion
            }
            catch (SocketException e)
            {
                File.AppendAllText("Log.htm","<b>SocketException: </b>"+e.ToString());
            }
            catch (Exception ex)
            {
                File.AppendAllText("Log.htm", "<b>Exception: </b>" + ex.ToString());
            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();
            }
        }

        #endregion
    }
}