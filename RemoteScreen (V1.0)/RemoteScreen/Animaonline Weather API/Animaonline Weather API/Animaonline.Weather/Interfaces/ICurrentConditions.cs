using System;
namespace Animaonline.Weather.Interfaces
{
    /// <summary>
    /// Current Conditions
    /// </summary>
    public interface ICurrentConditions
    {
        /// <summary>
        /// Weather Condition
        /// </summary>
        string Condition { get; set; }
        /// <summary>
        /// Humidity In Percent
        /// </summary>
        string Humidity { get; set; }
        /// <summary>
        /// Icon Url
        /// </summary>
        string Icon { get; set; }
        /// <summary>
        /// Current Temperature Data
        /// </summary>
        Animaonline.Weather.Temperature Temperature { get; set; }
        /// <summary>
        /// Wind Condition
        /// </summary>
        string WindCondition { get; set; }
    }
}
