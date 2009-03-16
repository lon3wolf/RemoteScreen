using System;

namespace Animaonline.Globals
{
    public class UnitConversions
    {
        private static int digits = 2;
        public static int Digits
        {
            get { return digits; }
            set { digits = value; }
        }

        private const double KILOMETERINMILES = 0.621371192;
        private const double MILEINKILOMETERS = 1.609344;

        /// <summary>
        /// Converts celsius to fahrenheit.
        /// </summary>
        /// <param name="c">Degrees in celsius</param>
        /// <returns></returns>
        public static double CelsiusToFahrenheit(double c)
        {
            return Math.Round(((9.0 / 5.0) * Double.Parse(c.ToString())) + 32, Digits);
        }

        /// <summary>
        /// Converts fahrenheit to celsius.
        /// </summary>
        /// <param name="f">Degrees in fahrenheit</param>
        /// <returns></returns>
        public static double FahrenheitToCelsius(double f)
        {
            return Math.Round((5.0 / 9.0) * (Double.Parse(f.ToString()) - 32), Digits);
        }
        public static double MilesToKilometers(double Miles)
        {
            return Math.Round(Miles * MILEINKILOMETERS, Digits);
        }

        public static double MilesToKilometers(string Miles)
        {
            return Math.Round(double.Parse(Miles) * MILEINKILOMETERS, Digits);
        }

        public static double KilometersToMiles(double Kilometers)
        {
            return Math.Round(Kilometers * KILOMETERINMILES, Digits);
        }

        public static double KilometersToMiles(string Kilometers)
        {
            return Math.Round(double.Parse(Kilometers) * KILOMETERINMILES, Digits);
        }
    }
}
