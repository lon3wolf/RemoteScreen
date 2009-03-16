using System;
namespace Animaonline.Geo
{
    interface IGoogleMap
    {
        string BubbleData { get; set; }
        string Latitude { get; set; }
        string Longitude { get; set; }
        int MapHeight { get; set; }
        string MapHtml { get; }
        int MapWidth { get; set; }
        void SaveMap(string Path);
        int ZoomLevel { get; set; }
    }
}
