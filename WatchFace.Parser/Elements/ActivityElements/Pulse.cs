using WatchFace.Parser.Attributes;
using WatchFace.Parser.Elements.BasicElements;

namespace WatchFace.Parser.Elements.ActivityElements
{
    public class Pulse
    {
        [ParameterId(1)]
        public ComposedElement Number { get; set; }

        [ParameterId(2)]
        [ParameterImageIndex]
        public long? Unknown2 { get; set; }

        [ParameterId(3)]
        [ParameterImageIndex]
        public long? NoDataImageIndex { get; set; }
    }
}