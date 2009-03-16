using System;
using Animaonline.Weather.WeatherData;
namespace Animaonline.Weather.Interfaces
{
    public interface IGoogleWeatherData
    {
        CurrentConditions CurrentConditions { get; set; }
        System.Collections.Generic.List<ForecastCondition> ForecastConditions { get; set; }
        ForecastInformation ForecastInformation { get; set; }
    }
}
