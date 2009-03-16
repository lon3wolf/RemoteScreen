using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animaonline.Weather.Parsers
{
    namespace Google
    {
        public class ParserConstantVariables
        {
            public const string DATAATTRIBUTE = "data";

            public const string FORECASTINFORMATION = "forecast_information";
            public const string CITY = "city";
            public const string POSTALCODE = "postal_code";
            public const string LATITUDEE6 = "latitude_e6";
            public const string LONGITUDEE6 = "longitude_e6";
            public const string FORECASTDATE = "forecast_date";
            public const string CURRENTDATETIME = "current_date_time";
            public const string UNITSYSTEM = "unit_system";

            public const string CURRENTCONDITIONS = "current_conditions";
            public const string CONDITION = "condition";
            public const string TEMPF = "temp_f";
            public const string TEMPC = "temp_c";
            public const string HUMIDITY = "humidity";
            public const string ICON = "icon";
            public const string WINDCONDITION = "wind_condition";

            public const string FORECASTCONDITIONS = "forecast_conditions";
            public const string DAYOFWEEK = "day_of_week";
            public const string LOW = "low";
            public const string HIGH = "high";
        }
    }
}
