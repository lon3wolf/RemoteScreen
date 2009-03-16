using System;
namespace Animaonline.Hardware
{
    interface IGPS
    {
        void Dispose();
        Animaonline.Geo.Coordinates GetCoordinates();
        string[] GetPortNames();
        System.IO.Ports.SerialPort GpsPort { get; set; }
        void SetPortName(string portName);
    }
}
