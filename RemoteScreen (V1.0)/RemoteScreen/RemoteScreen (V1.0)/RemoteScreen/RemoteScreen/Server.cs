using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Diagnostics;
using System.Windows.Forms;

namespace RemoteScreen
{
    class Server
    {
        TcpListener server = null;

        //Fixed service port for Remote Screen
        Int32 port = 55667;

        IPAddress localAddr;

        //Constructor
        public Server()
        {
            //Arbitrary Initialization
            server = null;
            localAddr = IPAddress.Parse("192.168.0.252");
        }

        //The server maintains connections for a single request, so multiple client(On different computer) can simultaneously connect to it.
        //Start Serving
        public void Serve()
        {

            try
            {
                server = new TcpListener(IPAddress.Any, port);

                // Start listening for client requests.
                server.Start();

                // Buffer for reading data
                Byte[] bytes = new Byte[256];
                String data = null;

                // Enter the listening loop.
                while (true)
                {
                    //You can replace Console output by Debug output (System.Diagnostics)
                    //Console.Write("Waiting for a connection... ");

                    // Perform a blocking call to accept requests.
                    // You could also user server.AcceptSocket() here.
                    TcpClient client = server.AcceptTcpClient();
                    //Console.WriteLine("Connected!");

                    //MessageBox.Show("Connected");
                    data = null;

                    // Get a stream object for reading and writing
                    NetworkStream stream = client.GetStream();
                    
                    //Save the image on C: drive
                    RemoteScreen.SaveScreenImage();

                    //Read image into buffer
                    byte[] msg = RemoteScreen.GetLatestImage();
                    
                    // Send back buffer.
                    stream.Write(msg, 0, msg.Length);

                    //
                    //Console.WriteLine("\n\nSent: {0}", msg.Length);
                    //Read <Send> request
                    int i;
                    i = stream.Read(bytes, 0, bytes.Length);
                
                    data = null;
                    // Translate data bytes to a ASCII string.
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);

                    //Print <Send>
                    //Console.WriteLine("{0} ", data);

                    // Shutdown and end connection
                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.ToString());
            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();
            }

        }
    }
}
