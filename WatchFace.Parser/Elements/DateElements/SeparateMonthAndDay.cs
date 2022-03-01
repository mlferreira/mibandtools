using WatchFace.Parser.Attributes;
using WatchFace.Parser.Elements.BasicElements;

namespace WatchFace.Parser.Elements.DateElements
{
    public class SeparateMonthAndDay
    {
        [ParameterId(1)]
        public ImageBoxObject Month { get; set; }
        
        [ParameterId(2)]
        public ImageSetObject MonthsEN { get; set; }
        
        [ParameterId(3)]
        public ImageSetObject MonthsCN { get; set; }

        [ParameterId(4)]
        public ImageBoxObject Day { get; set; }
    }
}