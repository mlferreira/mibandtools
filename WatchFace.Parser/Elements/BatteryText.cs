using WatchFace.Parser.Attributes;
using WatchFace.Parser.Elements.BasicElements;

namespace WatchFace.Parser.Elements
{
    public class BatteryText
    {
        [ParameterId(1)]
        public ComposedElement Coordinates { get; set; }

        [ParameterId(4)]
        public long SuffixImageIndex { get; set; }
    }
}