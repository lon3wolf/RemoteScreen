using System;
namespace Animaonline.Weather.Interfaces
{
    /// <summary>
    /// Forecast Information
    /// </summary>
    public interface IForecastInformation
    {
        /// <summary>
        /// City Name
        /// </summary>
        string City { get; set; }
        /// <summary>
        /// Geographic Location
        /// </summary>
        Animaonline.Geo.Coordinates Coordinates { get; set; }
        /// <summary>
        /// Current Date Time
        /// </summary>
        DateTime CurrentDateTime { get; set; }
        /// <summary>
        /// Forecast Date Time
        /// </summary>
        DateTime ForecastDateTime { get; set; }
        /// <summary>
        /// Postal Code
        /// </summary>
        string PostalCode { get; set; }
        /// <summary>
        /// Unit System
        /// </summary>
        string UnitSystem { get; set; }
    }
}
