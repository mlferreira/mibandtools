using WatchFace.Parser.Attributes;
using WatchFace.Parser.Elements.BasicElements;

namespace WatchFace.Parser.Elements.ActivityElements
{
    public class FormattedNumber
    {
        [ParameterId(1)]
        public ComposedElement ComposedElement { get; set; }

        [ParameterId(2)]
        [ParameterImageIndex]
        public long? SuffixImageIndex { get; set; }

        [ParameterId(3)]
        [ParameterImageIndex]
        public long? DecimalPointImageIndex { get; set; }

        [ParameterId(4)]
        public long? SuffixMilesImageIndex { get; set; }
    }
}