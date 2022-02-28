using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using WatchFace.Parser.Helpers;

namespace WatchFace.Parser.Models.Elements
{
    public class ImageBoxElement : CoordinatesElement
    {
        public ImageBoxElement(Parameter parameter, Element parent, string name = null) :
            base(parameter, parent, name) { }

        public long BottomRightX { get; set; }
        public long BottomRightY { get; set; }
        public TextAlignment Alignment { get; set; }
        public long SpacingX { get; set; }
        public long SpacingY { get; set; }
        public long ImageIndex { get; set; }
        public long ImagesCount { get; set; }

        public Rectangle GetBox()
        {
            return new Rectangle((int) X, (int) Y, (int) (BottomRightX - X), (int) (BottomRightY - Y));
        }

        public Rectangle GetAltBox(CoordinatesElement altCoordinates)
        {
            return new Rectangle((int) altCoordinates.X, (int) altCoordinates.Y, (int) (BottomRightX - X), (int) (BottomRightY - Y));
        }

        public void Draw(Graphics drawer, Bitmap[] images, int number, int minimumDigits = 1)
        {
            // TODO how to deal with 2 spacings values
            // DrawerHelper.DrawImages(drawer, GetImagesForNumber(images, number, minimumDigits), (int) Spacing, Alignment, GetBox());
            DrawerHelper.DrawImages(drawer, GetImagesForNumber(images, number, minimumDigits), (int) SpacingX, Alignment, GetBox());
        }

        public List<Bitmap> GetImagesForNumber(Bitmap[] images, int number, int minimumDigits = 1)
        {
            var stringNumber = number.ToString().PadLeft(minimumDigits, '0');

            return (from digitChar in stringNumber
                select int.Parse(digitChar.ToString())
                into digit
                where digit < ImagesCount
                select images[ImageIndex + digit]).ToList();
        }

        protected override Element CreateChildForParameter(Parameter parameter)
        {
            switch (parameter.Id)
            {
                case 3:
                    BottomRightX = parameter.Value;
                    return new ValueElement(parameter, this, nameof(BottomRightX));
                case 4:
                    BottomRightY = parameter.Value;
                    return new ValueElement(parameter, this, nameof(BottomRightY));
                case 5:
                    Alignment = (TextAlignment) parameter.Value;
                    return new ValueElement(parameter, this, nameof(Alignment));
                case 6:
                    SpacingX = parameter.Value;
                    return new ValueElement(parameter, this, nameof(SpacingX));
                case 7:
                    SpacingY = parameter.Value;
                    return new ValueElement(parameter, this, nameof(SpacingY));
                case 8:
                    ImageIndex = parameter.Value;
                    return new ValueElement(parameter, this, nameof(ImageIndex));
                case 9:
                    ImagesCount = parameter.Value;
                    return new ValueElement(parameter, this, nameof(ImagesCount));
                default:
                    return base.CreateChildForParameter(parameter);
            }
        }
    }
}