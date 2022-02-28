using WatchFace.Parser.Attributes;
using WatchFace.Parser.Elements.BasicElements;

namespace WatchFace.Parser.Elements.WeatherElements
{
    public class AirPollution
    {
        [ParameterId(1)]
        public ImageBoxObject Index { get; set; }

        [ParameterId(2)]
        public ImageSetObject Icon { get; set; }
    }
}