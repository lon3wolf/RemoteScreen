using System;
using System.Collections.Generic;
using System.Text;

namespace Animaonline.Geo.Maps
{
    /// <summary>
    /// Generates a map by using Google Maps API
    /// </summary>
    public class GoogleMapGenerator
    {
        /// <summary>
        /// Generates a map by using Google Maps API
        /// </summary>
        public class GoogleMap : IGoogleMap
        {
            /// <summary>
            /// Generates a map by using Google Maps API
            /// </summary>
            /// <param name="latitude">Map center Latitude</param>
            /// <param name="longitude">Map center Longitude</param>
            /// <param name="bubbleData">Map Message</param>
            /// <param name="Width">Map Width</param>
            /// <param name="Height">Map Height</param>
            /// <param name="zoomLevel">Map Zoom Level, 11 Is the default value.</param>
            public GoogleMap(string latitude, string longitude, string bubbleData, int Width, int Height, int zoomLevel)
            {
                Latitude = latitude;
                Longitude = longitude;
                BubbleData = bubbleData;
                MapWidth = Width;
                MapHeight = Height;
                ZoomLevel = zoomLevel;
            }

            /// <summary>
            /// Saves the generated map to the specified Path
            /// </summary>
            /// <param name="Path">The Path where the Map will be saved</param>
            public void SaveMap(string Path)
            {
                try
                {
                    System.IO.File.WriteAllText(Path, MapHtml);
                }
                catch (Exception SaveMapException)
                {
                    throw SaveMapException;
                }
            }

            #region ISpatialMap Members
            private string _latitude;
            private string _longitude;
            private string _BubbleData;
            private string _MapHtml;
            private int _MapHeight;
            private int _MapWidth;
            private int _ZoomLevel;

            /// <summary>
            /// Map center Latitude
            /// </summary>
            public string Latitude
            {
                get
                {
                    return _latitude;
                }
                set
                {
                    _latitude = value;
                }
            }
            /// <summary>
            /// Map center Longitude
            /// </summary>
            public string Longitude
            {
                get
                {
                    return _longitude;
                }
                set
                {
                    _longitude = value;
                }
            }

            /// <summary>
            /// Map Message
            /// </summary>
            public string BubbleData
            {
                get
                {
                    return _BubbleData;
                }
                set
                {
                    _BubbleData = value;
                }
            }

            /// <summary>
            /// Map Html
            /// </summary>
            public string MapHtml
            {
                get
                {
                    _MapHtml = Properties.Resources.MapTemplate.Replace(GeneratorConstantVariables.LATITUDETAG, Latitude);
                    _MapHtml = _MapHtml.Replace(GeneratorConstantVariables.LONGITUDETAG, Longitude);
                    _MapHtml = _MapHtml.Replace(GeneratorConstantVariables.BUBBLEDATATAG, BubbleData);
                    _MapHtml = _MapHtml.Replace(GeneratorConstantVariables.MAPWIDTHTAG, MapWidth.ToString());
                    _MapHtml = _MapHtml.Replace(GeneratorConstantVariables.MAPHEIGHTTAG, MapHeight.ToString());
                    _MapHtml = _MapHtml.Replace(GeneratorConstantVariables.DATETIMENOWTAG, DateTime.Now.ToString());
                    _MapHtml = _MapHtml.Replace(GeneratorConstantVariables.ZOOMLEVELTAG, ZoomLevel.ToString());
                    return _MapHtml;
                }
            }

            /// <summary>
            /// Map Width
            /// </summary>
            public int MapWidth
            {
                get
                {
                    return _MapWidth;
                }
                set
                {
                    _MapWidth = value;
                }
            }

            /// <summary>
            /// Map Height
            /// </summary>
            public int MapHeight
            {
                get
                {
                    return _MapHeight;
                }
                set
                {
                    _MapHeight = value;
                }
            }

            /// <summary>
            /// Map Zoom Level, 11 Is the default value.
            /// </summary>
            public int ZoomLevel
            {
                get
                {
                    return _ZoomLevel;
                }
                set
                {
                    _ZoomLevel = value;
                }
            }

            #endregion
        }
    }
}
