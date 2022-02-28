namespace WatchFace.Parser.Models.Elements
{
    public class BackgroundElement : ContainerElement
    {
        public BackgroundElement(Parameter parameter, Element parent = null, string name = null) :
            base(parameter, parent, name) { }

        public ImageElement Image { get; set; }
        
        // TODO
        // public String BackgroundColor { get; set; }

        protected override Element CreateChildForParameter(Parameter parameter)
        {
            switch (parameter.Id)
            {
                case 1:
                    Image = new ImageElement(parameter, this, nameof(Image));
                    return Image;
                // case 2:
                    // TODO
                case 3:
                case 4:
                case 5:
                    // skip background previews
                    return null;
                default:
                    return base.CreateChildForParameter(parameter);
            }
        }
    }
}