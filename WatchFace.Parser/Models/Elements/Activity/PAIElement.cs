using System.Drawing;
using WatchFace.Parser.Helpers;
using WatchFace.Parser.Interfaces;

namespace WatchFace.Parser.Models.Elements
{
    public class PAIElement : CompositeElement, IDrawable
    {
        public PAIElement(Parameter parameter, Element parent, string name= null) :
            base(parameter, parent, name) { }

        public ImageBoxElement Number { get; set; }


        public void Draw(Graphics drawer, Bitmap[] resources, WatchState state)
        {
            
            // TODO!!!
            
            var kilometers = state.Distance / 1000;
            var decimals = state.Distance % 1000 / 10;

            var images = Number.GetImagesForNumber(resources, kilometers);
            images.AddRange(Number.GetImagesForNumber(resources, decimals));

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
                default:
                    return base.CreateChildForParameter(parameter);
            }
        }
    }
}