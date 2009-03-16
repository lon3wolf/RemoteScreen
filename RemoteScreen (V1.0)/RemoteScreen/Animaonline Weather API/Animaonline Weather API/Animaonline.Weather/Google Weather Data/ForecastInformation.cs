using System;
using Animaonline.Geo;
using Animaonline.Weather.Interfaces;

namespace Animaonline.Weather.WeatherData
{
    public class ForecastInformation : IForecastInformation
    {
        /// <summary>
        /// City Name
        /// </summary>
        /// <value></value>
        public string City { get; set; }
        /// <summary>
        /// Postal Code
        /// </summary>
        /// <value></value>
        public string PostalCode { get; set; }
        /// <summary>
        /// Geographic Location
        /// </summary>
        /// <value></value>
        public Coordinates Coordinates { get; set; }
        /// <summary>
        /// Forecast Date Time
        /// </summary>
        /// <value></value>
        public DateTime ForecastDateTime { get; set; }
        /// <summary>
        /// Current Date Time
        /// </summary>
        /// <value></value>
        public DateTime CurrentDateTime { get; set; }
        /// <summary>
        /// Unit System
        /// </summary>
        /// <value></value>
        public string UnitSystem { get; set; }
    }
}
