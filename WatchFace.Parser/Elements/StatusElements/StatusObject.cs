using WatchFace.Parser.Attributes;
using WatchFace.Parser.Elements.BasicElements;

namespace WatchFace.Parser.Elements.StatusElements
{
    public class StatusObject
    {
        [ParameterId(1)]
        public CoordinatesObject Coordinates { get; set; }

        [ParameterId(2)]
        [ParameterImageIndex]
        public long? ImageIndexOn { get; set; }

        [ParameterId(3)]
        [ParameterImageIndex]
        public long? ImageIndexOff { get; set; }
    }
}