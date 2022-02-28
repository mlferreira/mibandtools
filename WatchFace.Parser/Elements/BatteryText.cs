using WatchFace.Parser.Attributes;
using WatchFace.Parser.Elements.BasicElements;

namespace WatchFace.Parser.Elements
{
    public class BatteryText
    {
        [ParameterId(1)]
        public ImageBoxObject Coordinates { get; set; }

        [ParameterId(4)]
        public long SuffixImageIndex { get; set; }
    }
}