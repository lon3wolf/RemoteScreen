using System;
using System.Collections.Generic;
using Animaonline.Weather.Interfaces;
using Animaonline.Weather.Parsers.Google;

namespace Animaonline.Weather.WeatherData
{
    public class GoogleWeatherData : IGoogleWeatherData, IDisposable
    {
        public GoogleWeatherData() { }

        public GoogleWeatherData(string fileName)
        {
            GoogleWeatherData data = GoogleWeatherFeedParser.ParseWeatherFeed(fileName);
            this.currentConditions = data.currentConditions;
            this.forecastConditions = data.forecastConditions;
            this.forecastInformation = data.forecastInformation;
        }

        private CurrentConditions currentConditions = new CurrentConditions();
        public CurrentConditions CurrentConditions
        {
            get { return currentConditions; }
            set { currentConditions = value; }
        }

        private ForecastInformation forecastInformation = new ForecastInformation();
        public ForecastInformation ForecastInformation
        {
            get { return forecastInformation; }
            set { forecastInformation = value; }
        }

        private List<ForecastCondition> forecastConditions = new List<ForecastCondition>();
        public List<ForecastCondition> ForecastConditions
        {
            get { return forecastConditions; }
            set { forecastConditions = value; }
        }

        #region IDisposable Members

        public void Dispose()
        {
            currentConditions = null;
            forecastInformation = null;
            forecastConditions = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        #endregion
    }
}