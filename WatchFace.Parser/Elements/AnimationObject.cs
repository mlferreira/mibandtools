using Newtonsoft.Json;
using WatchFace.Parser.Attributes;
using WatchFace.Parser.Elements.BasicElements;
using WatchFace.Parser.Elements.TimeElements;
using WatchFace.Parser.JsonConverters;

namespace WatchFace.Parser.Elements
{
    public class AnimationObject
    {
        [ParameterId(1)]
        public ImageSetObject AnimationImages { get; set; }

        [ParameterId(2)]
        public long? Speed { get; set; }

        [ParameterId(3)]
        public long? RepeatCount { get; set; }

        [ParameterId(4)]
        public long? UnknownTF4 { get; set; }
    }
}