using WatchFace.Parser.Attributes;

namespace WatchFace.Parser.Elements.ActivityElements
{
    public class StepsObject : ActivityBaseObject
    {
        [ParameterId(2)]
        [ParameterImageIndex]
        public long? Unknown2 { get; set; }

        [ParameterId(3)]
        [ParameterImageIndex]
        public long? NoDataImageIndex { get; set; }
    }
}