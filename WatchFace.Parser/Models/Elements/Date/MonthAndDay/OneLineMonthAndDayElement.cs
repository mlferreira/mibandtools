using System.Drawing;
using WatchFace.Parser.Helpers;
using WatchFace.Parser.Interfaces;

namespace WatchFace.Parser.Models.Elements
{
    public class OneLineMonthAndDayElement : CompositeElement, IDrawable
    {
        public OneLineMonthAndDayElement(Parameter parameter, Element parent = null, string name = null) :
            base(parameter, parent, name) { }

        public ImageBoxElement Number { get; set; }
        public long DelimiterImageIndex { get; set; }

        public void Draw(Graphics drawer, Bitmap[] resources, WatchState state)
        {
            var monthAndDay = (MonthAndDayElement) _parent;

            var images = Number.GetImagesForNumber(resources, state.Time.Month, monthAndDay.TwoDigitsMonth ? 2 : 1);
            images.Add(resources[DelimiterImageIndex]);
            images.AddRange(Number.GetImagesForNumber(resources, state.Time.Day, monthAndDay.TwoDigitsDay ? 2 : 1));

            // TODO how to deal with 2 spacings values
            // DrawerHelper.DrawImages(drawer, images, (int) Number.Spacing, Number.Alignment, Number.GetBox());
            DrawerHelper.DrawImages(drawer, images, (int) Number.SpacingX, Number.Alignment, Number.GetBox());
        }

        protected override Element CreateChildForParameter(Parameter parameter)
        {
            switch (parameter.Id)
            {
                case 1:
                    Number = new ImageBoxElement(parameter, this);
                    return Number;
                case 2:
                    DelimiterImageIndex = parameter.Value;
                    return new ValueElement(parameter, this);
                default:
                    return base.CreateChildForParameter(parameter);
            }
        }
    }
}