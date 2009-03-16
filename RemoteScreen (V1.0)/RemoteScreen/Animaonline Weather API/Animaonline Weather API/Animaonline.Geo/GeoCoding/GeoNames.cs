using System;
using System.Xml;

namespace Animaonline.Geo.GeoCoding
{
    /// <summary>
    /// Reverse GeoCoder - Powered by geonames.org
    /// </summary>
    public class GeoNames
    {
        /// <summary>
        /// Reverse GeoCoder - Powered by geonames.org
        /// </summary>
        /// <param name="coords">Input coordinates</param>
        /// <returns>A filled GeonameData struct</returns>
        public static GeoNamesData GetGeoname(Geo.Coordinates coords)
        {
            try
            {

                XmlDocument GeonameXML = new XmlDocument();
                GeoNamesData GeonameData = new GeoNamesData();
                System.Net.WebClient Client = new System.Net.WebClient();

                GeonameXML.LoadXml(Client.DownloadString(@"http://ws.geonames.org/findNearbyPlaceName?lat=" + coords.Latitude + "&lng=" + coords.Longitude));

                GeonameData.countryCode = GeonameXML.GetElementsByTagName("countryCode")[0].InnerText;
                GeonameData.countryName = GeonameXML.GetElementsByTagName("countryName")[0].InnerText;
                GeonameData.distance = GeonameXML.GetElementsByTagName("distance")[0].InnerText;
                GeonameData.fcl = GeonameXML.GetElementsByTagName("fcl")[0].InnerText;
                GeonameData.fcode = GeonameXML.GetElementsByTagName("fcode")[0].InnerText;
                GeonameData.geonameId = GeonameXML.GetElementsByTagName("geonameId")[0].InnerText;
                GeonameData.lat = GeonameXML.GetElementsByTagName("lat")[0].InnerText;
                GeonameData.lng = GeonameXML.GetElementsByTagName("lng")[0].InnerText;
                GeonameData.name = GeonameXML.GetElementsByTagName("name")[0].InnerText;

                return GeonameData;

            }
            catch (Exception)
            {
                return new GeoNamesData();
            }
        }


        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">Another object to compare to.</param>
        /// <returns>true if obj and this instance are the same type and represent the same value; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Returns the fully qualified type name of this instance.
        /// </summary>
        /// <returns>A System.String containing a fully qualified type name.</returns>
        public override string ToString()
        {
            return base.ToString();
        }

        /// <summary>
        /// GeoNamesData struct
        /// </summary>
        public struct GeoNamesData : IGeonameData
        {
            #region ISpatialGeoname Members

            private string _name;
            /// <summary>
            /// Location Name
            /// </summary>
            public string name
            {
                get
                {
                    return _name;
                }
                set
                {
                    _name = value;
                }
            }

            private string _lat;
            /// <summary>
            /// Location Latitude
            /// </summary>
            public string lat
            {
                get
                {
                    return _lat;
                }
                set
                {
                    _lat = value;
                }
            }

            private string _lng;
            /// <summary>
            /// Location Longitude
            /// </summary>
            public string lng
            {
                get
                {
                    return _lng;
                }
                set
                {
                    _lng = value;
                }
            }

            private string _geonameId;
            /// <summary>
            /// Location Geo Name ID (Unique identifier)
            /// </summary>
            public string geonameId
            {
                get
                {
                    return _geonameId;
                }
                set
                {
                    _geonameId = value;
                }
            }

            private string _countryCode;
            /// <summary>
            /// Location Country Code
            /// </summary>
            public string countryCode
            {
                get
                {
                    return _countryCode;
                }
                set
                {
                    _countryCode = value;
                }
            }

            private string _countryName;
            /// <summary>
            /// Location Country Name
            /// </summary>
            public string countryName
            {
                get
                {
                    return _countryName;
                }
                set
                {
                    _countryName = value;
                }
            }

            private string _fcl;
            /// <summary>
            /// Unknown Data
            /// </summary>
            public string fcl
            {
                get
                {
                    return _fcl;
                }
                set
                {
                    _fcl = value;
                }
            }

            private string _fcode;
            /// <summary>
            /// Unknown Data
            /// </summary>
            public string fcode
            {
                get
                {
                    return _fcode;
                }
                set
                {
                    _fcode = value;
                }
            }

            private string _distance;
            /// <summary>
            /// Unknown Data
            /// </summary>
            public string distance
            {
                get
                {
                    return _distance;
                }
                set
                {
                    _distance = value;
                }
            }

            #endregion
        }
    }
}
