using System;
using System.Net;
using Animaonline.Globals;

namespace Animaonline.Geo.GeoCoding
{
    /// <summary>
    /// Queries the server for coordinates
    /// </summary>
    public class GeoCode
    {
        private const string GeoCodeURL = "http://maps.google.com/maps/geo?q=";
        /// <summary>
        /// API Key is Required by the server
        /// </summary>
        public static string ApiKey;
        /// <summary>
        /// Output type, I'm using csv
        /// </summary>
        private const string OutputType = "csv";

        private static string addressTemp;

        /// <summary>
        /// Returns the query URL
        /// </summary>
        /// <param name="address">Address to query</param>
        /// <returns>Returns the query URL</returns>
        private static Uri GetGeoCodeUri(string address)
        {
            return new Uri(String.Format("{0}{1}&output={2}&key={3}", GeoCodeURL, address, OutputType, ApiKey));
        }

        /// <summary>
        /// Queries the GeoCode server for coordinates
        /// </summary>
        /// <param name="address">Address to query</param>
        /// <returns>Returns filled cordinates</returns>
        public static Coordinates GetCoordinates(string address)
        {
            addressTemp = address;
            if ((string.IsNullOrEmpty(ApiKey)) | (string.IsNullOrEmpty(ApiKey)))
            {
                throw new Exception("Google API key needs to be specified!");
            }
            try
            {
                Uri uri = GetGeoCodeUri(address);
                WebClient Client = new WebClient();
                string[] GeoCodeData = Client.DownloadString(uri).Split(',');
                return new Coordinates(GeoCodeData[2].ToDecimal(), GeoCodeData[3].ToDecimal());
            }
            catch (Exception GetCoordinatesException)
            {
                throw GetCoordinatesException;
            }
        }

        /// <summary>
        /// Returns a System.String that represents the current Coordinates
        /// </summary>
        /// <returns>A System.String that represents the current Coordinates</returns>
        public override string ToString()
        {
            Coordinates Coords = GetCoordinates(addressTemp);
            return string.Format("Latitude:{0} Longitude:{1}", Coords.Latitude, Coords.Longitude);
        }
    }
}
