using System.Drawing;
using WatchFace.Parser.Helpers;
using WatchFace.Parser.Interfaces;

namespace WatchFace.Parser.Models.Elements.Battery
{
    public class BatteryNumberElement : ImageBoxElement, IDrawable
    {
        public BatteryNumberElement(Parameter parameter, Element parent, string name = null) :
            base(parameter, parent, name) { }

        public ImageBoxElement Coordinates { get; set; }
        public long SuffixImageIndex { get; set; }

        public void Draw(Graphics drawer, Bitmap[] resources, WatchState state)
        {
            var images = Coordinates.GetImagesForNumber(resources, state.BatteryLevel);
            
            images.Add(resources[SuffixImageIndex]);

            // TODO how to deal with 2 spacings values
            // DrawerHelper.DrawImages(drawer, images, (int) Coordinates.Spacing, Coordinates.Alignment, Coordinates.GetBox());
            DrawerHelper.DrawImages(drawer, images, (int) Coordinates.SpacingX, Coordinates.Alignment, Coordinates.GetBox());
        }
        
        protected override Element CreateChildForParameter(Parameter parameter)
        {
            switch (parameter.Id)
            {
                case 1:
                    Coordinates = new ImageBoxElement(parameter, this);
                    return Coordinates;
                case 4:
                    SuffixImageIndex = parameter.Value;
                    return new ValueElement(parameter, this);
                default:
                    return base.CreateChildForParameter(parameter);
            }
        }
    }
}