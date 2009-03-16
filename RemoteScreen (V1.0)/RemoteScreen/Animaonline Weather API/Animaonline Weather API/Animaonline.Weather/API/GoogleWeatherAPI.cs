using System;
using Animaonline.Globals;
using Animaonline.Weather.Parsers.Google;
using Animaonline.Weather.WeatherData;

namespace Animaonline.Weather
{
    public class GoogleWeatherAPI
    {
        /// <summary>
        /// Gets the weather.
        /// </summary>
        /// <param name="Language">The language to get the weather data in</param>
        /// <param name="CityName">Name of the city to get the weather for</param>
        /// <returns></returns>
        public static GoogleWeatherData GetWeather(LanguageCode Language, string CityName)
        {
            GoogleWeatherData weatherData = new GoogleWeatherData();
            weatherData = GoogleWeatherFeedParser.ParseWeatherFeed(new Uri(Functions.GoogleWeatherFeedUrl(Language) + CityName));
            return weatherData;
        }
    }
}
