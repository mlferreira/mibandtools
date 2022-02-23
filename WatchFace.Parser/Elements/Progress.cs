using WatchFace.Parser.Attributes;
using WatchFace.Parser.Elements.BasicElements;

namespace WatchFace.Parser.Elements
{
    public class Progress
    {
        [ParameterId(1)]
        public Image GoalImage { get; set; }

        [ParameterId(2)]
        public ImageSet LineScale { get; set; }

        [ParameterId(3)]
        public CircleScale Circle { get; set; }
    }
}