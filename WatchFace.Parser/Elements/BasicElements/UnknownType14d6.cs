using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using WatchFace.Parser.Attributes;
using WatchFace.Parser.Models;

namespace WatchFace.Parser.Elements.BasicElements
{
    public class UnknownType14d6
    {
        [ParameterId(1)]
        public CoordinatesObject Unknown1 { get; set; }

        [ParameterId(2)]
        public CoordinatesObject Unknown2 { get; set; }

        [ParameterId(3)]
        public long? Unknown3 { get; set; }
    }
}