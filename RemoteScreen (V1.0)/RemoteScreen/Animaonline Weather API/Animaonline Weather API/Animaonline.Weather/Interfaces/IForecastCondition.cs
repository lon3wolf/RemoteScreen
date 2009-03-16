using System;
namespace Animaonline.Weather.Interfaces
{
    /// <summary>
    /// Forecast Condition
    /// </summary>
    public interface IForecastCondition
    {
        /// <summary>
        /// Day Of Week
        /// </summary>
        string Day { get; set; }
        /// <summary>
        /// Icon Url
        /// </summary>
        string Icon { get; set; }
        /// <summary>
        /// Lowest Temperature Data
        /// </summary>
        Temperature Low { get; set; }
        /// <summary>
        /// Highest Temperatue Data
        /// </summary>
        Temperature High { get; set; }
        /// <summary>
        /// Weather Condition
        /// </summary>
        string Condition { get; set; }
    }
}
