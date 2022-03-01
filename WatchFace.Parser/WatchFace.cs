using WatchFace.Parser.Attributes;
using WatchFace.Parser.Elements;

namespace WatchFace.Parser
{
    public class WatchFace
    {
        [ParameterId(2)]
        public Background Background { get; set; }

        [ParameterId(3)]
        public Time Time { get; set; }

        [ParameterId(4)]
        public Activity Activity { get; set; }

        [ParameterId(5)]
        public Date Date { get; set; }

        [ParameterId(6)]
        public Weather Weather { get; set; }

        [ParameterId(7)]
        public ProgressObject StepsProgress { get; set; }

        [ParameterId(8)]
        public Status Status { get; set; }

        [ParameterId(9)]
        public Battery Battery { get; set; }

        [ParameterId(10)]
        public AnalogDialFace AnalogDialFace { get; set; }
        
        [ParameterId(11)]
        public Other Other { get; set; }

        [ParameterId(12)]
        public ProgressObject HeartProgress { get; set; }

        [ParameterId(13)]
        public UnknownType14 Unknown13 { get; set; }
        
        [ParameterId(14)]
        public UnknownType14 Unknown14 { get; set; }
        
        [ParameterId(15)]
        public ProgressObject CaloriesProgress { get; set; }
        
        [ParameterId(18)]
        public Alarm Alarm { get; set; }
        
        [ParameterId(18)]
        public LunarDate LunarDateCN1 { get; set; }
    }
}