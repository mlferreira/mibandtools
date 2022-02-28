using WatchFace.Parser.Attributes;
using WatchFace.Parser.Elements.BasicElements;

namespace WatchFace.Parser.Elements
{
    public class Progress
    {
        [ParameterId(1)]
        public ImageObject GoalImage { get; set; }

        [ParameterId(2)]
        public ImageSetObject LineScale { get; set; }

        [ParameterId(3)]
        public CircleScale Circle { get; set; }
    }
}