using System.Drawing;
using WatchFace.Parser.Interfaces;

namespace WatchFace.Parser.Models.Elements
{
    public class SeparateMonthAndDayElement : CompositeElement, IDrawable
    {
        public SeparateMonthAndDayElement(Parameter parameter, Element parent = null, string name = null) :
            base(parameter, parent, name) { }

        public ImageBoxElement Month { get; set; }
        public ImageBoxElement Day { get; set; }
        public ImageBoxElement Year { get; set; }

        public void Draw(Graphics drawer, Bitmap[] resources, WatchState state)
        {
            var monthAndDay = (MonthAndDayAndYearElement) _parent;
            Month?.Draw(drawer, resources, state.Time.Month, monthAndDay.TwoDigitsMonth ? 2 : 1);
            Day?.Draw(drawer, resources, state.Time.Day, monthAndDay.TwoDigitsDay ? 2 : 1);
        }

        protected override Element CreateChildForParameter(Parameter parameter)
        {
            switch (parameter.Id)
            {
                case 1:
                    Month = new ImageBoxElement(parameter, this);
                    return Month;
                // case 3:
                case 4:
                    Day = new ImageBoxElement(parameter, this);
                    return Day;
                default:
                    return base.CreateChildForParameter(parameter);
            }
        }
    }
}