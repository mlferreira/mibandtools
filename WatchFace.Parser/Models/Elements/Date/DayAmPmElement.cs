using System.Drawing;

namespace WatchFace.Parser.Models.Elements
{
    public class DayAmPmElement : CoordinatesElement
    {

        public DayAmPmElement(Parameter parameter, Element parent, string name = null) :
            base(parameter, parent, name) { }
        
        public long AMImageIndex { get; set; }
        public long PMImageIndex { get; set; }
        
        public void Draw(Graphics drawer, Bitmap[] resources, WatchState state)
        {
            var time = state.Time.Hour;

            var image = resources[PMImageIndex];
            if (time >= 12)
            {
                image = resources[PMImageIndex];
            }
            
            drawer.DrawImage(image, new Point((int) X, (int) Y));
        }
        
        protected override Element CreateChildForParameter(Parameter parameter)
        {
            switch (parameter.Id)
            {
                case 3:
                case 5:
                    AMImageIndex = parameter.Value;
                    return new ValueElement(parameter, this, nameof(AMImageIndex));
                case 4:
                case 6:
                    PMImageIndex = parameter.Value;
                    return new ValueElement(parameter, this, nameof(PMImageIndex));

                default:
                    return base.CreateChildForParameter(parameter);
            }
        }
    }
}