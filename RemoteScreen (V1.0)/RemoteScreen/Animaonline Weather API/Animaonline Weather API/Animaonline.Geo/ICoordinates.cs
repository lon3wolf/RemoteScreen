using System;
namespace Animaonline.Geo.Interfaces
{
    public interface ICoordinates
    {
        decimal Latitude { get; set; }
        decimal Longitude { get; set; }
        string ToString();
    }
}
