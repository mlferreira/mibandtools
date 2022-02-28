using WatchFace.Parser.Attributes;
using WatchFace.Parser.Elements.BasicElements;

namespace WatchFace.Parser.Elements.TimeElements
{
    public class TwoDigits
    {
        [ParameterId(1)]
        public ImageSetObject Tens { get; set; }

        [ParameterId(2)]
        public ImageSetObject Ones { get; set; }
    }
}