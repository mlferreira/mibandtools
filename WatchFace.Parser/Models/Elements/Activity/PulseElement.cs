using System.Collections.Generic;
using System.Drawing;
using WatchFace.Parser.Helpers;
using WatchFace.Parser.Interfaces;

namespace WatchFace.Parser.Models.Elements
{
    public class PulseElement : CompositeElement, IDrawable
    {
        public PulseElement(Parameter parameter, Element parent = null, string name = null) :
            base(parameter, parent, name) { }
        
        public ImageBoxElement Number { get; set; }
        public long NoDataImageIndex { get; set; }

        public void Draw(Graphics drawer, Bitmap[] resources, WatchState state)
        {
            var images = new List<Bitmap>();

            if (state.Pulse != null)
            {
                images.AddRange(Number.GetImagesForNumber(resources, state.Pulse.Value));
            }
            else
            {
                images.Add(resources[NoDataImageIndex]);
            }

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
                case 3:
                    NoDataImageIndex = parameter.Value;
                    return new ValueElement(parameter, this);
                default:
                    return base.CreateChildForParameter(parameter);
            }
        }
    }
}