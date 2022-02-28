using WatchFace.Parser.Attributes;
using WatchFace.Parser.Elements.BasicElements;
using WatchFace.Parser.Elements.DateElements;

namespace WatchFace.Parser.Elements
{
    public class Date
    {
        [ParameterId(1)]
        public MonthAndDayAndYear MonthAndDayAndYear { get; set; }

        [ParameterId(2)]
        public DayAmPm DayAmPm { get; set; }

        [ParameterId(3)]
        public DateUnknown3 Unknown3 { get; set; }

        [ParameterId(4)]
        public ImageSetObject ENWeekDays { get; set; }
        
        [ParameterId(5)]
        public ImageSetObject CNWeekDays { get; set; }
        
        [ParameterId(6)]
        public ImageSetObject CN2WeekDays { get; set; }
    }
}