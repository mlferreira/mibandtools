using System.Collections.Generic;
using WatchFace.Parser.Attributes;

namespace WatchFace.Parser.Elements
{
    public class Other
    {
        [ParameterId(1)]
        public List<AnimationObject> Animation { get; set; }
    }
}