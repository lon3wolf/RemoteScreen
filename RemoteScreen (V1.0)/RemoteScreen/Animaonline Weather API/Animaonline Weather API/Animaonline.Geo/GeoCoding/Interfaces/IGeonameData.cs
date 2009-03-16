using System;
namespace Animaonline.Geo.GeoCoding
{
    interface IGeonameData
    {
        string countryCode { get; set; }
        string countryName { get; set; }
        string distance { get; set; }
        string fcl { get; set; }
        string fcode { get; set; }
        string geonameId { get; set; }
        string lat { get; set; }
        string lng { get; set; }
        string name { get; set; }
    }
}
