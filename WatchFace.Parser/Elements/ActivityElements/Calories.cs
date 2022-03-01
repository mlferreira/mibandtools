using WatchFace.Parser.Attributes;
using WatchFace.Parser.Elements.BasicElements;

namespace WatchFace.Parser.Elements.ActivityElements
{
    public class Calories : TextBoxObject
    {
        [ParameterId(3)]
        [ParameterImageIndex]
        public long? PrefixImageIndex { get; set; }
    }
}