using WatchFace.Parser.Attributes;
using WatchFace.Parser.Elements.BasicElements;

namespace WatchFace.Parser.Elements.ActivityElements
{
    public class PulseObject : ActivityBaseObject
    {
        [ParameterId(2)]
        [ParameterImageIndex]
        public long? Unknown2 { get; set; }

        [ParameterId(3)]
        [ParameterImageIndex]
        public long? NoDataImageIndex { get; set; }
        
        [ParameterId(4)]
        [ParameterImageIndex]
        public long? SuffixImageIndex { get; set; }
    }
}