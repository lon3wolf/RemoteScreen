using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace Animaonline.Hardware
{
    internal class GPS2
    {
        private SerialPort gpsPort;
        public SerialPort GpsPort
        {
            get { return gpsPort; }
            set { gpsPort = value; }
        }

        public void Open(string portName)
        {
            try
            {
                GpsPort = new SerialPort(portName)
                {
                    Parity = Parity.None,
                    BaudRate = 4800,
                    StopBits = StopBits.One,
                    DataBits = 8
                };
                GpsPort.Open();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Close()
        {
            try
            {
                GpsPort.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                GpsPort.Dispose();
            }
        }

        public void ProcessCommand(string cmd, byte[] rawData)
        {
            string sData = Encoding.Default.GetString(rawData);

            switch (cmd)
            {
                case "GPGGA":
                    ProcessGPGGA(sData);
                    break;
                case "GPGSA":
                    ProcessGPGSA(sData);
                    break;
                case "GPGSV":
                    ProcessGPGSV(sData);
                    break;
                case "GPRMC":
                    ProcessGPRMC(sData);
                    break;
                case "GPRMB":
                    ProcessGPRMB(rawData);
                    break;
                case "GPZDA":
                    ProcessGPZDA(rawData);
                    break;
                default:
                    break;
            }
        }

        private void ProcessGPZDA(byte[] rawData)
        {
            throw new NotImplementedException();
        }

        private void ProcessGPRMB(byte[] rawData)
        {
            throw new NotImplementedException();
        }

        private void ProcessGPRMC(string sData)
        {
            throw new NotImplementedException();
        }

        private void ProcessGPGSV(string sData)
        {
            throw new NotImplementedException();
        }

        private void ProcessGPGSA(string sData)
        {
            throw new NotImplementedException();
        }

        private void ProcessGPGGA(string sData)
        {
            throw new NotImplementedException();
        }
    }
}
