using WatchFace.Parser.Attributes;

namespace WatchFace.Parser.Elements.BasicElements
{
    public class ImageSetObject : ImageObject
    {
        [ParameterId(4)]
        [ParameterImagesCount]
        public long ImagesCount { get; set; }
    }
}