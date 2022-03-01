using Newtonsoft.Json;
using WatchFace.Parser.Attributes;
using WatchFace.Parser.Elements.BasicElements;
using WatchFace.Parser.Elements.TimeElements;
using WatchFace.Parser.JsonConverters;

namespace WatchFace.Parser.Elements
{
    public class Other
    {
        [ParameterId(1)]
        public AnimationObject[] Animation { get; set; }

        [ParameterId(2)]
        public long Unknown2 { get; set; }

        [ParameterId(3)]
        public long Unknown3 { get; set; }

        [ParameterId(4)]
        public long Unknown4 { get; set; }

        [ParameterId(5)]
        public long Unknown5 { get; set; }
    }
}