using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using WatchFace.Parser.Attributes;
using WatchFace.Parser.Models;

namespace WatchFace.Parser.Elements.BasicElements
{
    public class ImageBoxObject
    {
        [ParameterId(1)]
        public long TopLeftX { get; set; }

        [ParameterId(2)]
        public long TopLeftY { get; set; }

        [ParameterId(3)]
        public long BottomRightX { get; set; }

        [ParameterId(4)]
        public long BottomRightY { get; set; }

        [ParameterId(5)]
        [JsonConverter(typeof(StringEnumConverter))]
        public TextAlignment Alignment { get; set; }

        [ParameterId(6)]
        public long SpacingX { get; set; }
        
        [ParameterId(7)]
        public long SpacingY { get; set; }

        [ParameterId(8)]
        [ParameterImageIndex]
        public long ImageIndex { get; set; }

        [ParameterId(9)]
        [ParameterImagesCount]
        public long ImagesCount { get; set; }
    }
}