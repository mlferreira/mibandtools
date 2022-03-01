using Newtonsoft.Json;
using WatchFace.Parser.Attributes;
using WatchFace.Parser.Elements.BasicElements;
using WatchFace.Parser.Elements.TimeElements;
using WatchFace.Parser.JsonConverters;

namespace WatchFace.Parser.Elements
{
    public class Alarm
    {
        [ParameterId(1)]
        public ImageBoxObject Text { get; set; }

        [ParameterId(2)]
        public long? DelimiterImageIndex { get; set; }

        [ParameterId(3)]
        public ImageObject ImageOn { get; set; }
        
        [ParameterId(4)]
        public ImageObject ImageOff { get; set; }
        
        [ParameterId(5)]
        public ImageObject ImageNoAlarm { get; set; }

        [ParameterId(6)]
        public long? UnknownTF6 { get; set; }

        [ParameterId(7)]
        public long? UnknownTF7 { get; set; }
    }
}