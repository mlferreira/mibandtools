using WatchFace.Parser.Attributes;
using WatchFace.Parser.Elements.BasicElements;

namespace WatchFace.Parser.Elements
{
    public class LunarDate
    {
        [ParameterId(1)]
        public ImageSetObject LunarMonth { get; set; }

        [ParameterId(2)]
        public ImageBoxObject LunarDay1 { get; set; }

        [ParameterId(3)]
        [ParameterImageIndex]
        public long LunarDayOf0X { get; set; }
        
        [ParameterId(4)]
        [ParameterImageIndex]
        public long LunarDayOf2X { get; set; }
        
        [ParameterId(5)]
        [ParameterImageIndex]
        public long LunarDayOf10 { get; set; }

        [ParameterId(6)]
        [ParameterImageIndex]
        public long LunarDayOf20 { get; set; }

        [ParameterId(7)]
        [ParameterImageIndex]
        public long LunarDayOf30 { get; set; }
    }
}