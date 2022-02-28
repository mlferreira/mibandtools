using WatchFace.Parser.Attributes;
using WatchFace.Parser.Elements.BasicElements;

namespace WatchFace.Parser.Elements.ActivityElements
{
    public class ActivityBaseObject
    {
        [ParameterId(1)]
        public ImageBoxObject Number { get; set; }
    }
}