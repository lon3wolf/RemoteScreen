using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Animaonline.Weather;

namespace Animaonline.Geo
{
    public class Coordinates : Interfaces.ICoordinates
    {
        public Coordinates(decimal lat, decimal lng)
        {
            Latitude = lat;
            Longitude = lng;
        }

        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public override string ToString()
        {
            return String.Format("{0},{1}", Latitude, Longitude);
        }
    }
}
