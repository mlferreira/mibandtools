using System.Collections.Generic;

namespace WatchFace.Parser.Models.Elements
{
    public class WatchFace : ContainerElement
    {
        public WatchFace(IEnumerable<Parameter> parameters) : base(parameters) { }

        public BackgroundElement Background { get; set; }
        public TimeElement Time { get; set; }
        public ActivityElement Activity { get; set; }
        public DateElement Date { get; set; }
        public WeatherElement Weather { get; set; }
        public GoalProgressElement StepsProgress { get; set; }
        public StatusElement Status { get; set; }
        public BatteryElement Battery { get; set; }
        public AnalogDialElement AnalogDial { get; set; }
        public GoalProgressElement HeartProgress { get; set; }
        public GoalProgressElement CaloriesProgress { get; set; }

        protected override Element CreateChildForParameter(Parameter parameter)
        {
            switch (parameter.Id)
            {
                case 2:
                    Background = new BackgroundElement(parameter);
                    return Background;
                case 3:
                    Time = new TimeElement(parameter);
                    return Time;
                case 4:
                    Activity = new ActivityElement(parameter);
                    return Activity;
                case 5:
                    Date = new DateElement(parameter);
                    return Date;
                case 6:
                    Weather = new WeatherElement(parameter);
                    return Weather;
                case 7:
                    StepsProgress = new GoalProgressElement(parameter);
                    return StepsProgress;
                case 8:
                    Status = new StatusElement(parameter);
                    return Status;
                case 9:
                    Battery = new BatteryElement(parameter);
                    return Battery;
                case 10:
                    AnalogDial = new AnalogDialElement(parameter);
                    return AnalogDial;
                case 12:
                    HeartProgress = new GoalProgressElement(parameter);
                    return HeartProgress;
                case 15:
                    CaloriesProgress = new GoalProgressElement(parameter);
                    return CaloriesProgress;
                default:
                    return base.CreateChildForParameter(parameter);
            }
        }
    }
}