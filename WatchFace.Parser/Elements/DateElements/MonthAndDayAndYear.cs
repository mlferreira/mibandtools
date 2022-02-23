using WatchFace.Parser.Attributes;
using WatchFace.Parser.Elements.BasicElements;

namespace WatchFace.Parser.Elements.DateElements
{
    public class MonthAndDayAndYear
    {
        [ParameterId(1)]
        public SeparateMonthAndDay Separate { get; set; }

        [ParameterId(2)]
        public OneLineMonthAndDay OneLine { get; set; }

        [ParameterId(4)]
        public bool TwoDigitsMonth { get; set; }

        [ParameterId(5)]
        public bool TwoDigitsDay { get; set; }
        
    }
}