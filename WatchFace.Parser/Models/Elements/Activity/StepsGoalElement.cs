using System.Drawing;
using WatchFace.Parser.Interfaces;

namespace WatchFace.Parser.Models.Elements
{
    public class StepsGoalElement : ImageSetElement, IDrawable
    {
        public StepsGoalElement(Parameter parameter, Element parent, string name = null) :
            base(parameter, parent, name) { }

        public new void Draw(Graphics drawer, Bitmap[] resources, WatchState state)
        {
            var index = (int) (state.Steps * ImagesCount) / state.Goal;
            Draw(drawer, resources, index);
        }
    }
}