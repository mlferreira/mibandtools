using WatchFace.Parser.Attributes;
using WatchFace.Parser.Elements.BasicElements;

namespace WatchFace.Parser.Elements
{
    public class BatteryText
    {
        [ParameterId(1)]
        public ImageBoxObject Coordinates { get; set; }
        
        // TODO: check id
        [ParameterId(3)]
        [ParameterImageIndex]
        public long? PrefixImageIndex { get; set; }
        
        [ParameterId(4)]
        [ParameterImageIndex]
        public long SuffixImageIndex { get; set; }
    }
}