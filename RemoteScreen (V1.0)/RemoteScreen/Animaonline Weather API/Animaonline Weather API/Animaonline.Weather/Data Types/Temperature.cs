using Animaonline.Globals;

namespace Animaonline.Weather
{
    public class Temperature
    {
        public Temperature(double c, double f)
        {
            fahrenheit = f;
            celsius = c;
        }

        public Temperature(double t, TemperatureUnits unitSystem)
        {
            switch (unitSystem)
            {
                case TemperatureUnits.Fahrenheit:
                    fahrenheit = t;
                    celsius = UnitConversions.FahrenheitToCelsius(t);
                    break;
                case TemperatureUnits.Celsius:
                    celsius = t;
                    fahrenheit = UnitConversions.CelsiusToFahrenheit(t);
                    break;
                case TemperatureUnits.Rankine:
                    rankine = t;
                    break;
                case TemperatureUnits.Delisle:
                    delisle = t;
                    break;
                case TemperatureUnits.Newton:
                    newton = t;
                    break;
                case TemperatureUnits.Réaumur:
                    reaumur = t;
                    break;
                case TemperatureUnits.Rømer:
                    rømer = t;
                    break;
                case TemperatureUnits.Kelvin:
                    kelvin = t;
                    break;
            }
        }

        private double kelvin, fahrenheit, celsius, rankine, delisle, newton, reaumur, rømer;

        public double Kelvin
        {
            get { return kelvin; }
            set { kelvin = value; }
        }

        public double Fahrenheit
        {
            get { return fahrenheit; }
            set { fahrenheit = value; }
        }

        public double Celsius
        {
            get { return celsius; }
            set { celsius = value; }
        }

        public double Rankine
        {
            get { return rankine; }
            set { rankine = value; }
        }

        public double Delisle
        {
            get { return delisle; }
            set { delisle = value; }
        }

        public double Newton
        {
            get { return newton; }
            set { newton = value; }
        }

        public double Reaumur
        {
            get { return reaumur; }
            set { reaumur = value; }
        }

        public double Rømer
        {
            get { return rømer; }
            set { rømer = value; }
        }
    }
}
