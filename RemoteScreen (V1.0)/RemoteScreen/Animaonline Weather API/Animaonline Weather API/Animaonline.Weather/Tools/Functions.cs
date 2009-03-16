using System;
using System.Globalization;
using Animaonline.Globals;

namespace Animaonline.Weather
{
    public static class Functions
    {
        public static Uri GoogleWeatherFeedUrl(CultureInfo cultureInfo)
        {
            switch (cultureInfo.TwoLetterISOLanguageName.ToUpper())
            {
                case "EN":
                    return GoogleWeatherFeedUrl(LanguageCode.en_US);
                case "FR":
                    return GoogleWeatherFeedUrl(LanguageCode.fr_FR);
                case "DE":
                    return GoogleWeatherFeedUrl(LanguageCode.de_DE);
                case "IT":
                    return GoogleWeatherFeedUrl(LanguageCode.it_IT);
                case "NO":
                    return GoogleWeatherFeedUrl(LanguageCode.nb_NO);
                case "JP":
                    return GoogleWeatherFeedUrl(LanguageCode.ja_JP);
                case "RU":
                    return GoogleWeatherFeedUrl(LanguageCode.ru_RU);
                default:
                    return GoogleWeatherFeedUrl((LanguageCode)(-1));
            }
        }

        public static Uri GoogleWeatherFeedUrl(LanguageCode languageCode)
        {
            switch (languageCode)
            {
                case LanguageCode.en_US:
                    return new Uri(@"http://www.google.com/ig/api?weather=");
                case LanguageCode.en_GB:
                    return new Uri(@"http://www.google.co.uk/ig/api?weather=");
                case LanguageCode.fr_FR:
                    return new Uri(@"http://www.google.fr/ig/api?weather=");
                case LanguageCode.de_DE:
                    return new Uri(@"http://www.google.de/ig/api?weather=");
                case LanguageCode.it_IT:
                    return new Uri(@"http://www.google.it/ig/api?weather=");
                case LanguageCode.nb_NO:
                    return new Uri(@"http://www.google.no/ig/api?weather=");
                case LanguageCode.ja_JP:
                    return new Uri(@"http://www.google.co.jp/ig/api?weather=");
                case LanguageCode.ru_RU:
                    return new Uri(@"http://www.google.ru/ig/api?weather=");
                default:
                    return new Uri(@"http://www.google.com/ig/api?weather=");
            }
        }
    }
}
