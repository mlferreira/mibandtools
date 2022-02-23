namespace WatchFace.Parser.Models.Elements
{
    public class DateElement : ContainerElement
    {
        public DateElement(Parameter parameter, Element parent = null, string name = null) :
            base(parameter, parent, name) { }

        public MonthAndDayAndYearElement MonthAndDayAndYear { get; set; }
        public DayAmPmElement DayAmPm { get; set; }
        public WeekDayElement WeekDay { get; set; }

        protected override Element CreateChildForParameter(Parameter parameter)
        {
            switch (parameter.Id)
            {
                case 1:
                    MonthAndDayAndYear = new MonthAndDayAndYearElement(parameter, this);
                    return MonthAndDayAndYear;
                case 2:
                    DayAmPm = new DayAmPmElement(parameter, this);
                    return DayAmPm;
                case 4:
                case 5:
                case 6:
                    WeekDay = new WeekDayElement(parameter, this);
                    return WeekDay;
                default:
                    return base.CreateChildForParameter(parameter);
            }
        }
    }
}