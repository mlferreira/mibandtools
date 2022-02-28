using System.Collections.Generic;
using System.Drawing;
using WatchFace.Parser.Helpers;
using WatchFace.Parser.Interfaces;

namespace WatchFace.Parser.Models.Elements
{
    public class CaloriesElement : CompositeElement, IDrawable
    {
        
        public CaloriesElement(Parameter parameter, Element parent = null, string name = null) :
            base(parameter, parent, name) { }
        
        public ImageBoxElement Text { get; set; }
        public long SuffixImageIndex { get; set; }
        public long PrefixImageIndex { get; set; }
        
        
        public void Draw(Graphics drawer, Bitmap[] resources, WatchState state)
        {
            var images = new List<Bitmap>();

            images.Add(resources[PrefixImageIndex]);
            images.AddRange(Text.GetImagesForNumber(resources, state.Calories));
            images.Add(resources[SuffixImageIndex]);

            // TODO how to deal with 2 spacings values
            // DrawerHelper.DrawImages(drawer, images, (int) Text.Spacing, Text.Alignment, Text.GetBox());
            DrawerHelper.DrawImages(drawer, images, (int) Text.SpacingX, Text.Alignment, Text.GetBox());
        }
        
        protected override Element CreateChildForParameter(Parameter parameter)
        {
            switch (parameter.Id)
            {
                case 1:
                    Text = new ImageBoxElement(parameter, this);
                    return Text;
                case 2:
                    SuffixImageIndex = parameter.Value;
                    return new ValueElement(parameter, this);
                case 3:
                    PrefixImageIndex = parameter.Value;
                    return new ValueElement(parameter, this);
                default:
                    return base.CreateChildForParameter(parameter);
            }
        }
    }
}