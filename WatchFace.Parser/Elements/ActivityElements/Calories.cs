using WatchFace.Parser.Attributes;
using WatchFace.Parser.Elements.BasicElements;

namespace WatchFace.Parser.Elements.ActivityElements
{
    public class Calories
    {
        [ParameterId(1)]
        public ComposedElement Text { get; set; }

        [ParameterId(2)]
        [ParameterImageIndex]
        public long? SuffixImageIndex { get; set; }

        [ParameterId(3)]
        [ParameterImageIndex]
        public long? PrefixImageIndex { get; set; }
    }
}