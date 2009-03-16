using Animaonline.Weather.Interfaces;

namespace Animaonline.Weather.WeatherData
{
    public class CurrentConditions : ICurrentConditions
    {
        /// <summary>
        /// Weather Condition
        /// </summary>
        /// <value></value>
        public string Condition { get; set; }
        /// <summary>
        /// Current Temperature Data
        /// </summary>
        /// <value></value>
        public Temperature Temperature { get; set; }
        /// <summary>
        /// Humidity In Percent
        /// </summary>
        /// <value></value>
        public string Humidity { get; set; }
        /// <summary>
        /// Icon Url
        /// </summary>
        /// <value></value>
        public string Icon { get; set; }
        /// <summary>
        /// Wind Condition
        /// </summary>
        /// <value></value>
        public string WindCondition { get; set; }
    }
}