using WatchFace.Parser.Attributes;

namespace WatchFace.Parser.Elements.BasicElements
{
    public class ImageObject : CoordinatesObject
    {
        [ParameterId(3)]
        [ParameterImageIndex]
        public long ImageIndex { get; set; }
    }
}