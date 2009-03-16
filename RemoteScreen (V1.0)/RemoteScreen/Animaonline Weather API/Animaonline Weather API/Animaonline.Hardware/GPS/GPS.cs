using System;
using System.IO;
using System.IO.Ports;
using Animaonline.Geo;
using Animaonline.Globals;

namespace Animaonline.Hardware
{
    public class GPS : IDisposable, IGPS
    {
        private const char GPSSPLITCHAR = '$';
        private const string GPGGAIDENTIFIER = "GPGGA";
        private SerialPort gpsPort;
        public SerialPort GpsPort
        {
            get { return gpsPort; }
            set { gpsPort = value; }
        }

        public GPS()
        {
            GpsPort = new SerialPort();
        }

        public GPS(string portName)
        {
            try
            {
                GpsPort = new SerialPort(portName);
                GpsPort.Open();
            }
            catch (IOException OpenPortException)
            {
                throw OpenPortException;
            }
        }

        public void SetPortName(string portName)
        {
            if (GpsPort.PortName != portName)
            {
                GpsPort.PortName = portName;
                try
                {
                    GpsPort.Open();
                }
                catch (IOException SetPortNameException)
                {
                    throw SetPortNameException;
                }
            }
            else
            {
                if (!GpsPort.IsOpen)
                {
                    try
                    {
                        GpsPort.Open();
                    }
                    catch (IOException OpenPortException)
                    {
                        throw OpenPortException;
                    }
                }
            }
        }

        /// <summary>
        /// Gets the port names.
        /// </summary>
        /// <returns>Returns a string array of ports</returns>
        public string[] GetPortNames()
        {
            return SerialPort.GetPortNames();
        }

        /// <summary>
        /// Gets the coordinates from the satellite
        /// </summary>
        /// <returns></returns>
        public Coordinates GetCoordinates()
        {
            Coordinates GPSCoordinates = new Coordinates(0, 0);

            if (GpsPort.IsOpen)
            {
                string gpsData = GpsPort.ReadExisting();
                string[] gpsDataArray = gpsData.Split(GPSSPLITCHAR);

                for (int i = 0; i < gpsDataArray.Length; i++)
                {
                    string gpsTempData = gpsDataArray[i];
                    string[] gpsDataLineArray = gpsTempData.Split(',');

                    if (gpsDataLineArray[0] == GPGGAIDENTIFIER)
                    {
                        try
                        {
                            #region Latitude
                            try
                            {
                                gpsDataLineArray[2] = gpsDataLineArray[2].Replace('.', ',');
                            }
                            catch { }
                            Double dLat = Convert.ToDouble(gpsDataLineArray[2]);
                            int pt = dLat.ToString().IndexOf(',');
                            double degreesLat =
                            Convert.ToDouble(dLat.ToString().Substring(0, pt - 2));
                            double minutesLat =
                            Convert.ToDouble(dLat.ToString().Substring(pt - 2));
                            double DecDegsLat = degreesLat + (minutesLat / 60.0);
                            GPSCoordinates.Latitude = DecDegsLat.ToString().ToDecimal();
                            #endregion

                            #region Longitude
                            try
                            {
                                gpsDataLineArray[4] = gpsDataLineArray[4].Replace('.', ',');
                            }
                            catch { }
                            Double dLon = Convert.ToDouble(gpsDataLineArray[4]);
                            pt = dLon.ToString().IndexOf(',');
                            double degreesLon =
                            Convert.ToDouble(dLon.ToString().Substring(0, pt - 2));
                            double minutesLon =
                            Convert.ToDouble(dLon.ToString().Substring(pt - 2));
                            double DecDegsLon = degreesLon + (minutesLon / 60.0);
                            GPSCoordinates.Longitude = DecDegsLon.ToString().ToDecimal();
                            #endregion
                        }
                        catch (IOException GetGpsCoordinatesException)
                        {
                            throw GetGpsCoordinatesException;
                        }
                    }
                }
                return GPSCoordinates;
            }
            else
            {
                throw new Exception("SerialPort is closed");
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            try
            {
                if (GpsPort.IsOpen)
                {
                    GpsPort.Close();
                }
            }
            finally
            {
                GpsPort.Dispose();
            }
        }

        #endregion
    }
}
