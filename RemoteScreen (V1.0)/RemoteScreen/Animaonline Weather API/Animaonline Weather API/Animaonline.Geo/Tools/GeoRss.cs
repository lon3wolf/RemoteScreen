using System;
using System.IO;
using System.Text;
using System.Xml;

namespace Animaonline.Geo.Tools
{
    /// <summary>
    /// Generates GeoRss
    /// </summary>
    public class GeoRss
    {
        /// <summary>
        /// Generates GeoRss
        /// </summary>
        public struct GeoRssData
        {

            /// <summary>
            /// Generates GeoRss
            /// </summary>
            /// <param name="ItemDescription">Item Description</param>
            /// <param name="ItemLatitude">Item Latitude</param>
            /// <param name="ItemLongitude">Item Longitude</param>
            /// <param name="ItemTitle">Item Title</param>
            /// <param name="ItemLink">Item Link</param>
            /// <param name="ItemPubDate">Item Publication Date</param>
            /// <param name="ItemCategory">Item Category</param>
            public GeoRssData(string ItemDescription, string ItemLatitude, string ItemLongitude, string ItemTitle, string ItemLink, DateTime ItemPubDate, string ItemCategory)
            {
                description = ItemDescription;
                lat = ItemLatitude;
                lng = ItemLongitude;
                title = ItemTitle;
                link = ItemLink;
                pubDate = ItemPubDate;
                category = ItemCategory;
            }

            private string description, lat, lng, title, link, category;
            private DateTime pubDate;

            /// <summary>
            /// Item Description
            /// </summary>
            public string Description
            {
                get { return description; }
                set { description = value; }
            }

            /// <summary>
            /// Item Latitude
            /// </summary>
            public string Lat
            {
                get { return lat; }
                set { lat = value; }
            }

            /// <summary>
            /// Item Longitude
            /// </summary>
            public string Lng
            {
                get { return lng; }
                set { lng = value; }
            }

            /// <summary>
            /// Item Title
            /// </summary>
            public string Title
            {
                get { return title; }
                set { title = value; }
            }

            /// <summary>
            /// Item Link
            /// </summary>
            public string Link
            {
                get { return link; }
                set { link = value; }
            }

            /// <summary>
            /// Item Publication Date
            /// </summary>
            public DateTime PubDate
            {
                get { return pubDate; }
                set { pubDate = value; }
            }

            /// <summary>
            /// Item Category
            /// </summary>
            public string Category
            {
                get { return category; }
                set { category = value; }
            }

            /// <summary>
            /// Returns a System.String that represents the current GeoRssData
            /// </summary>
            /// <returns>A System.String that represents the current GeoRssData</returns>
            public override string ToString()
            {
                GeoRss iGR = new GeoRss();
                return iGR.GenerateRSS(this);
            }

            /// <summary>
            /// Generates GeoRss for a single GeoRssData object
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public string GenerateRSS()
            {
                GeoRss gR = new GeoRss();
                GeoRssData gD = new GeoRssData(Description, Lat, Lng, Title, Link, PubDate, Category);
                return gR.GenerateRSS(gD);
            }
        }

        private readonly MemoryStream stream = new MemoryStream();
        private XmlTextWriter GeoRssWriter;

        /// <summary>
        /// Generates GeoRss for a single GeoRssData object
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public string GenerateRSS(GeoRssData item)
        {
            GeoRssData[] temp = new GeoRssData[1];
            temp[0] = item;
            return GenerateRSS(temp);
        }

        /// <summary>
        /// Generates GeoRss for all the items in a GeoRssData[] array
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public string GenerateRSS(GeoRssData[] items)
        {
            GeoRssWriter = new XmlTextWriter(stream, Encoding.UTF8);

            GeoRssWriter.WriteStartDocument();
            GeoRssWriter.WriteWhitespace(Environment.NewLine);
            GeoRssWriter.WriteStartElement("rss");
            GeoRssWriter.WriteAttributeString("version", "2.0");
            GeoRssWriter.WriteAttributeString("xmlns:georss", "http://www.georss.org/georss");
            GeoRssWriter.WriteAttributeString("xmlns:gml", "http://www.opengis.net/gml");
            GeoRssWriter.WriteWhitespace(Environment.NewLine);

            GeoRssWriter.WriteStartElement("channel");
            GeoRssWriter.WriteWhitespace(Environment.NewLine);
            GeoRssWriter.WriteElementString("generator", "Animaonline.GeoServices.GeoRss");
            GeoRssWriter.WriteWhitespace(Environment.NewLine);
            GeoRssWriter.WriteElementString("title", "Animaonline Weather API Feed");
            GeoRssWriter.WriteWhitespace(Environment.NewLine);
            GeoRssWriter.WriteElementString("language", "en-us");
            GeoRssWriter.WriteWhitespace(Environment.NewLine);

            for (int i = 0; i < items.Length; i++)
            {
                GeoRssWriter.WriteStartElement("item");
                GeoRssWriter.WriteWhitespace(Environment.NewLine);
                GeoRssWriter.WriteElementString("title", items[i].Title);
                GeoRssWriter.WriteWhitespace(Environment.NewLine);


                GeoRssWriter.WriteElementString("link", items[i].Link);
                GeoRssWriter.WriteWhitespace(Environment.NewLine);

                GeoRssWriter.WriteElementString("pubdate", items[i].PubDate.ToString());
                GeoRssWriter.WriteWhitespace(Environment.NewLine);

                GeoRssWriter.WriteElementString("category", items[i].Category);
                GeoRssWriter.WriteWhitespace(Environment.NewLine);

                GeoRssWriter.WriteElementString("description", items[i].Description);
                GeoRssWriter.WriteWhitespace(Environment.NewLine);
                GeoRssWriter.WriteElementString("georss:point", items[i].Lat + " " + items[i].Lng);
                GeoRssWriter.WriteWhitespace(Environment.NewLine);
                GeoRssWriter.WriteEndElement();
                GeoRssWriter.WriteWhitespace(Environment.NewLine);
            }

            GeoRssWriter.WriteEndElement();
            GeoRssWriter.WriteWhitespace(Environment.NewLine);
            GeoRssWriter.WriteEndElement();
            GeoRssWriter.WriteWhitespace(Environment.NewLine);
            GeoRssWriter.WriteEndDocument();
            GeoRssWriter.Flush();

            StreamReader reader;
            stream.Position = 0;
            reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}