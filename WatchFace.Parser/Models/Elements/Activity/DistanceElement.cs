using System.Drawing;
using WatchFace.Parser.Helpers;
using WatchFace.Parser.Interfaces;

namespace WatchFace.Parser.Models.Elements
{
    public class DistanceElement : CompositeElement, IDrawable
    {
        public DistanceElement(Parameter parameter, Element parent, string name= null) :
            base(parameter, parent, name) { }

        public ImageBoxElement Number { get; set; }
        public long KilometerImageIndex { get; set; }
        public long DecimalPointImageIndex { get; set; }
        public long MilesSuffixImageIndex { get; set; }


        public void Draw(Graphics drawer, Bitmap[] resources, WatchState state)
        {
            var kilometers = state.Distance / 1000;
            var decimals = state.Distance % 1000 / 10;

            var images = Number.GetImagesForNumber(resources, kilometers);
            images.Add(resources[DecimalPointImageIndex]);
            images.AddRange(Number.GetImagesForNumber(resources, decimals));
            images.Add(resources[KilometerImageIndex]);

            // TODO: km vs miles?
            // TODO how to deal with 2 spacings values
            // DrawerHelper.DrawImages(drawer, images, (int) Number.Spacing, Number.Alignment, Number.GetBox());
            DrawerHelper.DrawImages(drawer, images, (int) Number.SpacingX, Number.Alignment, Number.GetBox());
        }

        protected override Element CreateChildForParameter(Parameter parameter)
        {
            switch (parameter.Id)
            {
                case 1:
                    Number = new ImageBoxElement(parameter, this, nameof(Number));
                    return Number;
                case 2:
                    KilometerImageIndex = parameter.Value;
                    return new ValueElement(parameter, this, nameof(KilometerImageIndex));
                case 3:
                    DecimalPointImageIndex = parameter.Value;
                    return new ValueElement(parameter, this, nameof(DecimalPointImageIndex));
                case 4:
                    MilesSuffixImageIndex = parameter.Value;
                    return new ValueElement(parameter, this, nameof(DecimalPointImageIndex));
                default:
                    return base.CreateChildForParameter(parameter);
            }
        }
    }
}