using WatchFace.Parser.Attributes;
using WatchFace.Parser.Elements.BasicElements;

namespace WatchFace.Parser.Elements.DateElements
{
    public class OneLineMonthAndDay
    {
        [ParameterId(1)]
        public ImageBoxObject ComposedElement { get; set; }

        [ParameterId(2)]
        [ParameterImageIndex]
        public long DelimiterImageIndex { get; set; }
    }
}