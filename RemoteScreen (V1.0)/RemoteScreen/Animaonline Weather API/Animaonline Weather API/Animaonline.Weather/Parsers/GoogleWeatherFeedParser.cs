using System;
using System.Linq;
using System.Xml.Linq;
using Animaonline.Geo;
using Animaonline.Globals;
using Animaonline.Weather.Exceptions;
using Animaonline.Weather.WeatherData;

namespace Animaonline.Weather.Parsers
{
    namespace Google
    {
        public static class GoogleWeatherFeedParser
        {
            /// <summary>
            /// Parses the weather feed.
            /// </summary>
            /// <param name="feedUri">The feed URI.</param>
            /// <returns></returns>
            public static GoogleWeatherData ParseWeatherFeed(Uri feedUri)
            {
                return ParseWeatherFeed(feedUri.ToString());
            }

            /// <summary>
            /// Parses the weather feed.
            /// </summary>
            /// <param name="fileName">Name of the file.</param>
            /// <returns></returns>
            public static GoogleWeatherData ParseWeatherFeed(string fileName)
            {
                TemperatureUnits UnitSystem = TemperatureUnits.Fahrenheit;
                GoogleWeatherData parsedData = new GoogleWeatherData();
                XDocument weatherFeed;

                try
                {
                    weatherFeed = XDocument.Load(fileName);
                }
                catch
                {
                    try
                    {
                        weatherFeed = XDocument.Parse(Downloader.DownloadString(fileName));
                    }
                    catch
                    {
                        throw new DownloadDataException();
                    }
                }

                var ForecastInformation = (from feed in weatherFeed.Descendants(ParserConstantVariables.FORECASTINFORMATION)
                                           select new ForecastInformation
                                           {
                                               City = feed.Element(ParserConstantVariables.CITY).Attribute(ParserConstantVariables.DATAATTRIBUTE).Value,
                                               PostalCode = feed.Element(ParserConstantVariables.POSTALCODE).Attribute(ParserConstantVariables.DATAATTRIBUTE).Value,
                                               Coordinates = new Coordinates(feed.Element(ParserConstantVariables.LATITUDEE6).Attribute(ParserConstantVariables.DATAATTRIBUTE).Value.ToDecimal(), feed.Element(ParserConstantVariables.LONGITUDEE6).Attribute(ParserConstantVariables.DATAATTRIBUTE).Value.ToDecimal()),
                                               ForecastDateTime = feed.Element(ParserConstantVariables.FORECASTDATE).Attribute(ParserConstantVariables.DATAATTRIBUTE).Value.ToDateTime(),
                                               CurrentDateTime = feed.Element(ParserConstantVariables.CURRENTDATETIME).Attribute(ParserConstantVariables.DATAATTRIBUTE).Value.ToDateTime(),
                                               UnitSystem = feed.Element(ParserConstantVariables.UNITSYSTEM).Attribute(ParserConstantVariables.DATAATTRIBUTE).Value
                                           });

                try
                {
                    switch (ForecastInformation.First().UnitSystem.ToUpper())
                    {
                        case "US":
                            UnitSystem = TemperatureUnits.Fahrenheit;
                            break;
                        case "SI":
                            UnitSystem = TemperatureUnits.Celsius;
                            break;
                        default:
                            throw new UnrecognizedUnitSystemException();
                    }
                }
                catch
                {
                    throw new NotImplementedException();
                }

                var CurrentConditions = (from feed in weatherFeed.Descendants(ParserConstantVariables.CURRENTCONDITIONS)
                                         select new CurrentConditions
                                         {
                                             Condition = feed.Element(ParserConstantVariables.CONDITION).Attribute(ParserConstantVariables.DATAATTRIBUTE).Value,
                                             Temperature = new Temperature(feed.Element(ParserConstantVariables.TEMPC).Attribute(ParserConstantVariables.DATAATTRIBUTE).Value.ToDouble(), feed.Element(ParserConstantVariables.TEMPF).Attribute(ParserConstantVariables.DATAATTRIBUTE).Value.ToDouble()),
                                             Humidity = feed.Element(ParserConstantVariables.HUMIDITY).Attribute(ParserConstantVariables.DATAATTRIBUTE).Value,
                                             Icon = feed.Element(ParserConstantVariables.ICON).Attribute(ParserConstantVariables.DATAATTRIBUTE).Value,
                                             WindCondition = feed.Element(ParserConstantVariables.WINDCONDITION).Attribute(ParserConstantVariables.DATAATTRIBUTE).Value
                                         });

                var ForecastConditions = (from feed in weatherFeed.Descendants(ParserConstantVariables.FORECASTCONDITIONS)
                                          select new ForecastCondition
                                          {
                                              Day = feed.Element(ParserConstantVariables.DAYOFWEEK).Attribute(ParserConstantVariables.DATAATTRIBUTE).Value,
                                              Low = new Temperature(feed.Element(ParserConstantVariables.LOW).Attribute(ParserConstantVariables.DATAATTRIBUTE).Value.ToDouble(), UnitSystem),
                                              High = new Temperature(feed.Element(ParserConstantVariables.HIGH).Attribute(ParserConstantVariables.DATAATTRIBUTE).Value.ToDouble(), UnitSystem),
                                              Icon = feed.Element(ParserConstantVariables.ICON).Attribute(ParserConstantVariables.DATAATTRIBUTE).Value,
                                              Condition = feed.Element(ParserConstantVariables.CONDITION).Attribute(ParserConstantVariables.DATAATTRIBUTE).Value
                                          });

                parsedData.ForecastInformation = ForecastInformation.First();
                parsedData.CurrentConditions = CurrentConditions.First();
                parsedData.ForecastConditions = ForecastConditions.ToList();

                return parsedData;
            }
        }
    }
}