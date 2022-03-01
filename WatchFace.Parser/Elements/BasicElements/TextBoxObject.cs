using WatchFace.Parser.Attributes;

namespace WatchFace.Parser.Elements.BasicElements
{
    public class TextBoxObject
    {
        [ParameterId(1)]
        public ImageBoxObject Text { get; set; }

        [ParameterId(2)]
        public long SuffixImageIndex { get; set; }
    }
}