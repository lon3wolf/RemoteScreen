using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace RemoteScreen
{   
    public class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Server server = null;
            if(args.Length!=0)
            {
                if(args.Length < 2)
                {
                    MessageBox.Show("Usage:\n RemoteScreen.exe IPAddress PortNo [NoHTML]\nFields in [] are optional");
                    return;
                }
                else if(args.Length == 2)
                {
                    try
                    {
                        server = new Server(args[0],int.Parse(args[1]),"");
                    }
                    catch
                    {
                        server = new Server(args[0],-1,""); //Causes to run on default port
                    }
                }
                else if (args.Length == 3)
                {
                    try
                    {
                        server = new Server(args[0], int.Parse(args[1]), args[2]);
                    }
                    catch
                    {
                        server = new Server(args[0], -1, args[2]); //Causes to run on default port
                    }
                }
                else
                {
                    MessageBox.Show("Too many arguments!");
                    return;
                }
            }
            else
            {
                server = new Server();
            }
            server.Serve2();
        }  
    }
}
