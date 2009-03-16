using Animaonline.Weather.Interfaces;

namespace Animaonline.Weather.WeatherData
{
    public class ForecastCondition : IForecastCondition
    {
        /// <summary>
        /// Day Of Week
        /// </summary>
        /// <value></value>
        public string Day { get; set; }
        /// <summary>
        /// Icon Url
        /// </summary>
        /// <value></value>
        public string Icon { get; set; }
        /// <summary>
        /// Lowest Temperature Data
        /// </summary>
        /// <value></value>
        public Temperature Low { get; set; }
        /// <summary>
        /// Highest Temperatue Data
        /// </summary>
        /// <value></value>
        public Temperature High { get; set; }
        /// <summary>
        /// Weather Condition
        /// </summary>
        /// <value></value>
        public string Condition { get; set; }
    }
}
