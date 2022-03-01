using WatchFace.Parser.Attributes;
using WatchFace.Parser.Elements.BasicElements;

namespace WatchFace.Parser.Elements
{
    public class ProgressObject
    {
        [ParameterId(1)]
        public ImageObject GoalImage { get; set; }

        [ParameterId(2)]
        public ImageSetObject LineScale { get; set; }

        [ParameterId(3)]
        public LinearScaleObject LinearScale { get; set; }
        
        [ParameterId(4)]
        public CircleScale CircleScale { get; set; }
    }
}